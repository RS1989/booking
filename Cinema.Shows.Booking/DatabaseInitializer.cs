using Cinema.Shows.Booking.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Shows.Booking
{
    public class DatabaseInitializer
    {
        public static List<Movie> PopulateMovies()
        {
            var result = new List<Movie>();
            result.Add(new Movie { Id = 1, Name = "Interstallar" });
            result.Add(new Movie { Id = 2, Name = "Lord Of the Rings (I, II, III)" });
            result.Add(new Movie { Id = 3, Name = "Harry Potter" });
            return result;
        }

        public static List<Room> PopulateRooms()
        {
            var result = new List<Room>();
            result.Add(new Room { Id = 1, Name = "ROOM I" });
            result.Add(new Room { Id = 2, Name = "ROOM II" });
            result.Add(new Room { Id = 3, Name = "ROOM III" });
            return result;
        }

        public static List<Seat> PopulateSeats()
        {
            var result = new List<Seat>();
            result.Add(new Seat { Id = 1, RoomId = 1, RowNumber = 1, SeatNumber = 1 });
            result.Add(new Seat { Id = 2, RoomId = 1, RowNumber = 1, SeatNumber = 2 });
            result.Add(new Seat { Id = 3, RoomId = 1, RowNumber = 1, SeatNumber = 3 });
            result.Add(new Seat { Id = 4, RoomId = 1, RowNumber = 1, SeatNumber = 4 });
            result.Add(new Seat { Id = 5, RoomId = 1, RowNumber = 1, SeatNumber = 5 });
            result.Add(new Seat { Id = 6, RoomId = 1, RowNumber = 2, SeatNumber = 1 });
            result.Add(new Seat { Id = 7, RoomId = 1, RowNumber = 2, SeatNumber = 2 });
            result.Add(new Seat { Id = 8, RoomId = 1, RowNumber = 2, SeatNumber = 3 });
            result.Add(new Seat { Id = 9, RoomId = 1, RowNumber = 2, SeatNumber = 4 });
            result.Add(new Seat { Id = 10, RoomId = 1, RowNumber = 2, SeatNumber = 5 });
            result.Add(new Seat { Id = 11, RoomId = 2, RowNumber = 1, SeatNumber = 1 });
            result.Add(new Seat { Id = 12, RoomId = 2, RowNumber = 1, SeatNumber = 2 });
            result.Add(new Seat { Id = 13, RoomId = 2, RowNumber = 1, SeatNumber = 3 });
            result.Add(new Seat { Id = 14, RoomId = 2, RowNumber = 1, SeatNumber = 4 });
            result.Add(new Seat { Id = 15, RoomId = 2, RowNumber = 1, SeatNumber = 5 });
            result.Add(new Seat { Id = 16, RoomId = 2, RowNumber = 2, SeatNumber = 1 });
            result.Add(new Seat { Id = 17, RoomId = 2, RowNumber = 2, SeatNumber = 2 });
            result.Add(new Seat { Id = 18, RoomId = 2, RowNumber = 2, SeatNumber = 3 });
            result.Add(new Seat { Id = 19, RoomId = 2, RowNumber = 2, SeatNumber = 4 });
            result.Add(new Seat { Id = 20, RoomId = 2, RowNumber = 2, SeatNumber = 5 });
            result.Add(new Seat { Id = 21, RoomId = 3, RowNumber = 1, SeatNumber = 1 });
            result.Add(new Seat { Id = 22, RoomId = 3, RowNumber = 1, SeatNumber = 2 });
            result.Add(new Seat { Id = 23, RoomId = 3, RowNumber = 1, SeatNumber = 3 });
            result.Add(new Seat { Id = 24, RoomId = 3, RowNumber = 1, SeatNumber = 4 });
            result.Add(new Seat { Id = 25, RoomId = 3, RowNumber = 1, SeatNumber = 5 });
            result.Add(new Seat { Id = 26, RoomId = 3, RowNumber = 2, SeatNumber = 1 });
            result.Add(new Seat { Id = 27, RoomId = 3, RowNumber = 2, SeatNumber = 2 });
            result.Add(new Seat { Id = 28, RoomId = 3, RowNumber = 2, SeatNumber = 3 });
            result.Add(new Seat { Id = 29, RoomId = 3, RowNumber = 2, SeatNumber = 4 });
            result.Add(new Seat { Id = 30, RoomId = 3, RowNumber = 2, SeatNumber = 5 });
            return result;
        }

        public static List<Show> PopulateShows()
        {
            var result = new List<Show>();
            result.Add(new Show { Id = 1, MovieId = 1, RoomId = 1, StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(2) });
            result.Add(new Show { Id = 2, MovieId = 2, RoomId = 2, StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(10) });
            result.Add(new Show { Id = 3, MovieId = 3, RoomId = 3, StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(10) });
            return result;
        }

        public static List<User> PopulateUsers()
        {
            var result = new List<User>();
            result.Add(new User { Id = new Guid("{EFE8EF95-B030-452B-925F-7C2F69CE5C05}"), Name = "User 1" });
            result.Add(new User { Id = new Guid("{8DA6675B-C1DE-4520-8E9C-B5678430883E}"), Name = "User 2" });
            result.Add(new User { Id = new Guid("{91B63266-9E79-45A1-BD57-74A08BA621B7}"), Name = "User 3" });
            return result;
        }

        public static List<Models.Booking> PopulateBookings()
        {
            var result = new List<Models.Booking>();
            result.Add(new Models.Booking { Id = 1, SeatId = 1, ShowId = 1 });
            result.Add(new Models.Booking { Id = 2, SeatId = 12, ShowId = 2 });
            result.Add(new Models.Booking { Id = 3, SeatId = 21, ShowId = 3 });
            return result;
        }

        public static List<UserBooking> PopulateUserBookings()
        {
            var result = new List<UserBooking>();
            result.Add(new UserBooking { Id = 1, BookingId = 1, UserId = new Guid("{EFE8EF95-B030-452B-925F-7C2F69CE5C05}") });
            result.Add(new UserBooking { Id = 2, BookingId = 2, UserId = new Guid("{8DA6675B-C1DE-4520-8E9C-B5678430883E}") });
            result.Add(new UserBooking { Id = 3, BookingId = 3, UserId = new Guid("{91B63266-9E79-45A1-BD57-74A08BA621B7}") });
            return result;
        }
    }
}
