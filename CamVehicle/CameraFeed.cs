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

        string[] liIPcamModels = {@"DAHUA", @"VIMICRO"};

        public CameraFeed()
        {
            InitializeComponent();

            strCamFeed = "";
            uSelectedCam = -1;

            
            

            // WebCamera comboBox setting
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

            //... WebCamera comboBox setting
            for( int i = 0; i < liIPcamModels.Length; i++)
            {
                cmbBoxModel.Items.Insert(i, liIPcamModels[i]);
            }
        }

        private void set_WebcamGroup_Prop(bool bflag)
        {
            radioWeb.Checked = bflag;
            chkLiBoxCameras.Enabled = bflag;
        }

        private void set_IPcamGroup_Prop(bool bflag)
        {
            radioIP.Checked = bflag;

            radioUnknown.Enabled = bflag;
            radioUnknown.Checked = false;         
            set_UnknowncamGroup_Prop(false);

            radioKnown.Enabled = bflag;
            radioKnown.Checked = false;
            set_KnowncamGroup_Prop(false);


        }
        private void set_KnowncamGroup_Prop(bool bflag)
        {
            txtBoxIPAddress.Enabled = bflag;
            cmbBoxModel.Enabled = bflag;
        }
        private void set_UnknowncamGroup_Prop(bool bflag)
        {
            txtBoxUrl.Enabled = bflag;
        }
        

        private void CameraFeed_Load(object sender, EventArgs e)
        {
            set_WebcamGroup_Prop(true);
            set_IPcamGroup_Prop(false);
        }




        private void radioWeb_CheckedChanged(object sender, EventArgs e)
        {
            set_WebcamGroup_Prop(radioWeb.Checked);
            set_IPcamGroup_Prop(!radioWeb.Checked);
        }
        private void radioIP_CheckedChanged(object sender, EventArgs e)
        {
            set_WebcamGroup_Prop(!radioIP.Checked);
            set_IPcamGroup_Prop(radioIP.Checked);
        }
        private void radioKnown_CheckedChanged(object sender, EventArgs e)
        {
            set_KnowncamGroup_Prop(radioKnown.Checked);
            set_UnknowncamGroup_Prop(!radioKnown.Checked);
        }

        private void radioUnknown_CheckedChanged(object sender, EventArgs e)
        {
            set_KnowncamGroup_Prop(!radioUnknown.Checked);
            set_UnknowncamGroup_Prop(radioUnknown.Checked);
        }

        



        private string get_IPcamUrl()
        {
            string strUrl;
            if (radioKnown.Checked)            
                if (cmbBoxModel.SelectedIndex == 0)  // DAHUA
                {
                    var strProtocal = "rtsp://";
                    var strUserName = "admin" + ":";
                    var strPassword = "admin" + "@";
                    var strIP = txtBoxIPAddress.Text + ":";
                    var strPort = 554.ToString() + "/cam/realmonitor?";
                    var strChannel = "channel=" + "1" + "&";
                    var strSubType = "subtype=" + "0";

                    // rtsp://admin:admin@00.00.00.00:554/cam/realmonitor?channel=1&subtype=0
                    strUrl = strProtocal + strUserName + strPassword + strIP + strPort + strChannel + strSubType;
                
                }
                else // if (cmbBoxModel.SelectedIndex == 0)  // VIMICRO
                {
                    var strProtocal = "rtsp://";
                    var strIP = txtBoxIPAddress.Text + "/";
                    var strType = "type=" + 0.ToString() + "&";
                    var strId = "id=" + 1.ToString() + "&";
                    var strUser = "user=" + "admin" + "&";
                    var strPassword = "password=" + "123456";

                    // rtsp://197.0.187.15/type=0&id=1&user=admin&password=123456                
                    strUrl = strProtocal + strIP + strType + strId + strUser + strPassword;                
                }
            else  // if (radioUnknown.checked)
            {
                strUrl = txtBoxUrl.Text;
            }
            return strUrl;
            
        }



        private void txtBoxIPAddress_TextChanged(object sender, EventArgs e)
        {
            strCamFeed = get_IPcamUrl();
            txtBoxKnownUrl.Text = strCamFeed;
        }
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (strCamFeed != "")
            {                
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

        private void cmbBoxModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            strCamFeed = get_IPcamUrl();
            txtBoxKnownUrl.Text = strCamFeed;
        }













        public new void Dispose()
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
                    if (uFrameWidth == 0)
                    {
                        MessageBox.Show("ERROR! Web Camera: " + strCamFeed);
                        strCamFeed = uSelectedCam.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Success! Web Camera: " + uSelectedCam.ToString());
                        strCamFeed = uSelectedCam.ToString();
                    }
                    
                }
                catch (Exception ex){
                    MessageBox.Show("ERROR! Web Camera: " + uSelectedCam.ToString());
                    strCamFeed = "";
                }                

            }                
            if (radioIP.Checked)
            {
                try
                {
                    strCamFeed = get_IPcamUrl();

                    VideoCapture cap;
                    cap = VideoCapture.FromFile(strCamFeed);                    
                    int uFrameWidth = (int)cap.Get(CaptureProperty.FrameWidth);
                    cap.Dispose();

                    if (uFrameWidth == 0)
                    {
                        MessageBox.Show("Error! IP Camera:" + strCamFeed);
                        strCamFeed = "";
                    }
                    else
                    {
                        MessageBox.Show("Success! IP Camera: " + strCamFeed);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR! IP Camera: " + strCamFeed);
                    strCamFeed = "";
                }                
            }

            if (strCamFeed == "")
            {
                chkBoxConnectCheck.Checked = false;
                chkBoxConnectCheck.Text = "Error !";
            }
            else
            {
                chkBoxConnectCheck.Checked = true;
                chkBoxConnectCheck.Text = "Success !";
            }


        }

        private void txtBoxUrl_TextChanged(object sender, EventArgs e)
        {
            strCamFeed = txtBoxUrl.Text;
        }
                
    }
}
