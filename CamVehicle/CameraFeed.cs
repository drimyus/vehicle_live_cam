using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenCvSharp;
using System.Diagnostics;

namespace CamVehicle
{
    public partial class CameraFeed : Form, IDisposable
    {
        int uLength;
        List<int> liEnabledCams = new List<int>();
        int uSelectedCam;
        string strCamFeed;

        string strProtocal, strUserName, strPassword, strIP, strPort, strUrlTail, strChannel, strSubType;

        

        public CameraFeed()
        {
            InitializeComponent();

            strCamFeed = "";
            uSelectedCam = -1;

            strProtocal = "rtsp";
            strUserName = "admin";
            strPassword = "admin";
            strIP = "192.168.1.155";
            strPort = "554";            
            strChannel = "1";
            strSubType = "0";


            radioWeb.Checked = true;
            radioIP.Checked = false;

            uLength = chkLiBoxCameras.Items.Count;
            for (int i = 0; i < uLength; i++)
            {
                VideoCapture cap;
                try
                {
                    cap = VideoCapture.FromCamera(i);
                    int uFrameWidth = (int)cap.Get(CaptureProperty.FrameWidth);
                    liEnabledCams.Add(i);

                    cap.Dispose();
                }
                catch (Exception e) { }
            }

            for (int i = 0; i < uLength; i++)
            {
                chkLiBoxCameras.SetItemCheckState(i, CheckState.Checked);
                if (!liEnabledCams.Contains(i))
                {
                    chkLiBoxCameras.SetItemCheckState(i, CheckState.Indeterminate);
                }
                else
                {
                    if (i == uSelectedCam)
                    {
                        chkLiBoxCameras.SetItemCheckState(i, CheckState.Checked);
                    }
                    else
                    {
                        chkLiBoxCameras.SetItemCheckState(i, CheckState.Unchecked);
                    }
                }
            }


        }

        private void txtBoxIPAddress_TextChanged(object sender, EventArgs e)
        {
            strIP = txtBoxIPAddress.Text;
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            if (strCamFeed != "")
            {
                uSelectedCam = chkLiBoxCameras.SelectedIndex;
                this.Hide();
            }
            else
            {
                MessageBox.Show("No connected Camera!");
            }
        }

        public string getCamFeed()
        {
            return strCamFeed;
        }

        private void chkLiBoxCameras_SelectedIndexChanged(object sender, EventArgs e)
        {               
            int idx = chkLiBoxCameras.SelectedIndex;
            if (liEnabledCams.Contains(idx))
            {
                if (uSelectedCam != -1)
                    chkLiBoxCameras.SetItemCheckState(uSelectedCam, CheckState.Unchecked);
                uSelectedCam = chkLiBoxCameras.SelectedIndex;
                chkLiBoxCameras.SetItemCheckState(uSelectedCam, CheckState.Checked);
            }                        
        }

        private void radioWeb_CheckedChanged(object sender, EventArgs e)
        {
            if (radioWeb.Checked){
                radioIP.Checked = false;}
        }
        private void radioIP_CheckedChanged(object sender, EventArgs e)
        {
            if (radioIP.Checked) {
                radioWeb.Checked = false;}
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (radioWeb.Checked)
            {                
                try
                {
                    VideoCapture cap;
                    cap = VideoCapture.FromCamera(uSelectedCam);
                    int uFrameWidth = (int)cap.Get(CaptureProperty.FrameWidth);
                    cap.Dispose();

                    lblCamerFeed.Text = "Success! Web Camera ID: " + uSelectedCam.ToString();
                    strCamFeed = uSelectedCam.ToString();
                }
                catch (Exception ex){
                    MessageBox.Show("Cannot Connect WebCamera " + strCamFeed + "!");
                    strCamFeed = "";
                }                

            }                
            if (radioIP.Checked)
            {
                try
                {
                    strIP = txtBoxIPAddress.Text;
                    strCamFeed = strProtocal + "://" + strUserName + ":" + strPassword + "@" + strIP + ":" + strPort + "/cam/realmonitor?" + "channel=" + strChannel + "&" + "subtype=" + strSubType;

                    VideoCapture cap;
                    cap = VideoCapture.FromFile(strCamFeed);
                    cap = VideoCapture.FromCamera(uSelectedCam);
                    int uFrameWidth = (int)cap.Get(CaptureProperty.FrameWidth);
                    cap.Dispose();

                    lblCamerFeed.Text = "Success! IP Camera Address: " + strIP;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cannot Connect WebCamera " + strIP + "!");
                    strCamFeed = "";
                }                
            }


        }


    }
}
