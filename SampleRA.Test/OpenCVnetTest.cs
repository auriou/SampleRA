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
            Detourage.GrayDetour(Tools.VideoPath);
        }

        [TestMethod]
        public void TestDetourageCamera()
        {
            Detourage.GrayDetour();
        }
    }
}
