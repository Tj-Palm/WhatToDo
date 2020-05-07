namespace RestApi.Models
{
    public class ActivityParameter
    {
        private int _timeUsage;
        private string _type;
        private string _environment;

        public ActivityParameter()
        {
        }

        public ActivityParameter(int timeUsage, string type, string environment)
        {
            
            _timeUsage = timeUsage;
            _type = type;
            _environment = environment;
        }

        public int TimeUsage
        {
            get => _timeUsage;
            set => _timeUsage = value;
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