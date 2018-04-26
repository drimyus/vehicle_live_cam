namespace CamVehicle
{
    partial class ROI
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioTrack = new System.Windows.Forms.RadioButton();
            this.radioZone = new System.Windows.Forms.RadioButton();
            this.radioLine = new System.Windows.Forms.RadioButton();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.picBoxImg = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxImg)).BeginInit();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(12, 338);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(90, 193);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 322);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "ROIs:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioTrack);
            this.groupBox1.Controls.Add(this.radioZone);
            this.groupBox1.Controls.Add(this.radioLine);
            this.groupBox1.Controls.Add(this.btnShow);
            this.groupBox1.Controls.Add(this.btnRemove);
            this.groupBox1.Controls.Add(this.btnClearAll);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(90, 297);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Types:";
            // 
            // radioTrack
            // 
            this.radioTrack.AutoSize = true;
            this.radioTrack.Location = new System.Drawing.Point(9, 29);
            this.radioTrack.Name = "radioTrack";
            this.radioTrack.Size = new System.Drawing.Size(75, 17);
            this.radioTrack.TabIndex = 17;
            this.radioTrack.TabStop = true;
            this.radioTrack.Text = "TrackArea";
            this.radioTrack.UseVisualStyleBackColor = true;
            this.radioTrack.CheckedChanged += new System.EventHandler(this.radioTrack_CheckedChanged);
            // 
            // radioZone
            // 
            this.radioZone.AutoSize = true;
            this.radioZone.Location = new System.Drawing.Point(9, 61);
            this.radioZone.Name = "radioZone";
            this.radioZone.Size = new System.Drawing.Size(50, 17);
            this.radioZone.TabIndex = 16;
            this.radioZone.TabStop = true;
            this.radioZone.Text = "Zone";
            this.radioZone.UseVisualStyleBackColor = true;
            this.radioZone.CheckedChanged += new System.EventHandler(this.radioZone_CheckedChanged);
            // 
            // radioLine
            // 
            this.radioLine.AutoSize = true;
            this.radioLine.Location = new System.Drawing.Point(9, 93);
            this.radioLine.Name = "radioLine";
            this.radioLine.Size = new System.Drawing.Size(45, 17);
            this.radioLine.TabIndex = 15;
            this.radioLine.TabStop = true;
            this.radioLine.Text = "Line";
            this.radioLine.UseVisualStyleBackColor = true;
            this.radioLine.CheckedChanged += new System.EventHandler(this.radioLine_CheckedChanged);
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(13, 259);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(64, 23);
            this.btnShow.TabIndex = 14;
            this.btnShow.Text = "Show All";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(13, 193);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(64, 23);
            this.btnRemove.TabIndex = 13;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(13, 226);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(64, 23);
            this.btnClearAll.TabIndex = 12;
            this.btnClearAll.Text = "ClearAll";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(13, 160);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(64, 23);
            this.btnReset.TabIndex = 11;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(13, 127);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(64, 23);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(867, 537);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(786, 537);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // picBoxImg
            // 
            this.picBoxImg.Location = new System.Drawing.Point(108, 20);
            this.picBoxImg.Name = "picBoxImg";
            this.picBoxImg.Size = new System.Drawing.Size(834, 511);
            this.picBoxImg.TabIndex = 12;
            this.picBoxImg.TabStop = false;
            this.picBoxImg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picBoxImg_MouseDown);
            this.picBoxImg.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picBoxImg_MouseMove);
            // 
            // ROI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 569);
            this.Controls.Add(this.picBoxImg);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ROI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ROI";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.PictureBox picBoxImg;
        private System.Windows.Forms.RadioButton radioTrack;
        private System.Windows.Forms.RadioButton radioZone;
        private System.Windows.Forms.RadioButton radioLine;
    }
}