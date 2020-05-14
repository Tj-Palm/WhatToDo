namespace RestApi.Models
{
    public class ActivityParameter
    {
        private int _timeInterval;
        private string _type;
        private string _environment;

        public ActivityParameter()
        {
        }

        public ActivityParameter(int timeInterval, string type, string environment)
        {
            
            _timeInterval = timeInterval;
            _type = type;
            _environment = environment;
        }

        public int TimeInterval
        {
            get => _timeInterval;
            set => _timeInterval = value;
        }

        public string ActivityLevel
        {
            get => _type;
            set => _type = value;
        }

        public string Environment
        {
            get => _environment;
            set => _environment = value;
        }
    }
}