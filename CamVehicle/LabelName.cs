using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CamVehicle
{
    public partial class LabelName : Form
        ///<summary>
        /// Form for adding the label to the ROI object
        ///</summary>
    {
        string strLabel;
        public LabelName(string initStr)
        {
            InitializeComponent();

            strLabel = initStr;
            txtBoxLabel.Text = strLabel;            
        }

        private void txtBoxLabel_TextChanged(object sender, EventArgs e)
            /// <summary>
            /// edit the label text with textbox control
            /// </summary>
        {
            strLabel = txtBoxLabel.Text;
        }

        public string getLabel()
            /// <summary>
            /// return the edited label string
            /// </summary>
        {
            return strLabel;
        }

        private void txtBoxLabel_KeyDown(object sender, KeyEventArgs e)
            /// <summary>
            /// save and the text of textbox to the label of ROI object 
            /// </summary>
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Hide();
            }
        }
    }
}
