﻿namespace CamVehicle
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadVideoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadIPCamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.chkBoxSave = new System.Windows.Forms.CheckBox();
            this.btnAddList = new System.Windows.Forms.Button();
            this.btnRemoveList = new System.Windows.Forms.Button();
            this.btnEditList = new System.Windows.Forms.Button();
            this.btnVideoOpen = new System.Windows.Forms.Button();
            this.btnCamOpen = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listView2 = new System.Windows.Forms.ListView();
            this.listView1 = new System.Windows.Forms.ListView();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.chkBoxDetectBlob = new System.Windows.Forms.CheckBox();
            this.chkBoxDetectCascade = new System.Windows.Forms.CheckBox();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1225, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadVideoToolStripMenuItem,
            this.loadIPCamToolStripMenuItem,
            this.loadImageToolStripMenuItem});
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // loadVideoToolStripMenuItem
            // 
            this.loadVideoToolStripMenuItem.Name = "loadVideoToolStripMenuItem";
            this.loadVideoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.loadVideoToolStripMenuItem.Text = "Load Video";
            this.loadVideoToolStripMenuItem.Click += new System.EventHandler(this.loadVideoToolStripMenuItem_Click);
            // 
            // loadIPCamToolStripMenuItem
            // 
            this.loadIPCamToolStripMenuItem.Name = "loadIPCamToolStripMenuItem";
            this.loadIPCamToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.loadIPCamToolStripMenuItem.Text = "Load Camera";
            this.loadIPCamToolStripMenuItem.Click += new System.EventHandler(this.loadIPCamToolStripMenuItem_Click);
            // 
            // loadImageToolStripMenuItem
            // 
            this.loadImageToolStripMenuItem.Name = "loadImageToolStripMenuItem";
            this.loadImageToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.loadImageToolStripMenuItem.Text = "Load Image";
            this.loadImageToolStripMenuItem.Click += new System.EventHandler(this.loadImageToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // btnStart
            // 
            this.btnStart.Image = ((System.Drawing.Image)(resources.GetObject("btnStart.Image")));
            this.btnStart.Location = new System.Drawing.Point(555, 27);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(56, 46);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Image = ((System.Drawing.Image)(resources.GetObject("btnStop.Image")));
            this.btnStop.Location = new System.Drawing.Point(613, 27);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(56, 46);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Stop";
            this.btnStop.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // chkBoxSave
            // 
            this.chkBoxSave.AutoSize = true;
            this.chkBoxSave.Location = new System.Drawing.Point(716, 44);
            this.chkBoxSave.Name = "chkBoxSave";
            this.chkBoxSave.Size = new System.Drawing.Size(51, 17);
            this.chkBoxSave.TabIndex = 5;
            this.chkBoxSave.Text = "Save";
            this.chkBoxSave.UseVisualStyleBackColor = true;
            this.chkBoxSave.CheckedChanged += new System.EventHandler(this.chkBoxSave_CheckedChanged);
            // 
            // btnAddList
            // 
            this.btnAddList.Image = ((System.Drawing.Image)(resources.GetObject("btnAddList.Image")));
            this.btnAddList.Location = new System.Drawing.Point(194, 27);
            this.btnAddList.Name = "btnAddList";
            this.btnAddList.Size = new System.Drawing.Size(56, 46);
            this.btnAddList.TabIndex = 6;
            this.btnAddList.Text = "Add";
            this.btnAddList.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddList.UseVisualStyleBackColor = true;
            this.btnAddList.Click += new System.EventHandler(this.btnAddList_Click);
            // 
            // btnRemoveList
            // 
            this.btnRemoveList.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveList.Image")));
            this.btnRemoveList.Location = new System.Drawing.Point(253, 27);
            this.btnRemoveList.Name = "btnRemoveList";
            this.btnRemoveList.Size = new System.Drawing.Size(56, 46);
            this.btnRemoveList.TabIndex = 7;
            this.btnRemoveList.Text = "Remove";
            this.btnRemoveList.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRemoveList.UseVisualStyleBackColor = true;
            this.btnRemoveList.Click += new System.EventHandler(this.btnRemoveList_Click);
            // 
            // btnEditList
            // 
            this.btnEditList.Image = ((System.Drawing.Image)(resources.GetObject("btnEditList.Image")));
            this.btnEditList.Location = new System.Drawing.Point(311, 27);
            this.btnEditList.Name = "btnEditList";
            this.btnEditList.Size = new System.Drawing.Size(56, 46);
            this.btnEditList.TabIndex = 8;
            this.btnEditList.Text = "Edit";
            this.btnEditList.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditList.UseVisualStyleBackColor = true;
            this.btnEditList.Click += new System.EventHandler(this.btnEditList_Click);
            // 
            // btnVideoOpen
            // 
            this.btnVideoOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnVideoOpen.Image")));
            this.btnVideoOpen.Location = new System.Drawing.Point(12, 27);
            this.btnVideoOpen.Name = "btnVideoOpen";
            this.btnVideoOpen.Size = new System.Drawing.Size(56, 46);
            this.btnVideoOpen.TabIndex = 9;
            this.btnVideoOpen.Text = "Video";
            this.btnVideoOpen.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVideoOpen.UseVisualStyleBackColor = true;
            this.btnVideoOpen.Click += new System.EventHandler(this.btnVideoOpen_Click);
            // 
            // btnCamOpen
            // 
            this.btnCamOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnCamOpen.Image")));
            this.btnCamOpen.Location = new System.Drawing.Point(70, 27);
            this.btnCamOpen.Name = "btnCamOpen";
            this.btnCamOpen.Size = new System.Drawing.Size(56, 46);
            this.btnCamOpen.TabIndex = 10;
            this.btnCamOpen.Text = "Camera";
            this.btnCamOpen.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCamOpen.UseVisualStyleBackColor = true;
            this.btnCamOpen.Click += new System.EventHandler(this.btnCamOpen_Click);
            // 
            // button7
            // 
            this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
            this.button7.Location = new System.Drawing.Point(440, 27);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(56, 46);
            this.button7.TabIndex = 12;
            this.button7.Text = "View";
            this.button7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button7.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(132, 79);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(926, 548);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // listView2
            // 
            this.listView2.Location = new System.Drawing.Point(1064, 79);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(149, 548);
            this.listView2.TabIndex = 14;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(12, 79);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(114, 426);
            this.listView1.TabIndex = 15;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(12, 511);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(114, 116);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            // 
            // chkBoxDetectBlob
            // 
            this.chkBoxDetectBlob.AutoSize = true;
            this.chkBoxDetectBlob.Location = new System.Drawing.Point(920, 44);
            this.chkBoxDetectBlob.Name = "chkBoxDetectBlob";
            this.chkBoxDetectBlob.Size = new System.Drawing.Size(79, 17);
            this.chkBoxDetectBlob.TabIndex = 17;
            this.chkBoxDetectBlob.Text = "DetectBlob";
            this.chkBoxDetectBlob.UseVisualStyleBackColor = true;
            this.chkBoxDetectBlob.CheckedChanged += new System.EventHandler(this.chkBoxDetectBlob_CheckedChanged);
            // 
            // chkBoxDetectCascade
            // 
            this.chkBoxDetectCascade.AutoSize = true;
            this.chkBoxDetectCascade.Location = new System.Drawing.Point(789, 44);
            this.chkBoxDetectCascade.Name = "chkBoxDetectCascade";
            this.chkBoxDetectCascade.Size = new System.Drawing.Size(100, 17);
            this.chkBoxDetectCascade.TabIndex = 13;
            this.chkBoxDetectCascade.Text = "DetectCascade";
            this.chkBoxDetectCascade.UseVisualStyleBackColor = true;
            this.chkBoxDetectCascade.CheckedChanged += new System.EventHandler(this.chkBoxDetectCascade_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 639);
            this.Controls.Add(this.chkBoxDetectBlob);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.chkBoxDetectCascade);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.btnCamOpen);
            this.Controls.Add(this.btnVideoOpen);
            this.Controls.Add(this.btnEditList);
            this.Controls.Add(this.btnRemoveList);
            this.Controls.Add(this.btnAddList);
            this.Controls.Add(this.chkBoxSave);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "CamVehicle";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadVideoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadIPCamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem loadImageToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.CheckBox chkBoxSave;
        private System.Windows.Forms.Button btnAddList;
        private System.Windows.Forms.Button btnRemoveList;
        private System.Windows.Forms.Button btnEditList;
        private System.Windows.Forms.Button btnVideoOpen;
        private System.Windows.Forms.Button btnCamOpen;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.CheckBox chkBoxDetectBlob;
        private System.Windows.Forms.CheckBox chkBoxDetectCascade;
    }
}

