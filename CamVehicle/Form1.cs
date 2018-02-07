using System;
using System.Windows.Forms;
using System.IO;

using OpenCvSharp;
using System.Diagnostics;
using System.Drawing;
using OpenCvSharp.Extensions;

namespace CamVehicle
{
    public partial class Form1 : Form
    {
        VideoCapture cap;
        uint uFps, uFrameWidth, uFrameHeight;
       
        Mat matFrame;
        Mat matToShow;

        bool bSave, bDetect;
        string strCapType, strCapFeed;

        CameraFeed camFeed = new CameraFeed();
        ImageList imageList = new ImageList();
        Detector detector = new Detector();

        public Form1()
        {
            InitializeComponent();
            uFps = 0;
            uFrameHeight = 0;
            uFrameWidth = 0;

            cap = new VideoCapture();

            bSave = false;
            bDetect = false;

            matFrame = new Mat();
            matToShow = new Mat();

            // default background image    
            string strBckImgPath = @"../../res/background.jpg";
            if (File.Exists(strBckImgPath)){
                showImage(Cv2.ImRead(strBckImgPath));}
            else{
                MessageBox.Show("No exist background Image " + Directory.GetCurrentDirectory());}

            // List View Images
            try
            {
                imageList.Images.Add(Bitmap.FromFile(@"../../res/video.bmp"));
                imageList.Images.Add(Bitmap.FromFile(@"../../res/camera.bmp"));

            }catch (Exception) {
                MessageBox.Show("Cannot load icon images for list view");  }

            listView1.View = View.LargeIcon;
            listView1.LargeImageList = imageList;
        }

        private void showImage(Mat cvImg)
        {
            Cv2.Resize(cvImg, matToShow, new OpenCvSharp.Size(pictureBox1.Width, pictureBox1.Height));

            pictureBox1.Image = BitmapConverter.ToBitmap(matToShow);            
        }

        // Load Video
        private void LoadVideo()
        {
            if (cap != null) cap.Dispose();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
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
            if (cap != null) cap.Dispose();
            camFeed.ShowDialog();
            strCapFeed = camFeed.getCamFeed();
            if (strCapFeed.Length == 1)
            {
                int uCamID;
                if (Int32.TryParse(strCapFeed, out uCamID)){
                    cap = VideoCapture.FromCamera(uCamID);}
            }
            else
            {
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
            if (cap != null)
            {
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
        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStop.Enabled = false;
            btnStart.Enabled = true;

            timer.Enabled = false;

        }


        // ***

        // *** CheckBox for Save and Detecting -----------------------------------------------------
        private void chkBoxSave_CheckedChanged(object sender, EventArgs e){
            bSave = chkBoxSave.Checked;
        }


        private void chkBoxDetect_CheckedChanged(object sender, EventArgs e){
            bDetect = chkBoxDetect.Checked;
        }        
        // ***

        private Mat drawtCars(Mat matFrame, Rect[] cars)
        {
            var rnd = new Random();
            var count = 1;
            foreach (var carRect in cars)
            {
                var color = Scalar.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                Cv2.Rectangle(matFrame, carRect, new Scalar(255, 255, 0), 2);
                count++;
            }
            return matFrame;
        }
        

        // *** Timer event
        private void timer_Tick(object sender, EventArgs e)
        {
            // main process
            try                 
            {
                cap.Read(matFrame);
                if (bDetect)
                {                                     
                    showImage(drawtCars(matFrame, detector.proc(matFrame)));
                }
                else { showImage(matFrame); }
                    
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                btnStop.Enabled = false;
                btnStart.Enabled = true;
                if (timer.Enabled == true) timer.Enabled = false;
                if (cap != null) cap.Dispose();
                //MessageBox.Show("Can't read frame!");
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
