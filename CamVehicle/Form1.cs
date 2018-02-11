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
        VideoCapture cap;
        VideoWriter saver;
        uint uFps, uFrameWidth, uFrameHeight;
       
        Mat matFrame;
        Mat matToShow;

        bool bSave, bDetectCascade, bDetectBlob;
        string strCapType, strCapFeed;

        CameraFeed camFeed = new CameraFeed();
        ImageList imageList = new ImageList();
        Detector detector = new Detector();
        Settings setting = new Settings();

        System.Drawing.Size minSize;
        Color colorRect;

        string strSavePath;

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

            }catch (Exception) {
                MessageBox.Show("Cannot load icon images for list view");  }

            listView1.View = View.LargeIcon;
            listView1.LargeImageList = imageList;

            minSize = new System.Drawing.Size(0, 0);
            colorRect = Color.FromArgb(255, 255, 0, 0);

            strCapFeed = "";
        }

        private void showImage(Mat cvImg)
        {
            Cv2.Resize(cvImg, matToShow, new OpenCvSharp.Size(pictureBox1.Width, pictureBox1.Height));

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
            Log_Print("Manual Device", "Video", "Opening", "", "", "");
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
                Log_Print("Manual Device", "Camera", "Opening", "", "", "");
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

                Log_Print("Manual Device", strCapType, "start", "", "", "");
            }
            else
            {
                MessageBox.Show("There is no connected video feed!");
                Log_Print("Manual Device", strCapType, "failed", "", "", "");
            }
        }

        private void Log_Print(string strChannel, string strFeedType="", string strEvent="", string strOrigin="", string strRule="", string strObjID="")
        {
            ListViewItem item = new ListViewItem(strChannel);
            item.SubItems.Add(strFeedType);
            item.SubItems.Add(strEvent);
            item.SubItems.Add(strOrigin);
            item.SubItems.Add(strRule);            
            item.SubItems.Add(DateTime.Now.ToString("yyyy_MM_dd-H_mm_ss"));
            item.SubItems.Add(strObjID);

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
                Log_Print("Manual Device", strCapType, "saved", "", "", "");
            }
            Log_Print("Manual Device", strCapType, "stopped", "", "", "");
        }


        // ***

        

        private Mat drawCars(Mat matFrame, List<Rect> cars)
        {
            var rnd = new Random();
            var count = 1;
            for (int i=0; i < cars.Count; i++)
            {
                var carRect = cars[i];                
                if (carRect.Width > minSize.Width && carRect.Height > minSize.Height)
                {
                    Cv2.Rectangle(matFrame, carRect, new Scalar(colorRect.B, colorRect.G, colorRect.R), 2);
                    count++;
                }                
            }

            Log_Print("Manual Device", strCapType, "detecting", "", "", count.ToString() + "detected");
            return matFrame;
        }


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

            minSize = setting.get_MinSize();

            colorRect = setting.get_ColorRect();


        }

        // *** CheckBox for Save and Detecting -----------------------------------------------------
        
        private void btnSetting_Click(object sender, EventArgs e)
        {
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

       

        // *** Timer event
        private void timer_Tick(object sender, EventArgs e)
        {
            // main process
            try                 
            {
                cap.Read(matFrame);
                if (bDetectCascade)
                {                                     
                    showImage(drawCars(matFrame, detector.proc(matFrame)));
                }
                if (bDetectBlob)
                {
                    showImage(drawCars(matFrame, detector.proc2(matFrame)));                        
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
                    Log_Print("Manual Device", strCapType, "disconnected", "", "", "");
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
