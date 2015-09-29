using System;

namespace Eagle.ViewModel
{
    public class HeartbeatBody
    {

        public double MaxNum { get; set; }

        public double AvgNum { get; set; }

        public DateTime LogTime { get; set; }

        public int HourTime { get; set; }

        public double MaxMemory { get; set; }

        public double AvgMemory { get; set; }
    }
}