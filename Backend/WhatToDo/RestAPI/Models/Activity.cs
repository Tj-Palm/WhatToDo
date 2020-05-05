using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;



namespace RestApi.Models
{
    public class Activity
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public TimeSpan TimeUsage { get; set; }
        public string Type { get; set; }
        public bool Outdoor { get; set; }
    }
}
