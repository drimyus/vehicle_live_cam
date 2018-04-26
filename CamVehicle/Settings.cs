using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CamVehicle
{
    public partial class Settings : Form
        ///<summary>
        /// Form for setting the main parameters
        ///</summary>
    {
        bool bSave, bExport, bDetectBlob, bDetectCascade, bShowRect, bShowROIs;

        string strSavePath, strHost, strPort;
        Color colorRect, colorROI;        
        Size minSize;
        Size szBick, szCar, szTruck, szCrowd;

        int iRctFntSz, iROIFntSz;

        double dThreshSameRct;

        public Settings()
        {
            InitializeComponent();

            bDetectCascade = false;
            chkBoxCascade.Checked = false;

            bExport = false;
            chkBoxExport.Checked = true;
            strHost = txtBoxHost.Text = "127.0.0.1";
            strPort = txtBoxPort.Text = "5000";

            chkBoxBlob.Checked = true;
            bDetectBlob = true;

            bSave = false;
            chkBoxSave.Checked = false;
            strSavePath = txtBoxSavePath.Text;

            colorRect = Color.FromArgb(255, 0, 255, 255);
            lblRectColorR.Text = "R: " + colorRect.R.ToString();
            lblRectColorG.Text = "G: " + colorRect.G.ToString();
            lblRectColorB.Text = "B: " + colorRect.B.ToString();

            colorROI = Color.FromArgb(255, 0, 0, 255);
            lblROIColorR.Text = "R: " + colorROI.R.ToString();
            lblROIColorG.Text = "G: " + colorROI.G.ToString();
            lblROIColorB.Text = "B: " + colorROI.B.ToString();

            minSize = new Size(20, 20);
            szBick = new Size(40, 40);
            szCar = new Size(150, 150);
            szTruck = new Size(200, 200);

            iRctFntSz = 1;
            iROIFntSz = 2;

            bShowRect = true;
            chkBoxShowRect.Checked = bShowRect;
            bShowROIs = true;
            chkBoxShowROI.Checked = bShowROIs;

            dThreshSameRct = 0.3;
            txtBoxSameRect.Text = dThreshSameRct.ToString();

        }

        private void Settings_Load(object sender, EventArgs e)
            /// Open the Setting Form
        {            
            btnRectColor.BackColor = colorRect;
            btnROIColor.BackColor = colorROI;

            txtBoxMinSzW.Text = minSize.Width.ToString();
            txtBoxMinSzH.Text = minSize.Height.ToString();

            txtBoxClass1_w.Text = szBick.Width.ToString();
            txtBoxClass1_h.Text = szBick.Height.ToString();

            txtBoxClass2_w.Text = szCar.Width.ToString();
            txtBoxClass2_h.Text = szCar.Height.ToString();

            txtBoxClass3_w.Text = szTruck.Width.ToString();
            txtBoxClass3_h.Text = szTruck.Height.ToString();

            txtBoxRectFntSZ.Text = iRctFntSz.ToString();
            txtBoxROIFntSZ.Text = iROIFntSz.ToString();

        }

        private void updateClassSizes()
            ///<summary>
            /// update the class member variable list of size with TextBox String
            ///</summary>
        {
            int hw = 0;
            if (Int32.TryParse(txtBoxMinSzW.Text, out hw) && Int32.TryParse(txtBoxMinSzH.Text, out hw))
                minSize = new Size(Int32.Parse(txtBoxMinSzW.Text), Int32.Parse(txtBoxMinSzH.Text));

            if (Int32.TryParse(txtBoxClass1_w.Text, out hw) && Int32.TryParse(txtBoxClass1_h.Text, out hw))
                szBick = new Size(Int32.Parse(txtBoxClass1_w.Text), Int32.Parse(txtBoxClass1_h.Text));

            if (Int32.TryParse(txtBoxClass2_w.Text, out hw) && Int32.TryParse(txtBoxClass2_h.Text, out hw))
                szCar = new Size(Int32.Parse(txtBoxClass2_w.Text), Int32.Parse(txtBoxClass2_h.Text));

            if (Int32.TryParse(txtBoxClass3_w.Text, out hw) && Int32.TryParse(txtBoxClass3_h.Text, out hw))
                szTruck = new Size(Int32.Parse(txtBoxClass3_w.Text), Int32.Parse(txtBoxClass3_h.Text));

        }

        private void chkBoxSave_CheckedChanged(object sender, EventArgs e)
            ///<summary> checkBox for saving the result video <summary>
        {
            bSave = chkBoxSave.Checked;
        }

        private void chkBoxExport_CheckedChanged(object sender, EventArgs e)
            ///<summary> checkBox for saving the result log csv <summary>
        {
            bExport = chkBoxExport.Checked;
        }

        private void btnOpenSaveDlg_Click(object sender, EventArgs e)
            ///<summary> checkBox for saving the result log csv <summary>
        {
            if (bSave)
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // create the video capture
                    strSavePath = saveFileDialog.FileName;

                    // display the save file name
                    string inFname = Path.GetFileName(strSavePath);

                    txtBoxSavePath.Text = strSavePath;
                }
            }
        }

        private void btnRectColor_Click(object sender, EventArgs e)
            ///<summary>
            /// button for selecting color of Rect
            ///</summary>
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                //CvColor color = new CvColor();
                colorRect = colorDialog.Color;

                btnRectColor.BackColor = colorRect;

                lblRectColorR.Text = "R: " + colorRect.R.ToString();
                lblRectColorG.Text = "G: " + colorRect.G.ToString();
                lblRectColorB.Text = "B: " + colorRect.B.ToString();

            }
        }
        private void btnROIColor_Click(object sender, EventArgs e)
            ///<summary>
            /// button for selecting color of ROI
            ///</summary>
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                //CvColor color = new CvColor();
                colorROI = colorDialog.Color;

                btnROIColor.BackColor = colorROI;

                lblROIColorR.Text = "R: " + colorROI.R.ToString();
                lblROIColorG.Text = "G: " + colorROI.G.ToString();
                lblROIColorB.Text = "B: " + colorROI.B.ToString();

            }
        }


        private void chkBoxCascade_CheckedChanged(object sender, EventArgs e)
            ///<summary> checkbox for selecting the cascade detecting mode </summary>
        {
            bDetectCascade = chkBoxCascade.Checked;
            if (bDetectCascade && bDetectBlob)
            {
                bDetectBlob = !bDetectCascade;
                chkBoxBlob.Checked = bDetectBlob;
            }
        }

        private void chkBoxBlob_CheckedChanged(object sender, EventArgs e)
            ///<summary> checkbox for selecting the Blob detecting mode </summary>
        {
            bDetectBlob = chkBoxBlob.Checked;
            if (bDetectCascade && bDetectBlob)
            {
                bDetectCascade = !bDetectBlob;
                chkBoxCascade.Checked = bDetectCascade;
            }
        }

        public bool getSaveChecked(){   return bSave;        }

        public string getSavePath(){   return strSavePath;  }

        private void txtBoxMinSzW_TextChanged(object sender, EventArgs e)
            /// <summary> 
            /// textbox for setting the size threshold 
            /// </summary>
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtBoxMinSzW.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only digits.");
                txtBoxMinSzW.Text = txtBoxMinSzW.Text.Remove(txtBoxMinSzW.Text.Length - 1);
            }            
            updateClassSizes();

        }
        public bool getShowRectChecked()
            /// <summary> return the show rect property </summary>
        { return bShowRect;  }

        public bool getShowROIChecked()
            /// <summary> return the show ROI property </summary>
        { return bShowROIs; }

        private void txtBoxMinSzH_TextChanged(object sender, EventArgs e)
            /// <summary> set the minimum size property </summary>
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtBoxMinSzH.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only digits.");
                txtBoxMinSzH.Text = txtBoxMinSzH.Text.Remove(txtBoxMinSzH.Text.Length - 1);
            }
            updateClassSizes();
        }

        private void txtBoxClass1_w_TextChanged(object sender, EventArgs e)
            /// <summary> set width of the size property of bicycle </summary>
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtBoxClass1_w.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only digits.");
                txtBoxClass1_w.Text = txtBoxClass1_w.Text.Remove(txtBoxClass1_w.Text.Length - 1);
            }
            updateClassSizes();
        }

        private void txtBoxClass1_h_TextChanged(object sender, EventArgs e)
            /// <summary> set height of the size property of bicycle </summary>
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtBoxClass1_h.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only digits.");
                txtBoxClass1_h.Text = txtBoxClass1_h.Text.Remove(txtBoxClass1_h.Text.Length - 1);
            }
            updateClassSizes();
        }

        private void txtBoxPort_TextChanged(object sender, EventArgs e)
            /// <summary> set port for export the log string </summary>
        {
            if (bExport)
                strPort = txtBoxPort.Text;
        }

        private void txtBoxClass2_w_TextChanged(object sender, EventArgs e)
            /// <summary> set width of the size property of car </summary>
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtBoxClass2_w.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only digits.");
                txtBoxClass2_w.Text = txtBoxClass2_w.Text.Remove(txtBoxClass2_w.Text.Length - 1);
            }
            updateClassSizes();
        }

        private void txtBoxClass2_h_TextChanged(object sender, EventArgs e)
            /// <summary> set height of the size property of car </summary>
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtBoxClass2_h.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only digits.");
                txtBoxClass2_h.Text = txtBoxClass2_h.Text.Remove(txtBoxClass2_h.Text.Length - 1);
            }
            updateClassSizes();
        }

        private void txtBoxRectFntSZ_TextChanged(object sender, EventArgs e)
            /// <summary> set font size for labeling the rects </summary>
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtBoxRectFntSZ.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only digits.");
                txtBoxRectFntSZ.Text = txtBoxRectFntSZ.Text.Remove(txtBoxRectFntSZ.Text.Length - 1);
            }

            int hw = 0;
            if (Int32.TryParse(txtBoxRectFntSZ.Text, out hw))
                iRctFntSz = Int32.Parse(txtBoxRectFntSZ.Text);
        }

        private void txtBoxROIFntSZ_TextChanged(object sender, EventArgs e)
            /// <summary> set font size for labeling the ROI objs </summary>
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtBoxROIFntSZ.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only digits.");
                txtBoxROIFntSZ.Text = txtBoxROIFntSZ.Text.Remove(txtBoxROIFntSZ.Text.Length - 1);
            }
            int hw = 0;
            if (Int32.TryParse(txtBoxROIFntSZ.Text, out hw))
                iROIFntSz = Int32.Parse(txtBoxROIFntSZ.Text);
        }

        private void txtBoxHost_TextChanged(object sender, EventArgs e)
            /// <summary> set Host for exporting the log string </summary>
        {
            if (bExport){
                strHost = txtBoxHost.Text;
            }
        }

        private void chkBoxShowROI_CheckedChanged(object sender, EventArgs e)
            /// <summary> set the showing ROI property </summary>
        {
            bShowROIs = chkBoxShowROI.Checked;
        }

        private void txtBoxSameRect_TextChanged(object sender, EventArgs e)
            /// <summary> set the threshold value for identify the same rect or not </summary>
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtBoxSameRect.Text, "[^0-9.]"))
            {
                MessageBox.Show("Please enter only digits.");
                txtBoxSameRect.Text = txtBoxSameRect.Text.Remove(txtBoxSameRect.Text.Length - 1);
            }

            double dw;
            if (Double.TryParse(txtBoxSameRect.Text, out dw)){
                dThreshSameRct = Double.Parse(txtBoxSameRect.Text);
            }
        }

        
        private void chkBoxShowRect_CheckedChanged(object sender, EventArgs e)
            /// <summary> set the showing Rect property </summary>
        {
            bShowRect = chkBoxShowRect.Checked;
        }

        private void txtBoxClass3_w_TextChanged(object sender, EventArgs e)
            /// <summary> set width of the size property of truck </summary>
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtBoxClass3_w.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only digits.");
                txtBoxClass3_w.Text = txtBoxClass3_w.Text.Remove(txtBoxClass3_w.Text.Length - 1);
            }
            updateClassSizes();
        }

     

        private void txtBoxClass3_h_TextChanged(object sender, EventArgs e)
            /// <summary> set height of the size property of truck </summary>
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtBoxClass3_h.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only digits.");
                txtBoxClass3_h.Text = txtBoxClass3_h.Text.Remove(txtBoxClass3_h.Text.Length - 1);
            }
            updateClassSizes();
        }

       
        public int getDetectMode()
        /// <summary> return the detect mode </summary>
        {
            if (bDetectCascade) return 1; 
            else if (bDetectBlob) return 2;
            else return 0;
        }

        private void btnOK_Click(object sender, EventArgs e)
            /// <summary> save button </summary>
        { this.Hide();    }
        

        public List<Color> getColors()
            /// <summary> select color </summary>
        { 
            return new List<Color> { colorRect, colorROI };
        }
        
        public string getHost()
        /// <summary> return host property </summary>
        { return strHost; }

        public int getPort()
        /// <summary> return port property </summary>
        { return Int32.Parse(strPort); }

        public List<Size> getSizes()
        /// <summary> return size properties as a list </summary>
        {
            List<Size> liSzThreshs = new List<Size>() { minSize, szBick, szCar, szTruck };
            return liSzThreshs;
        }
        public int getRctFntSz()
        /// <summary> return rect font size property </summary>
        { return iRctFntSz; }

        public int getROIFntSz()
        /// <summary> return ROI font size property </summary>
        { return iROIFntSz; }

        public double getThreshSameRect()
        /// <summary> return threshold property for identifing the same rect</summary>
        { return dThreshSameRct; }
    }
}
