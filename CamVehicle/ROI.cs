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
    /// <summary>
    /// Form for setting properties of ROIs
    /// </summary>
    {
        Mat matInitImage;
        Mat matToShow;

        bool bLineSel, bZoneSel, bTrackSel;

        System.Drawing.Point initPoint;
        List<System.Drawing.Point> points;

        int numLines, numZones;

        int origin_width, origin_Height;
        public ROI()
        {
            matInitImage = new Mat();
            matToShow = new Mat();
            numLines = 0;
            numZones = 0;

            InitializeComponent();
                      

            points = new List<System.Drawing.Point>();

            bTrackSel = true;
            radioTrack.Checked = bTrackSel;
            bLineSel = false;
            bZoneSel = false;
            
        }
        
        private void showImage(Mat matImage)
        ///<summary> show the cv image with the drawn ROI </summary>
        ///<param name="matImage"> cvimage to be shown </param>
        {
            if (matImage.Width != 0) { picBoxImg.Image = BitmapConverter.ToBitmap(matImage); }
            
        }

        public void setInitImage(Mat matFrame)
            /// <summary>
            /// set the init scene on which the ROIs are drawn
            /// </summary>
        {

            numLines = 0;
            numZones = 0;

            matFrame.CopyTo(matInitImage);
            Cv2.Resize(matInitImage, matInitImage, new OpenCvSharp.Size(picBoxImg.Width, picBoxImg.Height));

            listView1.Items.Clear();
            showImage(matInitImage);
        }

        public System.Drawing.Size getPicBoxSz()
            ///<summary> return the size of PictureBox which is used to calculate the zoom ratio when the form size is changed
            ///</summary>
            ///<returns> size of picture box </returns>
        {
            return new System.Drawing.Size(picBoxImg.Width, picBoxImg.Height);
        }

        private void picBoxImg_MouseDown(object sender, MouseEventArgs e)
            /// <summary> draw the ROI with mouse move and down event </summary>
            /// 
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // Remember the location where the button was pressed
                if (bLineSel)
                {
                    initPoint = e.Location;

                }

                if (bZoneSel || bTrackSel)
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
        /// <summary> draw the ROI with mouse move and down event </summary>
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

        private void btnAdd_Click(object sender, EventArgs e)
        /// <summary> 
        /// add the ROI object to the list of ROIs
        /// which will be transfered to the main Form
        /// </summary>
        {

            if (points.Count > 0)
            {
                string strLabel;
                if (bLineSel)
                {
                    LabelName lbl = new LabelName("Line");
                    lbl.ShowDialog();
                    strLabel = lbl.getLabel();                    

                    ListViewItem item = new ListViewItem(strLabel);
                    item.SubItems.Add("line");

                    item.SubItems.Add(initPoint.X.ToString() + "," + initPoint.Y.ToString());
                    item.SubItems.Add(points[0].X.ToString() + "," + points[0].Y.ToString());

                    listView1.Items.Add(item);
                }
                if (bZoneSel)
                {
                    LabelName lbl = new LabelName("Zone");
                    lbl.ShowDialog();
                    strLabel = lbl.getLabel();
                    

                    ListViewItem item = new ListViewItem(strLabel);
                    item.SubItems.Add("zone");

                    for (int i = 0; i < points.Count; i++)
                        item.SubItems.Add(points[i].X.ToString() + "," + points[i].Y.ToString());

                    listView1.Items.Add(item);
                }
                if (bTrackSel)
                {
                    LabelName lbl = new LabelName("TrackArea");
                    lbl.ShowDialog();
                    strLabel = lbl.getLabel();


                    ListViewItem item = new ListViewItem(strLabel);
                    item.SubItems.Add("trackarea");

                    for (int i = 0; i < points.Count; i++)
                        item.SubItems.Add(points[i].X.ToString() + "," + points[i].Y.ToString());

                    listView1.Items.Add(item);
                }
                points.Clear();
                showImage(matInitImage);
            }
        }


        private void btnRemove_Click(object sender, EventArgs e)
        /// <summary>remove the selected ROI from the list of ROIs
        /// </summary>
        {
            if (listView1.SelectedItems.Count != 0)
            {
                int idx = listView1.Items.IndexOf(listView1.SelectedItems[0]);
                listView1.Items.RemoveAt(idx);
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        ///<summary>
        /// clear the all element of ROI list
        /// </summary>
        {
            listView1.Items.Clear();
            showImage(matInitImage);
        }

        private void showROI(int idx)
        /// <summary>
        /// show the selected ROI on picture box
        /// </summary>
        /// 
        {
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

                string strItemLabel = item.SubItems[0].Text;
                string[] val1; 
                string[] val2;

                for (int j = 1; j < item.SubItems.Count-1; j++){
                    var strPt1 = item.SubItems[j % (item.SubItems.Count-2) + 2].Text;
                    var strPt2 = item.SubItems[(j + 1) % (item.SubItems.Count-2) + 2].Text;

                    val1 = strPt1.Split(',');
                    val2 = strPt2.Split(',');
                    Cv2.Line(matToShow, new OpenCvSharp.Point(Int32.Parse(val1[0]), Int32.Parse(val1[1])), new OpenCvSharp.Point(Int32.Parse(val2[0]), Int32.Parse(val2[1])), new Scalar(255, 0, 0), 2);
                }

                string[] val = item.SubItems[item.SubItems.Count-1].Text.Split(',');

                Cv2.PutText(matToShow, strItemLabel, new OpenCvSharp.Point(Int32.Parse(val[0]), Int32.Parse(val[1])), HersheyFonts.HersheyPlain, (double)1, new Scalar(255, 0, 0), 2);

                showImage(matToShow);

            }
        }

        private void btnShow_Click(object sender, EventArgs e)
            ///<summary>
            /// show all ROIs on Picture box
            ///</summary>
        {
            showROI(-1);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        /// <summary> select the ROI from the list of ROIs
        /// </summary>
        {
            if (listView1.SelectedItems.Count != 0){
                showROI(listView1.SelectedIndices[0]);
            }
            
        }

        private void btnOK_Click(object sender, EventArgs e)
            ///<summary> save the list ROIs </summary>
        {
            this.Close();
        }

        private void radioTrack_CheckedChanged(object sender, EventArgs e)
        /// <summary> set the ROI type as tracking area </summary>
        {
            bTrackSel = radioTrack.Checked;
            points.Clear();
            showImage(matInitImage);
        }

        private void radioZone_CheckedChanged(object sender, EventArgs e)
        /// <summary> set the ROI type as Zone Area </summary>
        {
            bZoneSel = radioZone.Checked;
            points.Clear();
            showImage(matInitImage);
        }

        private void radioLine_CheckedChanged(object sender, EventArgs e)
        /// <summary> set the ROI type as Line Object </summary>
        {
            bLineSel = radioLine.Checked;
            points.Clear();
            showImage(matInitImage);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        /// <summary> button for cancel the setting of ROIs </summary>
        {
            listView1.Items.Clear();
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        /// <summary> button for reset current ROI </summary>
        {
            points.Clear();
            showImage(matInitImage);
        }

        public List<string> getROIs()
            /// return the list ROIs
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
