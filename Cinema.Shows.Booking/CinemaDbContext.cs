using Cinema.Shows.Booking.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Shows.Booking
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext(DbContextOptions<CinemaDbContext> option) : base(option)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Booking>().HasData(DatabaseInitializer.PopulateBookings());
            modelBuilder.Entity<Models.Movie>().HasData(DatabaseInitializer.PopulateMovies());
            modelBuilder.Entity<Models.Room>().HasData(DatabaseInitializer.PopulateRooms());
            modelBuilder.Entity<Models.Seat>().HasData(DatabaseInitializer.PopulateSeats());
            modelBuilder.Entity<Models.Show>().HasData(DatabaseInitializer.PopulateShows());
            modelBuilder.Entity<Models.User>().HasData(DatabaseInitializer.PopulateUsers());
            modelBuilder.Entity<Models.UserBooking>().HasData(DatabaseInitializer.PopulateUserBookings());
        }

        public virtual DbSet<Models.Booking> Booking { get; set; }
        public virtual DbSet<Models.Movie> Movie { get; set; }
        public virtual DbSet<Models.Room> Room { get; set; }
        public virtual DbSet<Models.Seat> Seat { get; set; }
        public virtual DbSet<Models.Show> Show { get; set; }
        public virtual DbSet<Models.User> User { get; set; }
        public virtual DbSet<Models.UserBooking> UserBooking { get; set; }
    }
}
