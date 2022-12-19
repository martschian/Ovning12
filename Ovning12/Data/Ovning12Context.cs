using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ovning12.Models;

namespace Ovning12.Data
{
    public class Ovning12Context : DbContext
    {
        public Ovning12Context (DbContextOptions<Ovning12Context> options)
            : base(options)
        {
        }

        public DbSet<Ovning12.Models.ParkedVehicle> ParkedVehicle { get; set; } = default!;
    }
}
