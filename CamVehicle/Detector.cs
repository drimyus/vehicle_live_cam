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
        
        CascadeClassifier cascade;
        double dScaleFactor;
        int uMinNeighbors;
        Size minSize;

        Mat matGray = new Mat();

        public Detector()
        {
            cascade = new CascadeClassifier(@"..\..\cascade\cars.xml");

            dScaleFactor = 1.5;
            uMinNeighbors = 2;
            minSize = new Size(100, 100);
        }
        
        public Rect[] proc(Mat matFrame)
        {   
            
            Cv2.CvtColor(matFrame, matGray, ColorConversionCodes.BGRA2GRAY);
            Cv2.EqualizeHist(matGray, matGray);
            
            var cars = cascade.DetectMultiScale(
                image: matGray,
                scaleFactor: dScaleFactor,
                minNeighbors: uMinNeighbors,
                flags: HaarDetectionType.DoRoughSearch | HaarDetectionType.ScaleImage,
                minSize: minSize
                );
            
            Console.WriteLine("Detected cars: {0}", cars.Length);
            return cars;
        }

    }
}
