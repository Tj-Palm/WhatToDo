using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Models
{
    public class SensorData
    {
        private DateTime _time;
        private int _grassLengt;
        private int _id;

        public SensorData()
        {
            
        }

        public SensorData(DateTime time, int grassLengt, int id)
        {
            _time = time;
            _grassLengt = grassLengt;
            _id = id;
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

        [Key]
        public int Id
        {
            get => _id;
            set => _id = value;
        }
    }
}
