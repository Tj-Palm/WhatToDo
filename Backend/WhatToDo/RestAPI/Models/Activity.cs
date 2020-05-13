using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;



namespace RestApi.Models
{
    public class Activity
    {
        private int _id;
        private string _name;
        private int _timeInterval;
        private string _type;
        private string _environment;

        public Activity()
        {
        }

        public Activity(string name, int timeInterval, string type, string environment)
        {
            _name = name;
            _timeInterval = timeInterval;
            _type = type;
            _environment = environment;
        }

        [Key]
        public int id
        {
            get => _id;
            set => _id = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
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
