using Cinema.Shows.Booking.Repository.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Cinema.Shows.Booking.Services
{
    public class BookingService: IBookingService
    {
        private readonly ICommandFactory _commandFactory;
        private readonly IQueryFactory _queryFactory;

        public BookingService(ICommandFactory commandFactory, IQueryFactory queryFactory)
        {
            _commandFactory = commandFactory;
            _queryFactory = queryFactory;
        }

        public List<Models.Business.Show> GetAvailableShow(DateTime startTime)
        {
            var shows = _queryFactory.GetAvailableShow(startTime);
            var showIds = shows.Select(s => s.Id).ToList();
            var bookings = _queryFactory.GetBookingsByShowList(showIds);
            var roomIds = shows.Select(s=> s.RoomId).ToList();
            var seats = _queryFactory.GetAllSeatsByRoomIdList(roomIds);
            var bookedSeats = bookings.Select(b => b.SeatId);
            var availableSeats = seats.Where(s => !bookedSeats.Contains(s.Id)).ToList();

            var result = new List<Models.Business.Show>();

            foreach (var show in shows)
            {
                var showResult = new Models.Business.Show();
                showResult.MovieName = show.Movie.Name;
                showResult.RoomName = show.Room.Name;
                showResult.Seats = availableSeats.Select(s => new Models.Business.Seat() { RowNumber = s.RowNumber, SeatNumber = s.SeatNumber }).ToList();
                result.Add(showResult);
            }

            return result;
        }

        public Models.Business.Show GetAvailableSeatForShow(Int64 id)
        {
            var show = _queryFactory.GetShowById(id);
            var seatsInRoom = _queryFactory.GetSeatsByRoomId(id);
            var bookings = _queryFactory.GetBookingsByShowId(show.Id);
            var bookedSeats = bookings.Select(b => b.SeatId);
            var availableSeats = seatsInRoom.Where(s => !bookedSeats.Contains(s.Id));

            var result = new Models.Business.Show();
            result.MovieName = show.Movie.Name;
            result.RoomName = show.Room.Name;
            result.Seats = availableSeats.Select(s => new Models.Business.Seat() { RowNumber = s.RowNumber, SeatNumber = s.SeatNumber }).ToList();

            return result;
        }

        public void BookShow(Guid? userId, string userName, Int64 showId, List<Int64> seatIds)
        {
            var user = _queryFactory.GetUserById(userId.GetValueOrDefault());
            if (user == null) 
            {
                _commandFactory.UserAdd(new Models.User() { Id = userId.GetValueOrDefault(), Name = userName });
            }
            foreach (var seat in seatIds)
            {
                var booking = _commandFactory.BookingAdd(new Models.Booking() { SeatId = seat, ShowId = showId });
                _commandFactory.UserBookingAdd(new Models.UserBooking() { BookingId = booking.Id, UserId = userId.GetValueOrDefault() });
            }
            
        }
    }
}
