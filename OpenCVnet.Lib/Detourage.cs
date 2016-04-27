using OpenCV.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCVnet.Lib
{
    //test
    public class Detourage
    {
        public static void GrayDetour(string videofile = null)
        {
            if(string.IsNullOrEmpty(videofile))
            {
                using (var capture = Capture.CreateCameraCapture(0))
                {
                    GrayCapture(capture);
                }
            }
            else
            {
                using (var capture = Capture.CreateFileCapture(videofile))
                {
                    GrayCapture(capture);
                }
            }
        }


        private static void GrayCapture(Capture capture)
        {
            using (var window = new NamedWindow("test"))
            {
                while (CV.WaitKey(10) < 0) //laisse la main
                {
                    using (var src = capture.QueryFrame())// recupere une image
                    {
                        if (src == null)
                        {
                            break;
                        }
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
        }
    }
}
