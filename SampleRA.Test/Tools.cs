using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleRA.Test
{
    public static class Tools
    {
        public static string DataPath
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            }
        }

        public static string VideoPath
        {
            get
            {
                return Path.Combine(DataPath, "bouncingBall.avi");
            }
        }
    }
}
