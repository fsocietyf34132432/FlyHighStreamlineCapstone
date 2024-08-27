using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FlyHighStreamlineCapstone.Models;
using FlyHighStreamlineCapstone.ViewModel;

namespace FlyHighStreamlineCapstone.Data
{
    public class FlyHighStreamlineCapstoneContext : DbContext
    {
        public FlyHighStreamlineCapstoneContext (DbContextOptions<FlyHighStreamlineCapstoneContext> options)
            : base(options)
        {
        }

        public DbSet<FlyHighStreamlineCapstone.Models.Airline> Airline { get; set; } = default!;
        public DbSet<FlyHighStreamlineCapstone.Models.Aircraft> Aircraft { get; set; } = default!;
        public DbSet<FlyHighStreamlineCapstone.ViewModel.AircraftViewModel> AircraftViewModel { get; set; } = default!;
        public DbSet<FlyHighStreamlineCapstone.ViewModel.AirlineViewModel> AirlineViewModel { get; set; } = default!;
    }
}
