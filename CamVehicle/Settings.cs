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
        Color colorRect;
        Size minSize;

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
            minSize = new Size(50, 50);
        }

        private void Settings_Load(object sender, EventArgs e)
        {            
            btnRectColor.BackColor = colorRect;

            txtBoxMinSzW.Text = minSize.Width.ToString();
            txtBoxMinSzH.Text = minSize.Height.ToString();
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

                lblColorR.Text = "R: " + colorRect.R.ToString();
                lblColorG.Text = "G: " + colorRect.G.ToString();
                lblColorB.Text = "B: " + colorRect.B.ToString();

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
        {   return strSavePath;       }

        private void txtBoxMinSzW_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtBoxMinSzW.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only digits.");
                txtBoxMinSzW.Text = txtBoxMinSzW.Text.Remove(txtBoxMinSzW.Text.Length - 1);
            }
            int width = 0;
            if (Int32.TryParse(txtBoxMinSzW.Text, out width))
            {
                minSize.Width = width;
            }
            
        }

        private void txtBoxMinSzH_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtBoxMinSzH.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only digits.");
                txtBoxMinSzH.Text = txtBoxMinSzH.Text.Remove(txtBoxMinSzH.Text.Length - 1);
            }
            int height = 0;
            if (Int32.TryParse(txtBoxMinSzH.Text, out height))
            {
                minSize.Height = height;
            }

        }

        public int get_bDetectMode()
        {
            if (bDetectCascade) return 1; 
            else if (bDetectBlob) return 2;
            else return 0;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {   this.Hide();    }

       

        public Size get_MinSize()
        {
            return minSize;
        }

        public Color get_ColorRect()
        {   return colorRect; }


    }
}
