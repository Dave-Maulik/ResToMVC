using OdeToRes.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToRes.Data.Services
{
    public class OdeToResDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
