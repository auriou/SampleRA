using OpenCV.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCVnet.Lib
{
    public class Sample
    {
        public static void Execute(Action<Capture> function, string videofile = null)
        {
            if(string.IsNullOrEmpty(videofile))
            {
                using (var capture = Capture.CreateCameraCapture(0))
                {
                    function(capture);
                }
            }
            else
            {
                using (var capture = Capture.CreateFileCapture(videofile))
                {
                    function(capture);
                }
            }
        }


        public static void GrayCapture(Capture capture)
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

        public static void DetectFace(Capture capture)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "haarcascades_cuda", "haarcascade_frontalface_alt.xml");

            var cascade = HaarClassifierCascade.Load(path);
            var storage = new MemStorage();
            var size = new Size(40, 40);


            using (var window = new NamedWindow("test"))
            {
                while (CV.WaitKey(10) < 0)
                {
                    using (var image = capture.QueryFrame())
                    {
                        if (image == null)
                        {
                            break;
                        }

                        var faces = cascade.DetectObjects(image, storage, 1.1, 3, 0, size);

                        foreach (var rect in faces.ToArray<Rect>())
                        {
                            CV.Rectangle(image, new Point(rect.X, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height), new Scalar(255, 0, 0), 1, LineFlags.Connected8, 0);
                            window.ShowImage(image);
                        }
                    }
                }
            }
        }
    }
}
