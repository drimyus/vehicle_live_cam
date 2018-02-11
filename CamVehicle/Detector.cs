using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenCvSharp;

namespace CamVehicle
{
    class Detector
    {
        // cascade Detector settings
        CascadeClassifier cascade;
        double dScaleFactor;
        int uMinNeighbors;
        Size minSize;

        // Blob Detector Settings
        Mat matGray = new Mat();
        Mat kernel;
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
            this.kernel = Cv2.GetStructuringElement(MorphShapes.Rect, new Size(11, 11));

        }
        
        public List<Rect> proc(Mat matFrame)
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
        {
            this.bckSub.Apply(matFrame, this.fgMask, 0.01);

            //Cv2.MedianBlur(this.fgMask, this.fgMask, 11);

            Cv2.Erode(this.fgMask, this.fgMask, kernel, iterations: 1);
            Cv2.Dilate(this.fgMask, this.fgMask, kernel, iterations: 2);

            Cv2.MorphologyEx(this.fgMask, this.fgMask, MorphTypes.Open, kernel);

            Cv2.Threshold(this.fgMask, this.fgMask, 100, 255, ThresholdTypes.Binary);

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



    }
}
