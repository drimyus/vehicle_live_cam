using System;
using System.Windows.Forms;
using System.IO;

using OpenCvSharp;
using System.Diagnostics;
using System.Drawing;
using OpenCvSharp.Extensions;
using System.Collections.Generic;



namespace CamVehicle
{
    public partial class Form1 : Form  
    {
        /// <summary> 
        /// The main form for CamVehicle project
        /// </summary>


        ImageList imageList = new ImageList();

        CameraFeed camFeed = new CameraFeed();        
        Detector detector = new Detector();
        Settings setting = new Settings();
        WebExport exporter = new WebExport();
        ROI roi = new ROI();
        ListViewToCSV liToCsv = new ListViewToCSV();

        VideoCapture cap;
        VideoWriter saver;
        uint uFps, uFrameWidth, uFrameHeight;
       
        Mat matFrame;
        Mat matToShow;

        bool bSave, bDetectCascade, bDetectBlob;
        string strCapType, strCapFeed;

        List<string> roiElements;

        List<Rect> trackObjects;
        List<int> trackIDs;
        List<int> trackVelocity;
        int uniqueID;
        
        List <System.Drawing.Size> liSizes;
        Color colorRect, colorROI;        

        string strSavePath;

        List<List<OpenCvSharp.Point>> roiLines = new List<List<OpenCvSharp.Point>>();
        List<string> lblLines;
        List<List<OpenCvSharp.Point>> roiZones = new List<List<OpenCvSharp.Point>>();
        List<string> lblZones;

        List<OpenCvSharp.Point> roiTrackArea = new List<OpenCvSharp.Point>();
        Mat maskTrackArea;

        List<int> crossLinesCounts;

        int uPort;
        string strHost;

        int iRctFntSz, iROIFntSz;

        int origin_pic_w, origin_pic_h;
        bool bShowRect, bShowROI;

        double dThreshRct;

        public Queue<Mat> queueFrame;
        

        public Form1()
        {
            // check the user name and password
            Start start = new Start();
            start.ShowDialog();

            // load the settings
            LoadSettings();

            InitializeComponent();
            uFps = 0;
            uFrameHeight = 0;
            uFrameWidth = 0;

            cap = new VideoCapture();            

            bSave = false;
            bDetectCascade = false;
            bDetectBlob = true;


            matFrame = new Mat();
            matToShow = new Mat();

            // default background image    
            string strBckImgPath = @"../res/background.jpg";
            if (File.Exists(strBckImgPath)){
                showImage(Cv2.ImRead(strBckImgPath));}
            else{
                MessageBox.Show("No exist background Image " + Directory.GetCurrentDirectory());}

            // List View Images
            try
            {
                imageList.Images.Add(Bitmap.FromFile(@"../res/video.bmp"));
                imageList.Images.Add(Bitmap.FromFile(@"../res/camera.bmp"));

            } catch (Exception) {
                MessageBox.Show("Cannot load icon images for list view");
            }

            listView1.View = View.LargeIcon;
            listView1.LargeImageList = imageList;

            colorRect = Color.FromArgb(255, 0, 255, 255);
            colorROI = Color.FromArgb(255, 0, 0, 255);

            strCapFeed = "";

            trackObjects = new List<Rect>();
            trackIDs = new List<int>();
            trackVelocity = new List<int>();
            uniqueID = 0;

            roiLines = new List<List<OpenCvSharp.Point>>();
            lblLines = new List<string>();

            roiZones = new List<List<OpenCvSharp.Point>>();
            lblZones = new List<string>();

            maskTrackArea = new Mat(pictureBox1.Height, pictureBox1.Width, MatType.CV_8UC3, new Scalar(1, 1, 1));
            roiTrackArea = new List<OpenCvSharp.Point>();

            crossLinesCounts = new List<int>();

            origin_pic_w = pictureBox1.Width;
            origin_pic_h = pictureBox1.Height;

            queueFrame = new System.Collections.Generic.Queue<Mat>(20);
        }

        private void showImage(Mat cvImg)
        {
            if (bShowROI)
            {

                if (roiLines.Count > 0)
                {
                    for (int i = 0; i < roiLines.Count; i++)
                    {
                        for (int j = 0; j < roiLines[i].Count; j++)
                        {
                            Cv2.Line(cvImg, roiLines[i][j % roiLines[i].Count], roiLines[i][(j + 1) % roiLines[i].Count], new Scalar(colorROI.B, colorROI.G, colorROI.R), iROIFntSz);
                        }

                        Cv2.PutText(cvImg, lblLines[i], roiLines[i][0], HersheyFonts.HersheyPlain, (double)iROIFntSz / 2, new Scalar(colorROI.B, colorROI.G, colorROI.R), iROIFntSz);
                    }
                }
                if (roiZones.Count > 0)
                {
                    for (int i = 0; i < roiZones.Count; i++)
                    {
                        for (int j = 0; j < roiZones[i].Count; j++)
                        {
                            Cv2.Line(cvImg, roiZones[i][j % roiZones[i].Count], roiZones[i][(j + 1) % roiZones[i].Count], new Scalar(colorROI.B, colorROI.G, colorROI.R), iROIFntSz);
                        }

                        Cv2.PutText(cvImg, "Zone " + (i + 1).ToString(), roiZones[i][0], HersheyFonts.HersheyPlain, (double)iROIFntSz / 2, new Scalar(colorROI.B, colorROI.G, colorROI.R), iROIFntSz);
                    }
                }

                if (roiTrackArea.Count > 0)
                {
                    for (int j = 0; j < roiTrackArea.Count; j++)
                    {
                        Cv2.Line(cvImg, roiTrackArea[j % roiTrackArea.Count], roiTrackArea[(j + 1) % roiTrackArea.Count], new Scalar(colorROI.B, colorROI.G, colorROI.R), iROIFntSz);
                    }

                    Cv2.PutText(cvImg, "trackarea", roiTrackArea[0], HersheyFonts.HersheyPlain, (double)iROIFntSz / 2, new Scalar(colorROI.B, colorROI.G, colorROI.R), iROIFntSz);
                }
            }
            pictureBox1.Image = BitmapConverter.ToBitmap(cvImg);
        }

        private void LoadVideo()
            ///<summary>
            /// input the local video file path with FileOpenDialogue.
            /// configure the video capture
            /// </summary>
        {

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (cap != null) cap.Dispose();
                // create the video capture
                string path = openFileDialog.FileName;
                cap = VideoCapture.FromFile(path);

                // display the input file name
                string inFname = Path.GetFileName(path);
                // lblInput.Text = "Video File: " + inFname;

                uFps = (uint)cap.Get(CaptureProperty.Fps);
                uFrameWidth = (uint)cap.Get(CaptureProperty.FrameWidth);
                uFrameHeight = (uint)cap.Get(CaptureProperty.FrameHeight);

                strCapType = "Video";
                strCapFeed = path;
            }
            
        }

        private void loadVideoToolStripMenuItem_Click(object sender, EventArgs e)
            ///<summary>
            /// load menu clicking event
            ///</summary>
        {

            LoadVideo();
        }

        private void btnVideoOpen_Click(object sender, EventArgs e)
            ///<summary>
            /// shortcut button event for load video
            ///</summary>
        {
            LoadVideo();
        }

        // Load Camera
        private void LoadCamera()
            ///<summary>
            /// input the camera feed and configure the video capture from the camera feed(url)
            ///</summary>
        {
            camFeed.ShowDialog();
            strCapFeed = camFeed.getCamFeed();
            if (strCapFeed == "")
            {
                return;
            }
            else if (strCapFeed.Length == 1)
            {
                if (cap != null) cap.Dispose();
                int uCamID;
                if (Int32.TryParse(strCapFeed, out uCamID)) {
                    cap = VideoCapture.FromCamera(uCamID);
                }

            }
            else
            {
                if (cap != null) cap.Dispose();
                cap = VideoCapture.FromFile(strCapFeed);
            }

            if (cap != null)
            {

                uFrameWidth = (uint)cap.Get(CaptureProperty.FrameWidth);
                uFrameHeight = (uint)cap.Get(CaptureProperty.FrameHeight);
                uFps = (uint)cap.Get(CaptureProperty.Fps);
                if ((uFps < 10) || (uFps > 60))  { uFps = 30; }

                strCapType = "Camera";                
            }
            
        }
        private void loadIPCamToolStripMenuItem_Click(object sender, EventArgs e)
            ///<summary>
            /// menu clicking event for camera input 
            ///</summary>
        {

            LoadCamera();
        }

        private void btnCamOpen_Click(object sender, EventArgs e)
            ///<summary>
            /// button clicking event for camera input 
            ///</summary>
        {
            LoadCamera();
        }

        private void loadImageToolStripMenuItem_Click(object sender, EventArgs e)
            ///<summary>
            /// image loading. 
            ///     this is for only testing
            ///</summary>
        {

            if (cap != null) cap.Dispose();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                showImage(Cv2.ImRead(path));

                Console.WriteLine(path);
            }
        }

       
        // *** Start and Stop Button ---------------------------------------------------------------
        private void btnStart_Click(object sender, EventArgs e)
        ///<summary>
        /// start button for start playing and detecting.
        /// if any kind of issue is occurred, then start the video playing and detecting
        /// 
        /// if start button is clicked, timer starts running and the playing and detecting progress starts running
        /// 
        ///</summary>
        {

            if (cap != null && strCapFeed != "")
            {
                if (bSave)
                {
                    saver = new VideoWriter(strSavePath, FourCC.DIVX, (double)uFps, new OpenCvSharp.Size((double)uFrameWidth, (double)uFrameHeight));
                }
                btnStart.Enabled = false;
                btnStop.Enabled = true;

                timer.Interval = (int)(1000 / uFps);
                timer.Enabled = true;
               
            }
            else
            {
                MessageBox.Show("There is no connected video feed!");
            }
        }

        private void Log_Print(string strFeedType, string strEvent="", string strObjID="", string strVehicleType="")
        ///<summary>
        /// print the log string to the target csv file.
        ///</summary>
        ///
        /// <param name="strEvent"> (string)the event type e.g. ["Line X Crossed" or "Object Appear"]</param>
        /// <param name="strFeedType"> (string) the Source of Video e.g. ["Camera", "Video"] </param>
        /// <param name="strObjID"> (string) Id of object e.g. "1", "2", "3", </param>
        /// <param name="strVehicleType"> (string) type of vehicle (not implemented yet, e.g. ["Bicycle", "Car", "Truck", "Crowd"]</param>
        {
            var strChannel = "";
            if (strFeedType == "Camera")
            {
                if (strCapFeed.Length == 1) { strChannel = strCapFeed; }
                else { strChannel = "IP Camera"; }
            }
            if (strFeedType == "Video")
                strChannel = "Video";

            ListViewItem item = new ListViewItem(strChannel);

            item.SubItems.Add(strFeedType);
            item.SubItems.Add(strEvent);
            var strDate = DateTime.Now.ToString("yyyy_MM_dd-H_mm_ss");
            item.SubItems.Add(strDate);
            item.SubItems.Add(strObjID);
            item.SubItems.Add(strVehicleType);

            listView2.Items.Add(item);

            var log_str = strChannel + "_" +
                strFeedType + "_" +
                strEvent + "_" +
                strDate + "_" +
                strObjID + "_" +
                strVehicleType;
                
            exporter.SendUDP(strHost, uPort, log_str);
        }
        private void btnStop_Click(object sender, EventArgs e) 
            ///<summary>
            /// stop button for stop running timer
            ///</summary>
        {
            btnStop.Enabled = false;
            btnStart.Enabled = true;

            timer.Enabled = false;

            if (bSave)
            {
                saver.Release();
            }
            var liToCsv = new ListViewToCSV();
            liToCsv.listView_to_csv(listView2, "result.csv", false);
        }


        // ***
        private void LoadSettings()
        ///<summary>
        /// load parameters from the Setting Form 
        /// detection mode, 
        /// liSizes: size of threshold for identify the vehicle type, 
        /// bShowRect, bShowROI: flag for showing the rect and ROI,
        /// colorRect, colorROI: color for drawing the Rectangle and ROI
        /// dThreshRct: the threshold to identify the same rect.
        /// iRctFntSz, bShowROI: font Size for ROI and Rectangle
        ///</summary>

        {
            bSave = setting.getSaveChecked();
            strSavePath = setting.getSavePath();
            
            var detectMode = setting.getDetectMode();
            switch (detectMode) {
                case 0:
                    bDetectBlob = false;
                    bDetectCascade = false;
                    break;
                case 1:
                    bDetectBlob = false;
                    bDetectCascade = true;
                    break;
                case 2:
                    bDetectBlob = true;
                    bDetectCascade = false;
                    break;
                default:
                    break;
            }

            liSizes = setting.getSizes();
            var colors= setting.getColors();
            colorRect = colors[0];
            colorROI = colors[1];

            uPort = setting.getPort();
            strHost = setting.getHost();

            iRctFntSz = setting.getRctFntSz();
            iROIFntSz = setting.getROIFntSz();

            bShowRect = setting.getShowRectChecked();
            bShowROI = setting.getShowROIChecked();

            dThreshRct = setting.getThreshSameRect();

        }

        // *** CheckBox for Save and Detecting -----------------------------------------------------
        
        private void btnSetting_Click(object sender, EventArgs e)
            /// <summary>
            ///  Open the Setting Form with shortcut button
            /// </summary>
        {
            btnStop.Enabled = false;
            btnStart.Enabled = true;

            timer.Enabled = false;

            setting.ShowDialog();
            LoadSettings();
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
            /// <summary>
            ///  Open the Setting Form with menu
            /// </summary>
        {
            setting.ShowDialog();
            LoadSettings();            
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
            /// <summary>
            ///  Open the Help Form with menu
            /// </summary>
        {

        }

        private void btnROI_Click(object sender, EventArgs e)
            /// <summary>
            ///  Open the ROI setting Form with shortcut Button
            /// </summary>
        {
            btnStop.Enabled = false;
            btnStart.Enabled = true;

            timer.Enabled = false;
            
            if ((matFrame != null) && (matFrame.Width != 0))
            {
                roi.setInitImage(matFrame);
                roi.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select the camera feed!");
            }
           
            
            roiElements = roi.getROIs();
            if (roiElements.Count != 0)
            {
                roiLines.Clear();
                lblLines.Clear();
                roiZones.Clear();
                lblZones.Clear();
                for (int i = 0; i < roiElements.Count; i++)
                {
                    crossLinesCounts.Add(0);

                    string[] vals = roiElements[i].Split('_');
                    if (vals[1] == "line"){
                        List<OpenCvSharp.Point> roiLine = new List<OpenCvSharp.Point>();
                        for (int j = 2; j < vals.Length; j++)
                        {
                            roiLine.Add(new OpenCvSharp.Point(Int32.Parse(vals[j].Split(',')[0]), Int32.Parse(vals[j].Split(',')[1])));
                        }
                        roiLines.Add(roiLine);
                        lblLines.Add(vals[0]);

                    }
                    if (vals[1] == "zone"){
                        List<OpenCvSharp.Point> roiZone = new List<OpenCvSharp.Point>();
                        for (int j = 2; j < vals.Length; j++)
                        {
                            roiZone.Add(new OpenCvSharp.Point(Int32.Parse(vals[j].Split(',')[0]), Int32.Parse(vals[j].Split(',')[1])));
                        }
                        roiZones.Add(roiZone);
                        lblZones.Add(vals[0]);
                    }

                    if (vals[1] == "trackarea"){
                        roiTrackArea.Clear();
                        List<OpenCvSharp.Point> roiZone = new List<OpenCvSharp.Point>();
                        for (int j = 2; j < vals.Length; j++)
                        {
                            roiZone.Add(new OpenCvSharp.Point(Int32.Parse(vals[j].Split(',')[0]), Int32.Parse(vals[j].Split(',')[1])));
                        }
                        roiTrackArea = roiZone;
                        maskTrackArea.Empty();
                        maskTrackArea.Release();

                        maskTrackArea = new Mat(roi.getPicBoxSz().Height, roi.getPicBoxSz().Width, MatType.CV_8UC3, new Scalar(0, 0, 0));
                        Cv2.FillConvexPoly(maskTrackArea, roiTrackArea, new Scalar(1, 1, 1), LineTypes.Link8, 0);

                    }
                }
            }

            resize_ROIs(roi.getPicBoxSz(), new System.Drawing.Size(pictureBox1.Width, pictureBox1.Height));
        }
        

        private Mat updateObjects(List<Rect> cars)
            /// <summary>
            ///  check the events for each tracking vehicles
            ///  scanning the list of vehicles which are tracking on the scene 
            ///  while tracking, if the vehicle is checked with rule event(cross line or disappear) then log_print
            /// </summary>
        {
            List<int> liToDel = new List<int>();
            List<int> liToAdd = new List<int>();

            //var new_cnt = 0;
            //var old_cnt = 0;
            for (int c = 0; c < cars.Count; c++)
            {
                if ((cars[c].Width < liSizes[0].Width) || (cars[c].Width > liSizes[3].Width * 2))
                    continue;

                int trk = -1;
                int vel = 0;
                for (int t = 0; t < trackObjects.Count; t++)
                {
                    if (liToDel.Contains(t)) continue;
                    trackVelocity[t] -= 1;
                    if (trackVelocity[t] < -50)
                    {
                        liToDel.Add(t);
                        continue;
                    }

                    if (detector.isSameRects(trackObjects[t], cars[c], dThreshRct)) {
                        trk = t;
                        vel = detector.disRect2Rect(trackObjects[t], cars[c]);

                        for (int i = 0; i < roiLines.Count; i++)
                            if (detector.isCrossLine(trackObjects[t], cars[c], roiLines[i])){
                                // Draw vehicle
                                if (bShowRect) { Cv2.Rectangle(matToShow, cars[c], new Scalar(0, 0, 255), -1); }
                                crossLinesCounts[i]++;
                                Log_Print(strCapType, lblLines[i] + " Crossed", crossLinesCounts[i].ToString(), getObjectClass(trackObjects[trk]));
                                break;
                            }
                        break;
                    }
                    
                }

                if (trk != -1) {                    
                    trackObjects[trk] = cars[c];
                    trackVelocity[trk] = vel;
                    //old_cnt += 1;
                }
                else {

                    if (detector.isBorderRect(cars[c], matFrame.Size())) {
                        Cv2.Circle(matToShow, new OpenCvSharp.Point(cars[c].X, cars[c].Y), 5, new Scalar(0, 0, 255), 1);
                        // new_cnt += 1;
                    }
                    liToAdd.Add(c);
                }
            }

            for (int d = liToDel.Count - 1; d >= 0; d--)
            {
                try
                {
                    trackObjects.RemoveAt(liToDel[d]);
                    trackVelocity.RemoveAt(liToDel[d]);
                    //uniqueID -= 1;
                }
                catch
                {
                    Console.WriteLine("except:" + trackObjects.Count.ToString() + ":" + liToDel.Count.ToString() + ":" + d.ToString());
                }

            }
           

            for (int a = 0; a < liToAdd.Count; a++){
                //uniqueID += 1;
                //trackIDs.Add(uniqueID);
                trackObjects.Add(cars[liToAdd[a]]);
                trackVelocity.Add(0);
            }

            if (bShowRect) {
                for (int t = trackObjects.Count - 1; t >= 0; t--)
                {
                    Cv2.Rectangle(matToShow, trackObjects[t], new Scalar(colorRect.B, colorRect.G, colorRect.R), iRctFntSz);
                }
            }


            //Console.WriteLine(new_cnt.ToString() + ":" + old_cnt.ToString() + ":" + trackObjects.Count);
            return matToShow;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {

        }

        private void resize_ROIs(System.Drawing.Size before, System.Drawing.Size after)
        ///<summary>
        /// Resize the ROIs when the size of Form is being changed
        ///</summary>
        ///<param name="after"> the new form size after resizing </param>
        ///<param name="before"> the original form size before resizing </param>
        {
            Cv2.Resize(maskTrackArea, maskTrackArea, new OpenCvSharp.Size(after.Width, after.Height));

            for (int i = 0; i < roiLines.Count; i++)
            {
                for (int j = 0; j < roiLines[i].Count; j++)
                {
                    double x = roiLines[i][j].X * after.Width / before.Width;
                    double y = roiLines[i][j].Y * after.Height / before.Height;

                    roiLines[i][j] = new OpenCvSharp.Point(x, y);
                }
            }

            for (int j = 0; j < roiTrackArea.Count; j++)
            {
                double x = roiTrackArea[j].X * after.Width / before.Width;
                double y = roiTrackArea[j].Y * after.Height / before.Height;

                roiTrackArea[j] = new OpenCvSharp.Point(x, y);
            }

        }
        private void pictureBox1_Resize(object sender, EventArgs e)
            ///<summary>
            /// resize the picture box when the main From is reszing
            ///</summary>

        {
            if ((roiLines.Count > 0) && (origin_pic_w != 0) && (origin_pic_h != 0))
            {
                resize_ROIs(new System.Drawing.Size(origin_pic_w, origin_pic_h), new System.Drawing.Size(pictureBox1.Width, pictureBox1.Height));
            }
            else {
                if ((pictureBox1.Width != 0) && (pictureBox1.Height != 0))
                    Cv2.Resize(maskTrackArea, maskTrackArea, new OpenCvSharp.Size(pictureBox1.Width, pictureBox1.Height));
            }
            
            origin_pic_w = pictureBox1.Width;
            origin_pic_h = pictureBox1.Height;            
        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
            ///<summary>
            /// take the Form size before resizing
            ///</summary>
        {
            origin_pic_w = pictureBox1.Width;
            origin_pic_h = pictureBox1.Height;                
        }

        private string getObjectClass(Rect r)
            /// <summary>
            ///  identify the Object Type with its size.
            /// </summary>
            /// <param name="r"> rectangle of the detected vehicle whic is added to the list for tracking until disappearedd</param>
        {
            if (r.Width < liSizes[1].Width)
                return "Bicycle";
            else if (liSizes[1].Width < r.Width && r.Width < liSizes[2].Width)
                return "Car";
            else if (liSizes[2].Width < r.Width && r.Width < liSizes[3].Width)
                return "Truck";
            else
                return "Crowd";
        }

       
        private void addObject(Rect r)
            /// <summary>
            /// add the rect(vehicle) to the list of rectangles which are tracking vehicles.
            /// also log_print("object appear")
            /// </summary>
            /// <param name="r"> rect of the vehicle</param>
        {
            trackObjects.Add(r);
            uniqueID += 1;
            trackIDs.Add(uniqueID);

            trackVelocity.Add(-1);
            Log_Print(strCapType, "Object Appear", uniqueID.ToString(), getObjectClass(r));
        }


        // *** Timer event
        private void timer_Tick(object sender, EventArgs e)
        {
            ///<summary>
            /// main process 
            /// detecting and showing
            ///</summary> 
            try
            {
                cap.Read(matFrame);
                Cv2.Resize(matFrame, matFrame, new OpenCvSharp.Size(pictureBox1.Width, pictureBox1.Height));

                matFrame.CopyTo(matToShow);
                Cv2.Multiply(matFrame, maskTrackArea, matFrame);

                if (bDetectCascade)
                {
                    //showImage(updateObjects(detector.proc(matFrame)));
                }
                else if (bDetectBlob)
                {
                    showImage(updateObjects(detector.proc2(matFrame)));
                }
                else {
                    showImage(matToShow);
                }

                if (bSave)
                {
                    saver.Write(matFrame);
                }
                    
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                btnStop.Enabled = false;
                btnStart.Enabled = true;
                if (timer.Enabled == true) timer.Enabled = false;

                if (strCapFeed != "" && cap != null)
                {

                    System.Threading.Thread.Sleep((int)(1000 / uFps));
                    cap.Set(CaptureProperty.PosFrames, 0);
                    cap.Read(matFrame);
                }
                else
                {
                    MessageBox.Show("Can't read frame!");
                    cap.Dispose();
                }
            }

        }
        // ***

        private void btnAddList_Click(object sender, EventArgs e)
            /// <summary>
            /// Add the video capture object to the captures-list
            /// </summary>
        {
            if (cap != null)
            {
                ListViewItem item = new ListViewItem("Capture");

                if (strCapType == "Video")
                    item.ImageIndex = 0;
                if (strCapType == "Camera")
                    item.ImageIndex = 1;
                item.SubItems.Add(strCapFeed);

                listView1.Items.Add(item);

            }
            else
            {
                MessageBox.Show("No video capture!");
            }            
        }

        private void btnEditList_Click(object sender, EventArgs e){        }

        private void btnRemoveList_Click(object sender, EventArgs e)
            /// <summary>
            /// button for remove the added video capture object from the list
            /// </summary>
        {
            if (listView1.SelectedItems.Count != 0)
            {
                int idx = listView1.Items.IndexOf(listView1.SelectedItems[0]);
                listView1.Items.RemoveAt(idx);
            }

        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
    }
}
