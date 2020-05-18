using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestApi.Controllers;

namespace RestApi.Models
{
    public class InMemoryDbContext : DbContext
    {
        public InMemoryDbContext(DbContextOptions<InMemoryDbContext> options)
            : base(options)
        {
        }

        public DbSet<Activity> ActivityItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SensorData> Sensordatas { get; set; }
    }
}
