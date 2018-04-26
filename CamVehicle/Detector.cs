using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenCvSharp;

namespace CamVehicle
{
    class Detector
        /// <summary>
        /// functionalities for manage the detecting and checking the traffic events with ROI objects
        /// </summary>
    {
        // cascade Detector settings
        CascadeClassifier cascade;
        double dScaleFactor;
        int uMinNeighbors;
        Size minSize;

        // Blob Detector Settings
        Mat matGray = new Mat();
        Mat kernel1, kernel2;
        private BackgroundSubtractor bckSub;
        private Mat fgMask;                

        
        public Detector()
        {
            cascade = new CascadeClassifier(@"../cascade/cars.xml");
            dScaleFactor = 1.1;
            uMinNeighbors = 2;
            minSize = new Size(100, 100);


            this.bckSub = BackgroundSubtractorKNN.Create();
            this.fgMask = new Mat();
            this.kernel1 = Cv2.GetStructuringElement(MorphShapes.Rect, new Size(5, 5));
            this.kernel2 = Cv2.GetStructuringElement(MorphShapes.Rect, new Size(5, 5));

        }
        
        public List<Rect> proc(Mat matFrame)
            ///<summary>
            /// detect the vehicles from the matFrame, using the OpenCV's Cascade detector
            ///</summary>
            /// <param name="matFrame">input cvmat of frame</param>
        {
            Cv2.CvtColor(matFrame, matGray, ColorConversionCodes.BGRA2GRAY);
            Cv2.EqualizeHist(matGray, matGray);
            
            var dets = cascade.DetectMultiScale(
                image: matGray,
                scaleFactor: dScaleFactor,
                minNeighbors: uMinNeighbors,
                flags: HaarDetectionType.DoRoughSearch | HaarDetectionType.ScaleImage,
                minSize: minSize
                );

            var cars = new List<Rect>();
            foreach (var det in dets)
                cars.Add(det);

            return cars;
        }
        public List<Rect> proc2(Mat matFrame)
            ///<summary>
            /// detect the vehicles from the matFrame using the Blob detector
            ///</summary>
            /// <param name="matFrame">input cvmat of frame</param>
        {
            this.bckSub.Apply(matFrame, this.fgMask, 0.01);
            //Cv2.ImShow("mask", this.fgMask);
            
            Cv2.MedianBlur(this.fgMask, this.fgMask, 3);
            //Cv2.ImShow("blur", this.fgMask);
            
            Cv2.MorphologyEx(this.fgMask, this.fgMask, MorphTypes.Open, kernel1);
            //Cv2.ImShow("morph", this.fgMask);

            Cv2.Threshold(this.fgMask, this.fgMask, 10, 255, ThresholdTypes.Binary);
            //Cv2.ImShow("thresh", this.fgMask);
            //Cv2.WaitKey(1);
            
            Point[][] contours;
            HierarchyIndex[] hierarchyIndexes;
            Cv2.FindContours(
                this.fgMask,
                out contours,
                out hierarchyIndexes,
                mode: RetrievalModes.CComp,
                method: ContourApproximationModes.ApproxSimple
                );

            var contourIndex = 0;
            var previewsArea = 0.0;
            var cars = new List<Rect>();
            
            while ((contourIndex >= 0) && (contours.Length >= 0))
            {
                var contour = contours[contourIndex];
                var boundingRect = Cv2.BoundingRect(contour);
                var boundingRectArea = boundingRect.Width * boundingRect.Height;
                if (boundingRectArea > previewsArea)
                {
                    cars.Add(boundingRect);
                    //Cv2.Rectangle(matFrame, new Point(boundingRect.X, boundingRect.Y), new Point(boundingRect.X + boundingRect.Width, boundingRect.Y + boundingRect.Height), new Scalar(0, 255, 0));
                }
                contourIndex = hierarchyIndexes[contourIndex].Next;
            }
            return cars;
           
        }

        
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        

        public int disRect2Line(Rect r, OpenCvSharp.Point pt1, OpenCvSharp.Point pt2)
            ///<summary> 
            /// distance between rectangle and line
            /// which is used for checking the traffic event (crossing line)
            /// 
            ///</summary>
            /// <param name="pt1"> first endpoint of line</param>
            /// <param name="pt2"> second endpoint of line</param>
            /// <param name="r"> rectangle </param>

        {
            OpenCvSharp.Point pt = new OpenCvSharp.Point((int)(r.X + r.Width / 2), (int)(r.Y + r.Height / 2));

            var nom = Math.Abs((pt2.Y - pt1.Y) * pt.X - (pt2.X - pt1.X) * pt.Y + pt2.X * pt1.Y - pt2.Y * pt1.X);
            var denom = Math.Sqrt((pt2.Y - pt1.Y) * (pt2.Y - pt1.Y) + (pt2.X - pt1.X) * (pt2.X - pt1.X));

            return (int)(nom / denom);

        }

        public int disRect2Rect(Rect r1, Rect r2)
            /// <summary>
            /// distance between two rects
            /// </summary>
            /// <param name="r1"> rect of vehicle </param>
            /// <param name="r2"> rect of vehicle </param>
        {
            var d_x = (r1.X + r1.Width / 2) - (r2.X + r2.Width / 2);
            var d_y = (r1.Y + r1.Height / 2) - (r2.Y + r2.Height / 2);
            return (int)Math.Sqrt(d_x * d_x + d_y * d_y);
        }


        public bool isSameRects(Rect r1, Rect r2, double dThresh)
            ///<summary>
            /// check if the rects are same object or not, using the positon relation ship
            ///</summary>
            ///<param name="r1"> rect of object </param>
            ///<param name="r2"> rect of object </param>
            ///<param name="dThresh"> threshold of distance and size </param>
        {
            var sz1 = r1.Width * r1.Height;
            var sz2 = r2.Width * r2.Height;

            var sz_dis = Math.Abs(sz1 - sz2) * 2 / (sz1 + sz2);
            var cen_dis = disRect2Rect(r1, r2);

            if ((cen_dis < ((r1.Width + r2.Width) * dThresh)) && (sz_dis < dThresh))
                return true;
            else
                return false;
        }
        
        public bool isBorderRect(Rect r, OpenCvSharp.Size matSz)
            /// <summary> 
            /// check if the object rect is located on edge of scene(which means disappear)
            /// </summary>
            /// <param name="r"> rect of object </param>
            /// <param name="matSz"> size of input frame </param>
        {
            var padding = matSz.Height / 50;
            if (r.X > padding && (r.X + r.Width + padding) < matSz.Width && r.Y > padding && (r.Y + r.Height + padding) < matSz.Height)
                return false;
            else
                return true;
        }

        public bool isCrossLine(Rect r1, Rect r2, List<OpenCvSharp.Point> roiLine)
            /// <summary> 
            /// check if the object is cross the line or not
            /// </summary>
            /// <param name="r1"> object rect preview positoin </param>
            /// <param name="r2"> object rect current position </param>
            /// <param name="roiLine"> line object </param>
            /// 

        {
            var p1x = r1.X + r1.Width / 2;
            var p1y = r1.Y + r1.Height / 2;
            var p2x = r2.X + r2.Width / 2;
            var p2y = r2.Y + r2.Height / 2;

            var p3x = roiLine[0].X;
            var p3y = roiLine[0].Y;
            var p4x = roiLine[1].X;
            var p4y = roiLine[1].Y;

            Int64 sign1 = (p2x - p1x) * (p3y - p1y) - (p3x - p1x) * (p2y - p1y);
            Int64 sign2 = (p2x - p1x) * (p4y - p1y) - (p4x - p1x) * (p2y - p1y);
            Int64 sign3 = (p4x - p3x) * (p1y - p3y) - (p1x - p3x) * (p4y - p3y);
            Int64 sign4 = (p4x - p3x) * (p2y - p3y) - (p2x - p3x) * (p4y - p3y);

            if (((sign1 * sign2) < 0) && ((sign3 * sign4) < 0))
                return true;
            else
                return false;


        }
        public int checkAppearObject(Rect before, Rect after, OpenCvSharp.Size matSz)
            /// <summary>
            /// check the object rect which is disappearing or appearing on edge location
            /// </summary>
            /// <param name="after">objecct rect current position</param>
            /// <param name="before">object rect previews position</param>
            /// <param name="matSz"> size of video frame </param>
        {
            var bef = this.isBorderRect(before, matSz);
            var aft = this.isBorderRect(after, matSz);

            if (bef && !aft)
                return 0;  // appear
            else if (!bef && aft)
            {
                this.isBorderRect(before, matSz);
                this.isBorderRect(after, matSz);
                return 1;  // disappear
            }
            else
                return 2;  // track
        }

    }
}
