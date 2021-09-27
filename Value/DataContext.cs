using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DataContext : DbContext
    {
        

            public DbSet<Value> Values { get; set; }
            public DbSet<Activity> Activities { get; set; }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("server=localhost;database=Reactivities;uid=admin2;pwd=minhquan");
            }
            
            
    }
}
