using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenCVnet.Lib;

namespace SampleRA.Test
{
    [TestClass]
    public class OpenCVnetTest
    {
        [TestMethod]
        public void TestDetourage()
        {
            Sample.Execute(Sample.GrayCapture, Tools.VideoPath);
        }

        [TestMethod]
        public void TestDetourageCamera()
        {
            Sample.Execute(Sample.GrayCapture);
        }

        [TestMethod]
        public void TestDetectFace()
        {
            Sample.Execute(Sample.DetectFace);
        }
    }
}
