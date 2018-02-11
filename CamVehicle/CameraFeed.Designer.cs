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
            this.txtBoxUrl = new System.Windows.Forms.TextBox();
            this.cmbBoxModel = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxKnownUrl = new System.Windows.Forms.TextBox();
            this.radioUnknown = new System.Windows.Forms.RadioButton();
            this.radioKnown = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxIPAddress = new System.Windows.Forms.TextBox();
            this.radioIP = new System.Windows.Forms.RadioButton();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.chkBoxConnectCheck = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 28);
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
            this.groupBox1.Size = new System.Drawing.Size(181, 154);
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
            this.chkLiBoxCameras.Location = new System.Drawing.Point(79, 30);
            this.chkLiBoxCameras.Name = "chkLiBoxCameras";
            this.chkLiBoxCameras.Size = new System.Drawing.Size(92, 109);
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
            this.groupBox2.Controls.Add(this.txtBoxUrl);
            this.groupBox2.Controls.Add(this.cmbBoxModel);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtBoxKnownUrl);
            this.groupBox2.Controls.Add(this.radioUnknown);
            this.groupBox2.Controls.Add(this.radioKnown);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtBoxIPAddress);
            this.groupBox2.Location = new System.Drawing.Point(209, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(606, 154);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // txtBoxUrl
            // 
            this.txtBoxUrl.Location = new System.Drawing.Point(78, 119);
            this.txtBoxUrl.Name = "txtBoxUrl";
            this.txtBoxUrl.Size = new System.Drawing.Size(522, 20);
            this.txtBoxUrl.TabIndex = 17;
            this.txtBoxUrl.TextChanged += new System.EventHandler(this.txtBoxUrl_TextChanged);
            // 
            // cmbBoxModel
            // 
            this.cmbBoxModel.FormattingEnabled = true;
            this.cmbBoxModel.Location = new System.Drawing.Point(349, 45);
            this.cmbBoxModel.Name = "cmbBoxModel";
            this.cmbBoxModel.Size = new System.Drawing.Size(86, 21);
            this.cmbBoxModel.TabIndex = 16;
            this.cmbBoxModel.SelectedIndexChanged += new System.EventHandler(this.cmbBoxModel_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(271, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Camera Model:";
            // 
            // txtBoxKnownUrl
            // 
            this.txtBoxKnownUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxKnownUrl.Enabled = false;
            this.txtBoxKnownUrl.Location = new System.Drawing.Point(142, 72);
            this.txtBoxKnownUrl.Name = "txtBoxKnownUrl";
            this.txtBoxKnownUrl.Size = new System.Drawing.Size(458, 20);
            this.txtBoxKnownUrl.TabIndex = 14;
            // 
            // radioUnknown
            // 
            this.radioUnknown.AutoSize = true;
            this.radioUnknown.Location = new System.Drawing.Point(25, 98);
            this.radioUnknown.Name = "radioUnknown";
            this.radioUnknown.Size = new System.Drawing.Size(74, 17);
            this.radioUnknown.TabIndex = 13;
            this.radioUnknown.TabStop = true;
            this.radioUnknown.Text = "Unknown:";
            this.radioUnknown.UseVisualStyleBackColor = true;
            this.radioUnknown.CheckedChanged += new System.EventHandler(this.radioUnknown_CheckedChanged);
            // 
            // radioKnown
            // 
            this.radioKnown.AutoSize = true;
            this.radioKnown.Location = new System.Drawing.Point(25, 28);
            this.radioKnown.Name = "radioKnown";
            this.radioKnown.Size = new System.Drawing.Size(61, 17);
            this.radioKnown.TabIndex = 11;
            this.radioKnown.TabStop = true;
            this.radioKnown.Text = "Known:";
            this.radioKnown.UseVisualStyleBackColor = true;
            this.radioKnown.CheckedChanged += new System.EventHandler(this.radioKnown_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "IP Address:";
            // 
            // txtBoxIPAddress
            // 
            this.txtBoxIPAddress.Location = new System.Drawing.Point(142, 45);
            this.txtBoxIPAddress.Name = "txtBoxIPAddress";
            this.txtBoxIPAddress.Size = new System.Drawing.Size(87, 20);
            this.txtBoxIPAddress.TabIndex = 10;
            this.txtBoxIPAddress.Text = "192.168.1.127";
            this.txtBoxIPAddress.TextChanged += new System.EventHandler(this.txtBoxIPAddress_TextChanged);
            // 
            // radioIP
            // 
            this.radioIP.AutoSize = true;
            this.radioIP.Location = new System.Drawing.Point(210, 11);
            this.radioIP.Name = "radioIP";
            this.radioIP.Size = new System.Drawing.Size(82, 17);
            this.radioIP.TabIndex = 8;
            this.radioIP.TabStop = true;
            this.radioIP.Text = "IP Cameras:";
            this.radioIP.UseVisualStyleBackColor = true;
            this.radioIP.CheckedChanged += new System.EventHandler(this.radioIP_CheckedChanged);
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(210, 201);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(67, 43);
            this.btnCheck.TabIndex = 0;
            this.btnCheck.Text = "Check Connect";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(210, 264);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(67, 43);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // chkBoxConnectCheck
            // 
            this.chkBoxConnectCheck.AutoSize = true;
            this.chkBoxConnectCheck.Location = new System.Drawing.Point(298, 215);
            this.chkBoxConnectCheck.Name = "chkBoxConnectCheck";
            this.chkBoxConnectCheck.Size = new System.Drawing.Size(35, 17);
            this.chkBoxConnectCheck.TabIndex = 12;
            this.chkBoxConnectCheck.Text = "...";
            this.chkBoxConnectCheck.UseVisualStyleBackColor = true;
            // 
            // CameraFeed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 327);
            this.Controls.Add(this.chkBoxConnectCheck);
            this.Controls.Add(this.radioIP);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CameraFeed";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CameraFeed";
            this.Load += new System.EventHandler(this.CameraFeed_Load);
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
        private System.Windows.Forms.TextBox txtBoxUrl;
        private System.Windows.Forms.ComboBox cmbBoxModel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxKnownUrl;
        private System.Windows.Forms.RadioButton radioUnknown;
        private System.Windows.Forms.RadioButton radioKnown;
        private System.Windows.Forms.CheckBox chkBoxConnectCheck;
    }
}