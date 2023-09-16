using HoteleriaBack.Domain.Entities;
using HoteleriaBack.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace HoteleriaBack.Infrastructure.Base
{
    public class TravelContext : DbContext
    {

        public DbSet<Client> Clients { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<EmergencyContact> EmergencyContacts { get; set; }
        public DbSet<Location> Locations { get; set; }

        public TravelContext(DbContextOptions<TravelContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasKey(x => x.Id);

            modelBuilder.Entity<Hotel>().HasKey(x => x.Id);
            modelBuilder.Entity<Hotel>().HasOne(x => x.User);
            modelBuilder.Entity<Hotel>().HasOne(x => x.Location);

            modelBuilder.Entity<Room>().HasKey(x => x.Id);
            modelBuilder.Entity<Room>().HasOne(x => x.Hotel);

            modelBuilder.Entity<Reservation>().HasKey(x => x.Id);
            modelBuilder.Entity<Reservation>().HasOne(x => x.Client);
            modelBuilder.Entity<Reservation>().HasOne(x => x.User);
            modelBuilder.Entity<Reservation>().HasOne(x => x.Hotel);

            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<EmergencyContact>().HasKey(x => x.Id);
            modelBuilder.Entity<Location>().HasKey(x => x.Id);
        }
    }
}
