using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCV.Net;

namespace OpenCVnet.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            //détourage
            using (var capture = Capture.CreateCameraCapture(0))
            {
                using (var window = new NamedWindow("test"))
                {
                    while (CV.WaitKey(10) < 0) //laisse la main
                    {
                        using (var src = capture.QueryFrame())// recupere une image
                        using (var gray = new IplImage(src.Size, IplDepth.U8, 1)) //filtre
                        using (var dstCanny = new IplImage(src.Size, IplDepth.U8, 1))
                        {
                            CV.CvtColor(src, gray, ColorConversion.Bgr2Gray);
                            CV.Canny(gray, dstCanny, 50, 50);
                            window.ShowImage(dstCanny);
                        }
                    }
                }
            }


            //var fileCapture = Capture.CreateFileCapture("/path/to/your/video/test.avi");
        }
    }
}
