using System;

namespace Sensor
{
    public class Measurement
    {
        public DateTime MeasureTime { get; set; }
        public double MeasurementValue { get; set; }


        public Measurement(DateTime measureTime, double measurementValue )
        {
            MeasureTime = measureTime;
            MeasurementValue = measurementValue;
        }

        public override string ToString()
        {
            return MeasureTime + " " + MeasurementValue;
        }
    }
}