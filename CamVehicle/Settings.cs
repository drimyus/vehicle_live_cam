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
    {
        bool bSave, bDetectBlob, bDetectCascade;

        string strSavePath;
        Color colorRect, colorROI;        
        Size minSize;
        Size szBick, szCar, szTruck, szCrowd;

       

        public Settings()
        {
            InitializeComponent();

            bSave = false;
            bDetectCascade = false;
            bDetectBlob = false;

            chkBoxCascade.Checked = false;
            chkBoxBlob.Checked = false;
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
   
        }

        private void Settings_Load(object sender, EventArgs e)
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

        }

        private void updateClassSizes()
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
        {            bSave = chkBoxSave.Checked;                    }

        private void btnOpenSaveDlg_Click(object sender, EventArgs e)
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
        {
            bDetectCascade = chkBoxCascade.Checked;
            if (bDetectCascade && bDetectBlob)
            {
                bDetectBlob = !bDetectCascade;
                chkBoxBlob.Checked = bDetectBlob;
            }
        }

        private void chkBoxBlob_CheckedChanged(object sender, EventArgs e)
        {
            bDetectBlob = chkBoxBlob.Checked;
            if (bDetectCascade && bDetectBlob)
            {
                bDetectCascade = !bDetectBlob;
                chkBoxCascade.Checked = bDetectCascade;
            }
        }

        public bool get_bSaveChecked()
        {   return bSave;        }

        public string get_strSavePath()
        {   return strSavePath;  }

        private void txtBoxMinSzW_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtBoxMinSzW.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only digits.");
                txtBoxMinSzW.Text = txtBoxMinSzW.Text.Remove(txtBoxMinSzW.Text.Length - 1);
            }            
            updateClassSizes();

        }
        private void txtBoxMinSzH_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtBoxMinSzH.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only digits.");
                txtBoxMinSzH.Text = txtBoxMinSzH.Text.Remove(txtBoxMinSzH.Text.Length - 1);
            }
            updateClassSizes();
        }

        private void txtBoxClass1_w_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtBoxClass1_w.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only digits.");
                txtBoxClass1_w.Text = txtBoxClass1_w.Text.Remove(txtBoxClass1_w.Text.Length - 1);
            }
            updateClassSizes();
        }

        private void txtBoxClass1_h_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtBoxClass1_h.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only digits.");
                txtBoxClass1_h.Text = txtBoxClass1_h.Text.Remove(txtBoxClass1_h.Text.Length - 1);
            }
            updateClassSizes();
        }

        private void txtBoxClass2_w_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtBoxClass2_w.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only digits.");
                txtBoxClass2_w.Text = txtBoxClass2_w.Text.Remove(txtBoxClass2_w.Text.Length - 1);
            }
            updateClassSizes();
        }

        private void txtBoxClass2_h_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtBoxClass2_h.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only digits.");
                txtBoxClass2_h.Text = txtBoxClass2_h.Text.Remove(txtBoxClass2_h.Text.Length - 1);
            }
            updateClassSizes();
        }

        private void txtBoxClass3_w_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtBoxClass3_w.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only digits.");
                txtBoxClass3_w.Text = txtBoxClass3_w.Text.Remove(txtBoxClass3_w.Text.Length - 1);
            }
            updateClassSizes();
        }

     

        private void txtBoxClass3_h_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtBoxClass3_h.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only digits.");
                txtBoxClass3_h.Text = txtBoxClass3_h.Text.Remove(txtBoxClass3_h.Text.Length - 1);
            }
            updateClassSizes();
        }

       
        public int get_bDetectMode()
        {
            if (bDetectCascade) return 1; 
            else if (bDetectBlob) return 2;
            else return 0;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {   this.Hide();    }
        

        public List<Color> get_Colors()
        { 
            return new List<Color> { colorRect, colorROI };
        }
        

        public List<Size> get_Sizes()
        {
            List<Size> liSzThreshs = new List<Size>() { minSize, szBick, szCar, szTruck };
            return liSzThreshs;
        }
    }
}
