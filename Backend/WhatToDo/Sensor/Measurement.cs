using System;

namespace Sensor
{
    public class Measurement
    {
        public DateTime MeasureTime { get; set; }
        public string Compound { get; set; }
        public double MeasurementValue { get; set; }


        public Measurement(DateTime measureTime, double measurementValue )
        {
            MeasureTime = measureTime;
            MeasurementValue = measurementValue;
        }

        public override string ToString()
        {
            return MeasureTime + " " + Compound + " " + MeasurementValue;
        }

        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}