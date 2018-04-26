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
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxHost = new System.Windows.Forms.TextBox();
            this.chkBoxExport = new System.Windows.Forms.CheckBox();
            this.lblSavePath = new System.Windows.Forms.Label();
            this.txtBoxSavePath = new System.Windows.Forms.TextBox();
            this.btnOpenSaveDlg = new System.Windows.Forms.Button();
            this.chkBoxSave = new System.Windows.Forms.CheckBox();
            this.groupBoxDetector = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBoxSameRect = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkBoxBlob = new System.Windows.Forms.CheckBox();
            this.chkBoxCascade = new System.Windows.Forms.CheckBox();
            this.chkBoxShowRect = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxMinSzW = new System.Windows.Forms.TextBox();
            this.txtBoxMinSzH = new System.Windows.Forms.TextBox();
            this.lblMinSize = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBoxClass3_w = new System.Windows.Forms.TextBox();
            this.txtBoxClass3_h = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBoxClass2_w = new System.Windows.Forms.TextBox();
            this.txtBoxClass2_h = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBoxClass1_w = new System.Windows.Forms.TextBox();
            this.txtBoxClass1_h = new System.Windows.Forms.TextBox();
            this.lblClass3Sz = new System.Windows.Forms.Label();
            this.lblClass2Sz = new System.Windows.Forms.Label();
            this.lblClass1Sz = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkBoxShowROI = new System.Windows.Forms.CheckBox();
            this.txtBoxROIFntSZ = new System.Windows.Forms.TextBox();
            this.txtBoxRectFntSZ = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblROIColorB = new System.Windows.Forms.Label();
            this.lblROIColorG = new System.Windows.Forms.Label();
            this.lblROIColorR = new System.Windows.Forms.Label();
            this.btnROIColor = new System.Windows.Forms.Button();
            this.lblRectColorB = new System.Windows.Forms.Label();
            this.lblRectColorG = new System.Windows.Forms.Label();
            this.lblRectColorR = new System.Windows.Forms.Label();
            this.btnRectColor = new System.Windows.Forms.Button();
            this.groupBoxSave.SuspendLayout();
            this.groupBoxDetector.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSave
            // 
            this.groupBoxSave.Controls.Add(this.label2);
            this.groupBoxSave.Controls.Add(this.txtBoxPort);
            this.groupBoxSave.Controls.Add(this.label1);
            this.groupBoxSave.Controls.Add(this.txtBoxHost);
            this.groupBoxSave.Controls.Add(this.chkBoxExport);
            this.groupBoxSave.Controls.Add(this.lblSavePath);
            this.groupBoxSave.Controls.Add(this.txtBoxSavePath);
            this.groupBoxSave.Controls.Add(this.btnOpenSaveDlg);
            this.groupBoxSave.Controls.Add(this.chkBoxSave);
            this.groupBoxSave.Location = new System.Drawing.Point(12, 100);
            this.groupBoxSave.Name = "groupBoxSave";
            this.groupBoxSave.Size = new System.Drawing.Size(461, 152);
            this.groupBoxSave.TabIndex = 0;
            this.groupBoxSave.TabStop = false;
            this.groupBoxSave.Text = "Output";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(307, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Port:";
            // 
            // txtBoxPort
            // 
            this.txtBoxPort.Location = new System.Drawing.Point(342, 113);
            this.txtBoxPort.Name = "txtBoxPort";
            this.txtBoxPort.Size = new System.Drawing.Size(66, 20);
            this.txtBoxPort.TabIndex = 14;
            this.txtBoxPort.TextChanged += new System.EventHandler(this.txtBoxPort_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Host:";
            // 
            // txtBoxHost
            // 
            this.txtBoxHost.Location = new System.Drawing.Point(84, 113);
            this.txtBoxHost.Name = "txtBoxHost";
            this.txtBoxHost.Size = new System.Drawing.Size(202, 20);
            this.txtBoxHost.TabIndex = 12;
            this.txtBoxHost.TextChanged += new System.EventHandler(this.txtBoxHost_TextChanged);
            // 
            // chkBoxExport
            // 
            this.chkBoxExport.AutoSize = true;
            this.chkBoxExport.Location = new System.Drawing.Point(24, 90);
            this.chkBoxExport.Name = "chkBoxExport";
            this.chkBoxExport.Size = new System.Drawing.Size(56, 17);
            this.chkBoxExport.TabIndex = 11;
            this.chkBoxExport.Text = "Export";
            this.chkBoxExport.UseVisualStyleBackColor = true;
            this.chkBoxExport.CheckedChanged += new System.EventHandler(this.chkBoxExport_CheckedChanged);
            // 
            // lblSavePath
            // 
            this.lblSavePath.AutoSize = true;
            this.lblSavePath.Location = new System.Drawing.Point(49, 55);
            this.lblSavePath.Name = "lblSavePath";
            this.lblSavePath.Size = new System.Drawing.Size(32, 13);
            this.lblSavePath.TabIndex = 3;
            this.lblSavePath.Text = "Path:";
            // 
            // txtBoxSavePath
            // 
            this.txtBoxSavePath.Location = new System.Drawing.Point(84, 52);
            this.txtBoxSavePath.Name = "txtBoxSavePath";
            this.txtBoxSavePath.Size = new System.Drawing.Size(296, 20);
            this.txtBoxSavePath.TabIndex = 2;
            // 
            // btnOpenSaveDlg
            // 
            this.btnOpenSaveDlg.Location = new System.Drawing.Point(386, 52);
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
            this.chkBoxSave.Location = new System.Drawing.Point(24, 31);
            this.chkBoxSave.Name = "chkBoxSave";
            this.chkBoxSave.Size = new System.Drawing.Size(53, 17);
            this.chkBoxSave.TabIndex = 0;
            this.chkBoxSave.Text = "Video";
            this.chkBoxSave.UseVisualStyleBackColor = true;
            this.chkBoxSave.CheckedChanged += new System.EventHandler(this.chkBoxSave_CheckedChanged);
            // 
            // groupBoxDetector
            // 
            this.groupBoxDetector.Controls.Add(this.label12);
            this.groupBoxDetector.Controls.Add(this.txtBoxSameRect);
            this.groupBoxDetector.Controls.Add(this.label6);
            this.groupBoxDetector.Controls.Add(this.chkBoxBlob);
            this.groupBoxDetector.Controls.Add(this.chkBoxCascade);
            this.groupBoxDetector.Location = new System.Drawing.Point(12, 12);
            this.groupBoxDetector.Name = "groupBoxDetector";
            this.groupBoxDetector.Size = new System.Drawing.Size(461, 82);
            this.groupBoxDetector.TabIndex = 1;
            this.groupBoxDetector.TabStop = false;
            this.groupBoxDetector.Text = "Detector";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(217, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "Threshold Rect:";
            // 
            // txtBoxSameRect
            // 
            this.txtBoxSameRect.Location = new System.Drawing.Point(288, 37);
            this.txtBoxSameRect.Name = "txtBoxSameRect";
            this.txtBoxSameRect.Size = new System.Drawing.Size(115, 20);
            this.txtBoxSameRect.TabIndex = 4;
            this.txtBoxSameRect.TextChanged += new System.EventHandler(this.txtBoxSameRect_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Mode:";
            // 
            // chkBoxBlob
            // 
            this.chkBoxBlob.AutoSize = true;
            this.chkBoxBlob.Location = new System.Drawing.Point(52, 32);
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
            this.chkBoxCascade.Location = new System.Drawing.Point(52, 55);
            this.chkBoxCascade.Name = "chkBoxCascade";
            this.chkBoxCascade.Size = new System.Drawing.Size(68, 17);
            this.chkBoxCascade.TabIndex = 0;
            this.chkBoxCascade.Text = "Cascade";
            this.chkBoxCascade.UseVisualStyleBackColor = true;
            this.chkBoxCascade.CheckedChanged += new System.EventHandler(this.chkBoxCascade_CheckedChanged);
            // 
            // chkBoxShowRect
            // 
            this.chkBoxShowRect.AutoSize = true;
            this.chkBoxShowRect.Location = new System.Drawing.Point(80, 35);
            this.chkBoxShowRect.Name = "chkBoxShowRect";
            this.chkBoxShowRect.Size = new System.Drawing.Size(79, 17);
            this.chkBoxShowRect.TabIndex = 2;
            this.chkBoxShowRect.Text = "Show Rect";
            this.chkBoxShowRect.UseVisualStyleBackColor = true;
            this.chkBoxShowRect.CheckedChanged += new System.EventHandler(this.chkBoxShowRect_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtBoxMinSzW);
            this.groupBox3.Controls.Add(this.txtBoxMinSzH);
            this.groupBox3.Controls.Add(this.lblMinSize);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtBoxClass3_w);
            this.groupBox3.Controls.Add(this.txtBoxClass3_h);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtBoxClass2_w);
            this.groupBox3.Controls.Add(this.txtBoxClass2_h);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtBoxClass1_w);
            this.groupBox3.Controls.Add(this.txtBoxClass1_h);
            this.groupBox3.Controls.Add(this.lblClass3Sz);
            this.groupBox3.Controls.Add(this.lblClass2Sz);
            this.groupBox3.Controls.Add(this.lblClass1Sz);
            this.groupBox3.Location = new System.Drawing.Point(12, 422);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(461, 130);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Classifier Size: H x W";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(272, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "x";
            // 
            // txtBoxMinSzW
            // 
            this.txtBoxMinSzW.Location = new System.Drawing.Point(220, 19);
            this.txtBoxMinSzW.Name = "txtBoxMinSzW";
            this.txtBoxMinSzW.Size = new System.Drawing.Size(35, 20);
            this.txtBoxMinSzW.TabIndex = 18;
            this.txtBoxMinSzW.TextChanged += new System.EventHandler(this.txtBoxMinSzW_TextChanged);
            // 
            // txtBoxMinSzH
            // 
            this.txtBoxMinSzH.Location = new System.Drawing.Point(298, 19);
            this.txtBoxMinSzH.Name = "txtBoxMinSzH";
            this.txtBoxMinSzH.Size = new System.Drawing.Size(35, 20);
            this.txtBoxMinSzH.TabIndex = 17;
            this.txtBoxMinSzH.TextChanged += new System.EventHandler(this.txtBoxMinSzH_TextChanged);
            // 
            // lblMinSize
            // 
            this.lblMinSize.AutoSize = true;
            this.lblMinSize.Location = new System.Drawing.Point(89, 23);
            this.lblMinSize.Name = "lblMinSize";
            this.lblMinSize.Size = new System.Drawing.Size(51, 13);
            this.lblMinSize.TabIndex = 16;
            this.lblMinSize.Text = "Minimum:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(272, 101);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(12, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "x";
            // 
            // txtBoxClass3_w
            // 
            this.txtBoxClass3_w.Location = new System.Drawing.Point(220, 97);
            this.txtBoxClass3_w.Name = "txtBoxClass3_w";
            this.txtBoxClass3_w.Size = new System.Drawing.Size(35, 20);
            this.txtBoxClass3_w.TabIndex = 14;
            this.txtBoxClass3_w.TextChanged += new System.EventHandler(this.txtBoxClass3_w_TextChanged);
            // 
            // txtBoxClass3_h
            // 
            this.txtBoxClass3_h.Location = new System.Drawing.Point(298, 97);
            this.txtBoxClass3_h.Name = "txtBoxClass3_h";
            this.txtBoxClass3_h.Size = new System.Drawing.Size(35, 20);
            this.txtBoxClass3_h.TabIndex = 13;
            this.txtBoxClass3_h.TextChanged += new System.EventHandler(this.txtBoxClass3_h_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(272, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(12, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "x";
            // 
            // txtBoxClass2_w
            // 
            this.txtBoxClass2_w.Location = new System.Drawing.Point(220, 71);
            this.txtBoxClass2_w.Name = "txtBoxClass2_w";
            this.txtBoxClass2_w.Size = new System.Drawing.Size(35, 20);
            this.txtBoxClass2_w.TabIndex = 11;
            this.txtBoxClass2_w.TextChanged += new System.EventHandler(this.txtBoxClass2_w_TextChanged);
            // 
            // txtBoxClass2_h
            // 
            this.txtBoxClass2_h.Location = new System.Drawing.Point(298, 71);
            this.txtBoxClass2_h.Name = "txtBoxClass2_h";
            this.txtBoxClass2_h.Size = new System.Drawing.Size(35, 20);
            this.txtBoxClass2_h.TabIndex = 10;
            this.txtBoxClass2_h.TextChanged += new System.EventHandler(this.txtBoxClass2_h_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(272, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "x";
            // 
            // txtBoxClass1_w
            // 
            this.txtBoxClass1_w.Location = new System.Drawing.Point(220, 45);
            this.txtBoxClass1_w.Name = "txtBoxClass1_w";
            this.txtBoxClass1_w.Size = new System.Drawing.Size(35, 20);
            this.txtBoxClass1_w.TabIndex = 8;
            this.txtBoxClass1_w.TextChanged += new System.EventHandler(this.txtBoxClass1_w_TextChanged);
            // 
            // txtBoxClass1_h
            // 
            this.txtBoxClass1_h.Location = new System.Drawing.Point(298, 45);
            this.txtBoxClass1_h.Name = "txtBoxClass1_h";
            this.txtBoxClass1_h.Size = new System.Drawing.Size(35, 20);
            this.txtBoxClass1_h.TabIndex = 7;
            this.txtBoxClass1_h.TextChanged += new System.EventHandler(this.txtBoxClass1_h_TextChanged);
            // 
            // lblClass3Sz
            // 
            this.lblClass3Sz.AutoSize = true;
            this.lblClass3Sz.Location = new System.Drawing.Point(89, 101);
            this.lblClass3Sz.Name = "lblClass3Sz";
            this.lblClass3Sz.Size = new System.Drawing.Size(104, 13);
            this.lblClass3Sz.TabIndex = 2;
            this.lblClass3Sz.Text = "Class 3 (Bus/Truck):";
            // 
            // lblClass2Sz
            // 
            this.lblClass2Sz.AutoSize = true;
            this.lblClass2Sz.Location = new System.Drawing.Point(89, 75);
            this.lblClass2Sz.Name = "lblClass2Sz";
            this.lblClass2Sz.Size = new System.Drawing.Size(69, 13);
            this.lblClass2Sz.TabIndex = 1;
            this.lblClass2Sz.Text = "Class 2 (Car):";
            // 
            // lblClass1Sz
            // 
            this.lblClass1Sz.AutoSize = true;
            this.lblClass1Sz.Location = new System.Drawing.Point(89, 49);
            this.lblClass1Sz.Name = "lblClass1Sz";
            this.lblClass1Sz.Size = new System.Drawing.Size(86, 13);
            this.lblClass1Sz.TabIndex = 0;
            this.lblClass1Sz.Text = "Class 1 (bicycle):";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(317, 558);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(398, 558);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkBoxShowROI);
            this.groupBox2.Controls.Add(this.txtBoxROIFntSZ);
            this.groupBox2.Controls.Add(this.txtBoxRectFntSZ);
            this.groupBox2.Controls.Add(this.chkBoxShowRect);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.lblROIColorB);
            this.groupBox2.Controls.Add(this.lblROIColorG);
            this.groupBox2.Controls.Add(this.lblROIColorR);
            this.groupBox2.Controls.Add(this.btnROIColor);
            this.groupBox2.Controls.Add(this.lblRectColorB);
            this.groupBox2.Controls.Add(this.lblRectColorG);
            this.groupBox2.Controls.Add(this.lblRectColorR);
            this.groupBox2.Controls.Add(this.btnRectColor);
            this.groupBox2.Location = new System.Drawing.Point(12, 258);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(461, 158);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Label";
            // 
            // chkBoxShowROI
            // 
            this.chkBoxShowROI.AutoSize = true;
            this.chkBoxShowROI.Location = new System.Drawing.Point(296, 34);
            this.chkBoxShowROI.Name = "chkBoxShowROI";
            this.chkBoxShowROI.Size = new System.Drawing.Size(80, 17);
            this.chkBoxShowROI.TabIndex = 4;
            this.chkBoxShowROI.Text = "Show ROIs";
            this.chkBoxShowROI.UseVisualStyleBackColor = true;
            this.chkBoxShowROI.CheckedChanged += new System.EventHandler(this.chkBoxShowROI_CheckedChanged);
            // 
            // txtBoxROIFntSZ
            // 
            this.txtBoxROIFntSZ.Location = new System.Drawing.Point(349, 123);
            this.txtBoxROIFntSZ.Name = "txtBoxROIFntSZ";
            this.txtBoxROIFntSZ.Size = new System.Drawing.Size(35, 20);
            this.txtBoxROIFntSZ.TabIndex = 24;
            this.txtBoxROIFntSZ.TextChanged += new System.EventHandler(this.txtBoxROIFntSZ_TextChanged);
            // 
            // txtBoxRectFntSZ
            // 
            this.txtBoxRectFntSZ.Location = new System.Drawing.Point(139, 123);
            this.txtBoxRectFntSZ.Name = "txtBoxRectFntSZ";
            this.txtBoxRectFntSZ.Size = new System.Drawing.Size(35, 20);
            this.txtBoxRectFntSZ.TabIndex = 23;
            this.txtBoxRectFntSZ.TextChanged += new System.EventHandler(this.txtBoxRectFntSZ_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(294, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Font Size";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(79, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Font Size:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(261, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "ROI:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(41, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Rect:";
            // 
            // lblROIColorB
            // 
            this.lblROIColorB.AutoSize = true;
            this.lblROIColorB.Location = new System.Drawing.Point(376, 93);
            this.lblROIColorB.Name = "lblROIColorB";
            this.lblROIColorB.Size = new System.Drawing.Size(20, 13);
            this.lblROIColorB.TabIndex = 18;
            this.lblROIColorB.Text = "B: ";
            // 
            // lblROIColorG
            // 
            this.lblROIColorG.AutoSize = true;
            this.lblROIColorG.Location = new System.Drawing.Point(376, 78);
            this.lblROIColorG.Name = "lblROIColorG";
            this.lblROIColorG.Size = new System.Drawing.Size(21, 13);
            this.lblROIColorG.TabIndex = 17;
            this.lblROIColorG.Text = "G: ";
            // 
            // lblROIColorR
            // 
            this.lblROIColorR.AutoSize = true;
            this.lblROIColorR.Location = new System.Drawing.Point(376, 63);
            this.lblROIColorR.Name = "lblROIColorR";
            this.lblROIColorR.Size = new System.Drawing.Size(21, 13);
            this.lblROIColorR.TabIndex = 16;
            this.lblROIColorR.Text = "R: ";
            // 
            // btnROIColor
            // 
            this.btnROIColor.Location = new System.Drawing.Point(294, 62);
            this.btnROIColor.Name = "btnROIColor";
            this.btnROIColor.Size = new System.Drawing.Size(57, 43);
            this.btnROIColor.TabIndex = 15;
            this.btnROIColor.Text = "Color";
            this.btnROIColor.UseVisualStyleBackColor = true;
            this.btnROIColor.Click += new System.EventHandler(this.btnROIColor_Click);
            // 
            // lblRectColorB
            // 
            this.lblRectColorB.AutoSize = true;
            this.lblRectColorB.Location = new System.Drawing.Point(161, 93);
            this.lblRectColorB.Name = "lblRectColorB";
            this.lblRectColorB.Size = new System.Drawing.Size(20, 13);
            this.lblRectColorB.TabIndex = 14;
            this.lblRectColorB.Text = "B: ";
            // 
            // lblRectColorG
            // 
            this.lblRectColorG.AutoSize = true;
            this.lblRectColorG.Location = new System.Drawing.Point(161, 78);
            this.lblRectColorG.Name = "lblRectColorG";
            this.lblRectColorG.Size = new System.Drawing.Size(21, 13);
            this.lblRectColorG.TabIndex = 13;
            this.lblRectColorG.Text = "G: ";
            // 
            // lblRectColorR
            // 
            this.lblRectColorR.AutoSize = true;
            this.lblRectColorR.Location = new System.Drawing.Point(161, 63);
            this.lblRectColorR.Name = "lblRectColorR";
            this.lblRectColorR.Size = new System.Drawing.Size(21, 13);
            this.lblRectColorR.TabIndex = 12;
            this.lblRectColorR.Text = "R: ";
            // 
            // btnRectColor
            // 
            this.btnRectColor.Location = new System.Drawing.Point(79, 62);
            this.btnRectColor.Name = "btnRectColor";
            this.btnRectColor.Size = new System.Drawing.Size(57, 43);
            this.btnRectColor.TabIndex = 11;
            this.btnRectColor.Text = "Color";
            this.btnRectColor.UseVisualStyleBackColor = true;
            this.btnRectColor.Click += new System.EventHandler(this.btnRectColor_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 589);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancel);
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
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSave;
        private System.Windows.Forms.CheckBox chkBoxSave;
        private System.Windows.Forms.GroupBox groupBoxDetector;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkBoxBlob;
        private System.Windows.Forms.CheckBox chkBoxCascade;
        private System.Windows.Forms.Label lblSavePath;
        private System.Windows.Forms.TextBox txtBoxSavePath;
        private System.Windows.Forms.Button btnOpenSaveDlg;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBoxClass3_w;
        private System.Windows.Forms.TextBox txtBoxClass3_h;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBoxClass2_w;
        private System.Windows.Forms.TextBox txtBoxClass2_h;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBoxClass1_w;
        private System.Windows.Forms.TextBox txtBoxClass1_h;
        private System.Windows.Forms.Label lblClass3Sz;
        private System.Windows.Forms.Label lblClass2Sz;
        private System.Windows.Forms.Label lblClass1Sz;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkBoxExport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxMinSzW;
        private System.Windows.Forms.TextBox txtBoxMinSzH;
        private System.Windows.Forms.Label lblMinSize;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblROIColorB;
        private System.Windows.Forms.Label lblROIColorG;
        private System.Windows.Forms.Label lblROIColorR;
        private System.Windows.Forms.Button btnROIColor;
        private System.Windows.Forms.Label lblRectColorB;
        private System.Windows.Forms.Label lblRectColorG;
        private System.Windows.Forms.Label lblRectColorR;
        private System.Windows.Forms.Button btnRectColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxHost;
        private System.Windows.Forms.TextBox txtBoxROIFntSZ;
        private System.Windows.Forms.TextBox txtBoxRectFntSZ;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkBoxShowRect;
        private System.Windows.Forms.CheckBox chkBoxShowROI;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBoxSameRect;
    }
}