using System;
using System.Windows.Forms;
using System.IO;

using OpenCvSharp;
using System.Diagnostics;

namespace CamVehicle
{
    public partial class Form1 : Form
    {
        VideoCapture cap;

        public Form1()
        {
            InitializeComponent();
        }

        private void loadVideoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // create the video capture
                string path = openFileDialog.FileName;
                cap = VideoCapture.FromFile(path);

                // display the input file name
                string inFname = Path.GetFileName(path);
                // lblInput.Text = "Video File: " + inFname;

                int uFps = (int)cap.Get(CaptureProperty.Fps);
                int uFrameWidth = (int)cap.Get(CaptureProperty.FrameWidth);
                int uFrameHeight = (int)cap.Get(CaptureProperty.FrameHeight);
                
            }

        }

        private void loadImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                System.Diagnostics.Debug.WriteLine(path);
                    
                Mat matImg = Cv2.ImRead(path);
                Cv2.ImShow("Image", matImg);
                Cv2.WaitKey(0);
            }
        }
    }
}
