namespace CamVehicle
{
    partial class CameraFeed
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkLiBoxCameras = new System.Windows.Forms.CheckedListBox();
            this.radioWeb = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioIP = new System.Windows.Forms.RadioButton();
            this.txtBoxIPAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCamerFeed = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Camera ID:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkLiBoxCameras);
            this.groupBox1.Controls.Add(this.radioWeb);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(188, 162);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // chkLiBoxCameras
            // 
            this.chkLiBoxCameras.FormattingEnabled = true;
            this.chkLiBoxCameras.Items.AddRange(new object[] {
            "Camera0",
            "Camera1",
            "Camera2",
            "Camera3",
            "Camera4",
            "Camera5",
            "Camera6",
            "Camera7",
            "Camera8",
            "Camera9"});
            this.chkLiBoxCameras.Location = new System.Drawing.Point(85, 26);
            this.chkLiBoxCameras.Name = "chkLiBoxCameras";
            this.chkLiBoxCameras.Size = new System.Drawing.Size(92, 124);
            this.chkLiBoxCameras.TabIndex = 9;
            this.chkLiBoxCameras.SelectedIndexChanged += new System.EventHandler(this.chkLiBoxCameras_SelectedIndexChanged);
            // 
            // radioWeb
            // 
            this.radioWeb.AutoSize = true;
            this.radioWeb.Location = new System.Drawing.Point(0, 0);
            this.radioWeb.Name = "radioWeb";
            this.radioWeb.Size = new System.Drawing.Size(95, 17);
            this.radioWeb.TabIndex = 7;
            this.radioWeb.Text = "Web Cameras:";
            this.radioWeb.UseVisualStyleBackColor = true;
            this.radioWeb.CheckedChanged += new System.EventHandler(this.radioWeb_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioIP);
            this.groupBox2.Controls.Add(this.txtBoxIPAddress);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 177);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(188, 58);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // radioIP
            // 
            this.radioIP.AutoSize = true;
            this.radioIP.Location = new System.Drawing.Point(0, 0);
            this.radioIP.Name = "radioIP";
            this.radioIP.Size = new System.Drawing.Size(82, 17);
            this.radioIP.TabIndex = 8;
            this.radioIP.TabStop = true;
            this.radioIP.Text = "IP Cameras:";
            this.radioIP.UseVisualStyleBackColor = true;
            this.radioIP.CheckedChanged += new System.EventHandler(this.radioIP_CheckedChanged);
            // 
            // txtBoxIPAddress
            // 
            this.txtBoxIPAddress.Location = new System.Drawing.Point(85, 27);
            this.txtBoxIPAddress.Name = "txtBoxIPAddress";
            this.txtBoxIPAddress.Size = new System.Drawing.Size(92, 20);
            this.txtBoxIPAddress.TabIndex = 10;
            this.txtBoxIPAddress.Text = "192.168.1.139";
            this.txtBoxIPAddress.TextChanged += new System.EventHandler(this.txtBoxIPAddress_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "IP Address:";
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(345, 192);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(67, 43);
            this.btnCheck.TabIndex = 0;
            this.btnCheck.Text = "Check Connect";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(418, 192);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(67, 43);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(224, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Selected Camera:";
            // 
            // lblCamerFeed
            // 
            this.lblCamerFeed.AutoSize = true;
            this.lblCamerFeed.Location = new System.Drawing.Point(224, 38);
            this.lblCamerFeed.Name = "lblCamerFeed";
            this.lblCamerFeed.Size = new System.Drawing.Size(0, 13);
            this.lblCamerFeed.TabIndex = 11;
            // 
            // CameraFeed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 242);
            this.Controls.Add(this.lblCamerFeed);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CameraFeed";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CameraFeed";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtBoxIPAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.RadioButton radioWeb;
        private System.Windows.Forms.RadioButton radioIP;
        private System.Windows.Forms.CheckedListBox chkLiBoxCameras;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCamerFeed;
    }
}