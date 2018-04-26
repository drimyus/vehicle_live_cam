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
    public partial class Start : Form
    /// <summary>
    /// start Form for log in <user name and password>
    /// </summary>
    {
        string strName, strPassword, savedName, savedPassword;
        public Start()
        {
            savedName = "longwind";
            savedPassword = "BS1786";

            InitializeComponent();

            strName = "";
            strPassword = "";
            //strName = "longwind";
            //strPassword = "BS1786";
            //txtBoxName.Text = strName;
            //txtBoxPassword.Text = strPassword;
        }

        private void txtBoxName_TextChanged(object sender, EventArgs e)
            /// <summary> input the user name </summary>
        {
            strName = txtBoxName.Text;
        }

        private void checkString()
        /// <summary> identify the username and password </summary>
        {
            if ((strPassword == savedPassword) && (strName == savedName))
            {
                this.Hide();
            }
            else
            {
                MessageBox.Show("In correct Password and Username.");
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        /// <summary> button OK </summary>
        {
            checkString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Start_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void Start_KeyDown(object sender, KeyEventArgs e)
            /// <summary> enter keypress == button OK </summary>
        {
            if (e.KeyCode == Keys.Enter)
            {
                checkString();
            }
        }

        private void txtBoxPassword_TextChanged(object sender, EventArgs e)
        /// <summary> type the password </summary>
        {
            strPassword = txtBoxPassword.Text;
        }
    }
}
