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
            this.picBoxImg = new System.Windows.Forms.PictureBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.chkBoxROIZone = new System.Windows.Forms.CheckBox();
            this.chkBoxROILine = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxImg)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picBoxImg
            // 
            this.picBoxImg.Location = new System.Drawing.Point(100, 12);
            this.picBoxImg.Name = "picBoxImg";
            this.picBoxImg.Size = new System.Drawing.Size(833, 519);
            this.picBoxImg.TabIndex = 1;
            this.picBoxImg.TabStop = false;
            this.picBoxImg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picBoxImg_MouseDown);
            this.picBoxImg.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picBoxImg_MouseMove);
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(12, 270);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(82, 261);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 257);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "ROIs:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnShow);
            this.groupBox1.Controls.Add(this.btnRemove);
            this.groupBox1.Controls.Add(this.btnClearAll);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.chkBoxROIZone);
            this.groupBox1.Controls.Add(this.chkBoxROILine);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(82, 232);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Types:";
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(8, 195);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(64, 23);
            this.btnShow.TabIndex = 14;
            this.btnShow.Text = "Show All";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(8, 137);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(64, 23);
            this.btnRemove.TabIndex = 13;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(8, 166);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(64, 23);
            this.btnClearAll.TabIndex = 12;
            this.btnClearAll.Text = "ClearAll";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(8, 108);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(64, 23);
            this.btnReset.TabIndex = 11;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(8, 79);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(64, 23);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // chkBoxROIZone
            // 
            this.chkBoxROIZone.AutoSize = true;
            this.chkBoxROIZone.Location = new System.Drawing.Point(6, 51);
            this.chkBoxROIZone.Name = "chkBoxROIZone";
            this.chkBoxROIZone.Size = new System.Drawing.Size(51, 17);
            this.chkBoxROIZone.TabIndex = 9;
            this.chkBoxROIZone.Text = "Zone";
            this.chkBoxROIZone.UseVisualStyleBackColor = true;
            this.chkBoxROIZone.CheckedChanged += new System.EventHandler(this.chkBoxROIZone_CheckedChanged);
            // 
            // chkBoxROILine
            // 
            this.chkBoxROILine.AutoSize = true;
            this.chkBoxROILine.Location = new System.Drawing.Point(6, 28);
            this.chkBoxROILine.Name = "chkBoxROILine";
            this.chkBoxROILine.Size = new System.Drawing.Size(46, 17);
            this.chkBoxROILine.TabIndex = 8;
            this.chkBoxROILine.Text = "Line";
            this.chkBoxROILine.UseVisualStyleBackColor = true;
            this.chkBoxROILine.CheckedChanged += new System.EventHandler(this.chkBoxROILine_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(858, 537);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(777, 537);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ROI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 569);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.picBoxImg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ROI";
            this.Text = "ROI";
            ((System.ComponentModel.ISupportInitialize)(this.picBoxImg)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxImg;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.CheckBox chkBoxROIZone;
        private System.Windows.Forms.CheckBox chkBoxROILine;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}