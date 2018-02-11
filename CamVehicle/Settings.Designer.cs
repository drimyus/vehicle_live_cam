namespace CamVehicle
{
    partial class Settings
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
            this.groupBoxSave = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxSavePath = new System.Windows.Forms.TextBox();
            this.btnOpenSaveDlg = new System.Windows.Forms.Button();
            this.chkBoxSave = new System.Windows.Forms.CheckBox();
            this.groupBoxDetector = new System.Windows.Forms.GroupBox();
            this.lblColorB = new System.Windows.Forms.Label();
            this.lblColorG = new System.Windows.Forms.Label();
            this.lblColorR = new System.Windows.Forms.Label();
            this.btnRectColor = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxMinSzW = new System.Windows.Forms.TextBox();
            this.txtBoxMinSzH = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkBoxBlob = new System.Windows.Forms.CheckBox();
            this.chkBoxCascade = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBoxSave.SuspendLayout();
            this.groupBoxDetector.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSave
            // 
            this.groupBoxSave.Controls.Add(this.label1);
            this.groupBoxSave.Controls.Add(this.txtBoxSavePath);
            this.groupBoxSave.Controls.Add(this.btnOpenSaveDlg);
            this.groupBoxSave.Controls.Add(this.chkBoxSave);
            this.groupBoxSave.Location = new System.Drawing.Point(12, 12);
            this.groupBoxSave.Name = "groupBoxSave";
            this.groupBoxSave.Size = new System.Drawing.Size(677, 117);
            this.groupBoxSave.TabIndex = 0;
            this.groupBoxSave.TabStop = false;
            this.groupBoxSave.Text = "Save";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Path:";
            // 
            // txtBoxSavePath
            // 
            this.txtBoxSavePath.Location = new System.Drawing.Point(93, 69);
            this.txtBoxSavePath.Name = "txtBoxSavePath";
            this.txtBoxSavePath.Size = new System.Drawing.Size(512, 20);
            this.txtBoxSavePath.TabIndex = 2;
            // 
            // btnOpenSaveDlg
            // 
            this.btnOpenSaveDlg.Location = new System.Drawing.Point(611, 66);
            this.btnOpenSaveDlg.Name = "btnOpenSaveDlg";
            this.btnOpenSaveDlg.Size = new System.Drawing.Size(23, 23);
            this.btnOpenSaveDlg.TabIndex = 1;
            this.btnOpenSaveDlg.Text = "...";
            this.btnOpenSaveDlg.UseVisualStyleBackColor = true;
            this.btnOpenSaveDlg.Click += new System.EventHandler(this.btnOpenSaveDlg_Click);
            // 
            // chkBoxSave
            // 
            this.chkBoxSave.AutoSize = true;
            this.chkBoxSave.Location = new System.Drawing.Point(28, 30);
            this.chkBoxSave.Name = "chkBoxSave";
            this.chkBoxSave.Size = new System.Drawing.Size(51, 17);
            this.chkBoxSave.TabIndex = 0;
            this.chkBoxSave.Text = "Save";
            this.chkBoxSave.UseVisualStyleBackColor = true;
            this.chkBoxSave.CheckedChanged += new System.EventHandler(this.chkBoxSave_CheckedChanged);
            // 
            // groupBoxDetector
            // 
            this.groupBoxDetector.Controls.Add(this.lblColorB);
            this.groupBoxDetector.Controls.Add(this.lblColorG);
            this.groupBoxDetector.Controls.Add(this.lblColorR);
            this.groupBoxDetector.Controls.Add(this.btnRectColor);
            this.groupBoxDetector.Controls.Add(this.label3);
            this.groupBoxDetector.Controls.Add(this.txtBoxMinSzW);
            this.groupBoxDetector.Controls.Add(this.txtBoxMinSzH);
            this.groupBoxDetector.Controls.Add(this.label2);
            this.groupBoxDetector.Controls.Add(this.chkBoxBlob);
            this.groupBoxDetector.Controls.Add(this.chkBoxCascade);
            this.groupBoxDetector.Location = new System.Drawing.Point(12, 135);
            this.groupBoxDetector.Name = "groupBoxDetector";
            this.groupBoxDetector.Size = new System.Drawing.Size(677, 121);
            this.groupBoxDetector.TabIndex = 1;
            this.groupBoxDetector.TabStop = false;
            this.groupBoxDetector.Text = "Detector";
            // 
            // lblColorB
            // 
            this.lblColorB.AutoSize = true;
            this.lblColorB.Location = new System.Drawing.Point(580, 85);
            this.lblColorB.Name = "lblColorB";
            this.lblColorB.Size = new System.Drawing.Size(20, 13);
            this.lblColorB.TabIndex = 10;
            this.lblColorB.Text = "B: ";
            // 
            // lblColorG
            // 
            this.lblColorG.AutoSize = true;
            this.lblColorG.Location = new System.Drawing.Point(580, 62);
            this.lblColorG.Name = "lblColorG";
            this.lblColorG.Size = new System.Drawing.Size(21, 13);
            this.lblColorG.TabIndex = 9;
            this.lblColorG.Text = "G: ";
            // 
            // lblColorR
            // 
            this.lblColorR.AutoSize = true;
            this.lblColorR.Location = new System.Drawing.Point(580, 39);
            this.lblColorR.Name = "lblColorR";
            this.lblColorR.Size = new System.Drawing.Size(21, 13);
            this.lblColorR.TabIndex = 8;
            this.lblColorR.Text = "R: ";
            // 
            // btnRectColor
            // 
            this.btnRectColor.Location = new System.Drawing.Point(498, 36);
            this.btnRectColor.Name = "btnRectColor";
            this.btnRectColor.Size = new System.Drawing.Size(57, 43);
            this.btnRectColor.TabIndex = 7;
            this.btnRectColor.Text = "Color";
            this.btnRectColor.UseVisualStyleBackColor = true;
            this.btnRectColor.Click += new System.EventHandler(this.btnRectColor_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(336, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "x";
            // 
            // txtBoxMinSzW
            // 
            this.txtBoxMinSzW.Location = new System.Drawing.Point(296, 39);
            this.txtBoxMinSzW.Name = "txtBoxMinSzW";
            this.txtBoxMinSzW.Size = new System.Drawing.Size(35, 20);
            this.txtBoxMinSzW.TabIndex = 5;
            this.txtBoxMinSzW.TextChanged += new System.EventHandler(this.txtBoxMinSzW_TextChanged);
            // 
            // txtBoxMinSzH
            // 
            this.txtBoxMinSzH.Location = new System.Drawing.Point(353, 39);
            this.txtBoxMinSzH.Name = "txtBoxMinSzH";
            this.txtBoxMinSzH.Size = new System.Drawing.Size(35, 20);
            this.txtBoxMinSzH.TabIndex = 4;
            this.txtBoxMinSzH.TextChanged += new System.EventHandler(this.txtBoxMinSzH_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "MinSize ( w x h ):";
            // 
            // chkBoxBlob
            // 
            this.chkBoxBlob.AutoSize = true;
            this.chkBoxBlob.Location = new System.Drawing.Point(28, 62);
            this.chkBoxBlob.Name = "chkBoxBlob";
            this.chkBoxBlob.Size = new System.Drawing.Size(47, 17);
            this.chkBoxBlob.TabIndex = 1;
            this.chkBoxBlob.Text = "Blob";
            this.chkBoxBlob.UseVisualStyleBackColor = true;
            this.chkBoxBlob.CheckedChanged += new System.EventHandler(this.chkBoxBlob_CheckedChanged);
            // 
            // chkBoxCascade
            // 
            this.chkBoxCascade.AutoSize = true;
            this.chkBoxCascade.Location = new System.Drawing.Point(28, 39);
            this.chkBoxCascade.Name = "chkBoxCascade";
            this.chkBoxCascade.Size = new System.Drawing.Size(68, 17);
            this.chkBoxCascade.TabIndex = 0;
            this.chkBoxCascade.Text = "Cascade";
            this.chkBoxCascade.UseVisualStyleBackColor = true;
            this.chkBoxCascade.CheckedChanged += new System.EventHandler(this.chkBoxCascade_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(12, 262);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(677, 24);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Result";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(308, 292);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 39);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 336);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBoxDetector);
            this.Controls.Add(this.groupBoxSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.groupBoxSave.ResumeLayout(false);
            this.groupBoxSave.PerformLayout();
            this.groupBoxDetector.ResumeLayout(false);
            this.groupBoxDetector.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSave;
        private System.Windows.Forms.CheckBox chkBoxSave;
        private System.Windows.Forms.GroupBox groupBoxDetector;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkBoxBlob;
        private System.Windows.Forms.CheckBox chkBoxCascade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxSavePath;
        private System.Windows.Forms.Button btnOpenSaveDlg;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button btnRectColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxMinSzW;
        private System.Windows.Forms.TextBox txtBoxMinSzH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Label lblColorB;
        private System.Windows.Forms.Label lblColorG;
        private System.Windows.Forms.Label lblColorR;
        private System.Windows.Forms.Button btnOK;
    }
}