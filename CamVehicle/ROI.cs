using OpenCvSharp;
using OpenCvSharp.Extensions;
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
    public partial class ROI : Form
    {
        Mat matInitImage;
        Mat matToShow;

        bool bLineSel, bZoneSel;

        System.Drawing.Point initPoint;
        List<System.Drawing.Point> points;

        int numLines, numZones;
        public ROI()
        {
            matInitImage = new Mat();
            matToShow = new Mat();
            numLines = 0;
            numZones = 0;

            InitializeComponent();

            points = new List<System.Drawing.Point>();

            bLineSel = true;
            chkBoxROILine.Checked = bLineSel;
        }
        
        private void showImage(Mat matImage)
        {
            picBoxImg.Image = BitmapConverter.ToBitmap(matImage);
        }

        public void setInitImage(Mat matFrame){
            numLines = 0;
            numZones = 0;

            matFrame.CopyTo(matInitImage);
            Cv2.Resize(matInitImage, matInitImage, new OpenCvSharp.Size(picBoxImg.Width, picBoxImg.Height));

            listView1.Items.Clear();
            showImage(matInitImage);
        }
        
        private void picBoxImg_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // Remember the location where the button was pressed
                if (bLineSel)
                {
                    initPoint = e.Location;

                }

                if (bZoneSel)
                {
                    if (points.Count == 0)
                    {
                        matInitImage.CopyTo(matToShow);

                        Cv2.Circle(matToShow, new OpenCvSharp.Point(e.Location.X, e.Location.Y), 2, new Scalar(255, 0, 0), -1);
                        showImage(matToShow);

                        points.Add(e.Location);
                    }
                    else
                    {
                        matInitImage.CopyTo(matToShow);

                        points.Add(e.Location);

                        var len = points.Count;
                        for (int i = 0;  i < len-1; i++)
                        {
                            Cv2.Line(matToShow, new OpenCvSharp.Point(points[i].X, points[i].Y), new OpenCvSharp.Point(points[i + 1].X, points[i + 1].Y), new Scalar(255, 0, 0), 2);
                        }
                        showImage(matToShow);
                        
                    }
                    

                }
                
            }
        }

        private void picBoxImg_MouseMove(object sender, MouseEventArgs e)
        {

            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                if (bLineSel)
                {
                    matInitImage.CopyTo(matToShow);
                    Cv2.Line(matToShow, new OpenCvSharp.Point(initPoint.X, initPoint.Y), new OpenCvSharp.Point(e.Location.X, e.Location.Y), new Scalar(255, 0, 0), 2);
                    points.Insert(0, e.Location);
                    showImage(matToShow);
                }
            }
        }

        private void chkBoxROILine_CheckedChanged(object sender, EventArgs e)
        {
            bLineSel = chkBoxROILine.Checked;
            if (bLineSel && bZoneSel)
            {
                bZoneSel = !bLineSel;
                chkBoxROIZone.Checked = bZoneSel;

                points.Clear();                
                showImage(matInitImage);
            }
        }

        private void chkBoxROIZone_CheckedChanged(object sender, EventArgs e)
        {
            bZoneSel = chkBoxROIZone.Checked;
            if (bLineSel && bZoneSel)
            {
                bLineSel = !bZoneSel;
                chkBoxROILine.Checked = bLineSel;

                points.Clear();
                showImage(matInitImage);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (points.Count > 0)
            {
                if (bLineSel)
                {
                    ListViewItem item = new ListViewItem("Line_" + (++numLines).ToString());
                    
                    item.SubItems.Add(initPoint.X.ToString() + "," + initPoint.Y.ToString());
                    item.SubItems.Add(points[0].X.ToString() + "," + points[0].Y.ToString());

                    listView1.Items.Add(item);
                }
                if (bZoneSel)
                {
                    ListViewItem item = new ListViewItem("Zone_" + (++numZones).ToString());
                    for (int i = 0; i < points.Count; i++)
                        item.SubItems.Add(points[i].X.ToString() + "," + points[i].Y.ToString());

                    listView1.Items.Add(item);
                }
                points.Clear();
                showImage(matInitImage);
            }
        }


        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                int idx = listView1.Items.IndexOf(listView1.SelectedItems[0]);
                listView1.Items.RemoveAt(idx);
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            showImage(matInitImage);
        }

        private void showROI(int idx) {
            matInitImage.CopyTo(matToShow);
            int start, end;
            if (idx == -1) {
                start = 0;
                end = listView1.Items.Count;
            }
            else
            {
                start = idx;
                end = idx + 1;
            }
            for (int i = start; i < end; i++) { 
               
                var item = listView1.Items[i];
                for (int j = 0; j < item.SubItems.Count-1; j++){
                    var strPt1 = item.SubItems[j % (item.SubItems.Count-1) + 1].Text;
                    var strPt2 = item.SubItems[(j + 1) % (item.SubItems.Count-1) + 1].Text;

                    string[] val1 = strPt1.Split(',');
                    string[] val2 = strPt2.Split(',');
                    Cv2.Line(matToShow, new OpenCvSharp.Point(Int32.Parse(val1[0]), Int32.Parse(val1[1])), new OpenCvSharp.Point(Int32.Parse(val2[0]), Int32.Parse(val2[1])), new Scalar(255, 0, 0), 2);

                }
                showImage(matToShow);

            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            showROI(-1);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0){
                showROI(listView1.SelectedIndices[0]);
            }
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            points.Clear();            
            showImage(matInitImage);
        }

        public List<string> getROIs()
        {
            List<string> rois = new List<string>();

            var len = listView1.Items.Count;
            for (int i = 0; i < len; i++)
            {
                var sub_len = listView1.Items[i].SubItems.Count;
                string roi = listView1.Items[i].SubItems[0].Text;
                for (int j = 1; j < sub_len; j++)
                {
                    roi += "_" + listView1.Items[i].SubItems[j].Text;
                }

                rois.Add(roi);
            }

            return rois;
        }

        
    }
}
