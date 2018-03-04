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
        ImageList imageList = new ImageList();

        CameraFeed camFeed = new CameraFeed();        
        Detector detector = new Detector();
        Settings setting = new Settings();
        ROI roi = new ROI();


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
        List<List<OpenCvSharp.Point>> roiZones = new List<List<OpenCvSharp.Point>>();

        List<int> crossLinesCounts;

        public Form1()
        {
            InitializeComponent();
            uFps = 0;
            uFrameHeight = 0;
            uFrameWidth = 0;

            cap = new VideoCapture();            

            bSave = false;
            bDetectCascade = false;
            bDetectBlob = false;


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
            roiZones = new List<List<OpenCvSharp.Point>>();

            crossLinesCounts = new List<int>();
        }

        private void showImage(Mat cvImg)
        {
            Cv2.Resize(cvImg, matToShow, new OpenCvSharp.Size(pictureBox1.Width, pictureBox1.Height));
            if (roiLines.Count > 0)
            {
                for (int i = 0; i < roiLines.Count; i++) {
                    for (int j = 0; j < roiLines[i].Count; j++){
                        Cv2.Line(matToShow, roiLines[i][j % roiLines[i].Count], roiLines[i][(j + 1) % roiLines[i].Count], new Scalar(colorROI.B, colorROI.G, colorROI.R), 2);}
                        
                    Cv2.PutText(matToShow, "Line " + (i+1).ToString(), roiLines[i][0], HersheyFonts.HersheyPlain, 0.8, new Scalar(colorROI.B, colorROI.G, colorROI.R), 1);                    
                }
            }
            if (roiZones.Count > 0)
            {
                for (int i = 0; i < roiZones.Count; i++)
                {
                    for (int j = 0; j < roiZones[i].Count; j++){
                        Cv2.Line(matToShow, roiZones[i][j % roiZones[i].Count], roiZones[i][(j + 1) % roiZones[i].Count], new Scalar    (colorROI.B, colorROI.G, colorROI.R), 2);}

                    Cv2.PutText(matToShow, "Zone " + (i + 1).ToString(), roiZones[i][0], HersheyFonts.HersheyPlain, 0.8, new Scalar(colorROI.B, colorROI.G, colorROI.R), 1);
                }
            }
            pictureBox1.Image = BitmapConverter.ToBitmap(matToShow);            
        }

        // Load Video
        private void LoadVideo()
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
        {
            LoadVideo();
        }

        private void btnVideoOpen_Click(object sender, EventArgs e)
        {
            LoadVideo();
        }

        // Load Camera
        private void LoadCamera()
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
                if (Int32.TryParse(strCapFeed, out uCamID)){
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
                if (uFps == 0) { uFps = 30; }

                strCapType = "Camera";                
            }
            
        }
        private void loadIPCamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadCamera();
        }

        private void btnCamOpen_Click(object sender, EventArgs e)
        {
            LoadCamera();
        }



        private void loadImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cap != null) cap.Dispose();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                pictureBox1.Image = BitmapConverter.ToBitmap(Cv2.ImRead(path));

                Console.WriteLine(path);
            }
        }

       
        // *** Start and Stop Button ---------------------------------------------------------------
        private void btnStart_Click(object sender, EventArgs e)
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
            item.SubItems.Add(DateTime.Now.ToString("yyyy_MM_dd-H_mm_ss"));
            item.SubItems.Add(strObjID);
            item.SubItems.Add(strVehicleType);

            listView2.Items.Add(item);
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStop.Enabled = false;
            btnStart.Enabled = true;

            timer.Enabled = false;

            if (bSave)
            {
                saver.Release();
            }
            
        }


        // ***
        private void LoadSettings()
        {
            bSave = setting.get_bSaveChecked();
            strSavePath = setting.get_strSavePath();
            
            var detectMode = setting.get_bDetectMode();
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

            liSizes = setting.get_Sizes();
            var colors= setting.get_Colors();
            colorRect = colors[0];
            colorROI = colors[1];

        }

        // *** CheckBox for Save and Detecting -----------------------------------------------------
        
        private void btnSetting_Click(object sender, EventArgs e)
        {
            btnStop.Enabled = false;
            btnStart.Enabled = true;

            timer.Enabled = false;

            setting.ShowDialog();
            LoadSettings();            
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setting.ShowDialog();
            LoadSettings();            
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void btnROI_Click(object sender, EventArgs e)
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
            roiLines.Clear();
            roiZones.Clear();
            for (int i = 0; i < roiElements.Count; i++)
            {
                crossLinesCounts.Add(0);

                string[] vals = roiElements[i].Split('_');
                if (vals[0] == "Line")
                {
                    List<OpenCvSharp.Point> roiLine = new List<OpenCvSharp.Point>();
                    for (int j = 2; j < vals.Length; j++)
                    {
                        roiLine.Add(new OpenCvSharp.Point(Int32.Parse(vals[j].Split(',')[0]), Int32.Parse(vals[j].Split(',')[1])));
                    }
                    roiLines.Add(roiLine);
                    
                }
                if (vals[0] == "Zone")
                {
                    List<OpenCvSharp.Point> roiZone = new List<OpenCvSharp.Point>();
                    for (int j = 2; j < vals.Length; j++)
                    {
                        roiZone.Add(new OpenCvSharp.Point(Int32.Parse(vals[j].Split(',')[0]), Int32.Parse(vals[j].Split(',')[1])));
                    }
                    roiZones.Add(roiZone);
                }
            }
        }

        private Mat updateObjects(List<Rect> cars)
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

                    if (detector.isSameRects(trackObjects[t], cars[c])) {
                        trk = t;
                        vel = detector.disRect2Rect(trackObjects[t], cars[c]);

                        for (int i = 0; i < roiLines.Count; i++)
                            if (detector.isCrossLine(trackObjects[t], cars[c], roiLines[i])){
                                // Draw vehicle
                                Cv2.Rectangle(matFrame, cars[c], new Scalar(0, 0, 255), -1);
                                crossLinesCounts[i]++;
                                Log_Print(strCapType, "Line " + (i+1).ToString() + " Crossed", crossLinesCounts[i].ToString(), getObjectClass(trackObjects[trk]));
                                break;
                            }
                        break;
                    }
                    
                }

                if (trk != -1) {
                    /*
                    var apr = detector.checkAppearObject(trackObjects[trk], cars[c], matFrame.Size());

                    Scalar color = new Scalar(255, 255, 0);
                    if (apr == 0) {
                        //color = new Scalar(0, 0, 255);
                        Console.WriteLine("appear");

                        //Log_Print(strCapType, "Object Appear", trackIDs[trk].ToString(), getObjectClass(trackObjects[trk]));
                    }

                    if (apr == 1) {
                        //color = new Scalar(255, 0, 0);
                       
                        liToDel.Add(trk);
                        Console.WriteLine("disappear");

                        //Log_Print(strCapType, "Object Disappear", trackIDs[trk].ToString(), getObjectClass(trackObjects[trk]));
                    }

                    */
                    
                    trackObjects[trk] = cars[c];
                    trackVelocity[trk] = vel;
                    //old_cnt += 1;
                }
                else {

                    if (detector.isBorderRect(cars[c], matFrame.Size())) {
                        Cv2.Circle(matFrame, new OpenCvSharp.Point(cars[c].X, cars[c].Y), 5, new Scalar(0, 0, 255), 1);
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

            for (int t = trackObjects.Count - 1; t >= 0; t--){
                Cv2.Rectangle(matFrame, trackObjects[t], new Scalar(255, 255, 0), 1);
            }

            //Console.WriteLine(new_cnt.ToString() + ":" + old_cnt.ToString() + ":" + trackObjects.Count);
            return matFrame;
        }
                        

        private string getObjectClass(Rect r)
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
            // main process
            try
            {
                cap.Read(matFrame);

                Cv2.Resize(matFrame, matFrame, new OpenCvSharp.Size(pictureBox1.Width, pictureBox1.Height));

                if (bDetectCascade)
                {
                    //
                }
                else if (bDetectBlob)
                {
                    // updateObjects(detector.proc2(matFrame));
                    showImage(updateObjects(detector.proc2(matFrame)));
                }
                else { showImage(matFrame); }

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
        private void btnEditList_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                MessageBox.Show("Edit Capture...");
            }
        }

        private void btnRemoveList_Click(object sender, EventArgs e)
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
