using System;
using System.Collections.Generic;
using System.Text;

namespace UDPreciever
{
    public class Sensordata
    {
        private DateTime _time;
        private int _grassLengt;

        public Sensordata()
        {

        }

        public Sensordata(DateTime time, int grassLengt)
        {
            _time = time;
            _grassLengt = grassLengt;
        }

        public DateTime Time
        {
            get => _time;
            set => _time = value;
        }

        public int GrassLengt
        {
            get => _grassLengt;
            set => _grassLengt = value;
        }
    }
}
