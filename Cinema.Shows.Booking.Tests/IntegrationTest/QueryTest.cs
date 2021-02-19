using Cinema.Shows.Booking.Repository.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cinema.Shows.Booking.Tests.IntegrationTest
{
    public class QueryTest
    {
        private CinemaDbContext _context;
        [SetUp]
        public void Setup()
        {
            var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkSqlServer()
            .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<CinemaDbContext>();

            builder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=test_1;Trusted_Connection=Yes;MultipleActiveResultSets=True;")
                    .UseInternalServiceProvider(serviceProvider);

            _context = new CinemaDbContext(builder.Options);
            _context.Database.Migrate();
        }

        [Test]
        [TestCase("123", "123")]
        public void GetUserByIdTest(string name, string expectedName)
        {
            var id = Guid.NewGuid();
            _context.User.Add(new Models.User { Name = name, Id = id });

            _context.SaveChanges();

            var query = new GetUserById(_context, id);
            var result = query.Execute();

            Assert.IsNotNull(result, "wrong result");
            Assert.IsTrue(result.Id == id, "wrong result");
            Assert.IsTrue(result.Name == expectedName, "wrong result");

            Dispose();
        }

        [Test]
        [TestCase(1, 1, 1, 1, 1, 1)]
        public void GetShowByIdTest(int id, int movieId, int roomId, int expectedId, int expectedMovieId, int expectedRoomId)
        {

            _context.Show.Add(new Models.Show { EndTime = DateTime.Now, MovieId = movieId, RoomId = roomId, StartTime = DateTime.Now });
            _context.SaveChanges();

            var query = new GetShowById(_context, id);
            var result = query.Execute();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id == expectedId, "wrong result");
            Assert.IsTrue(result.MovieId == expectedMovieId, "wrong result");
            Assert.IsTrue(result.RoomId == expectedRoomId, "wrong result");
            Dispose();
        }

        [Test]
        [TestCase(1, 1, 1, 1, 1, 1, 1)]
        public void GetSeatsByRoomIdTest(int id, int roomId, int seatNumber, int RowNumber, int expectedId, int expectedSeatNumber, int expectedRowNumber)
        {
            _context.Seat.Add(new Models.Seat { RoomId = roomId, SeatNumber = seatNumber, RowNumber = RowNumber });
            _context.SaveChanges();

            var query = new GetSeatsByRoomId(_context, id);
            var result = query.Execute().ToList();

            Assert.IsNotNull(result);
            Assert.IsTrue(result[0].Id == expectedId, "wrong result");
            Assert.IsTrue(result[0].SeatNumber == expectedSeatNumber, "wrong result");
            Assert.IsTrue(result[0].RowNumber == expectedRowNumber, "wrong result");
            Dispose();
        }

        [Test]
        [TestCase(1, 1, 1, 1, 1)]
        public void GetBookingsByShowListTest(int seatId, int showId, int expectedId, int expectedSeatId, int expectedShowId)
        {
            _context.Booking.Add(new Models.Booking { SeatId = seatId, ShowId = showId });
            _context.SaveChanges();

            var query = new GetBookingsByShowList(_context, new List<Int64>() { 1 });
            var result = query.Execute().ToList();

            Assert.IsNotNull(result);
            Assert.IsTrue(result[0].Id == expectedId, "wrong result");
            Assert.IsTrue(result[0].SeatId == expectedSeatId, "wrong result");
            Assert.IsTrue(result[0].ShowId == expectedShowId, "wrong result");
            Dispose();
        }

        [Test]
        [TestCase(1, 1, 1, 1, 1)]
        public void GetBookingsByShowIdTest(int seatId, int showId, int expectedId, int expectedSeatId, int expectedShowId)
        {
            _context.Booking.Add(new Models.Booking { SeatId = seatId, ShowId = showId });
            _context.SaveChanges();

            var query = new GetBookingsByShowId(_context, 1);
            var result = query.Execute().ToList();

            Assert.IsNotNull(result);
            Assert.IsTrue(result[0].Id == expectedId, "wrong result");
            Assert.IsTrue(result[0].SeatId == expectedSeatId, "wrong result");
            Assert.IsTrue(result[0].ShowId == expectedShowId, "wrong result");
            Dispose();
        }

        [Test]
        [TestCase(1, 1, 1, 1)]
        public void GetAvailableShowTest(int moveID, int roomID, int expectedMoveID, int expectedRoomID)
        {
            _context.Show.Add(new Models.Show { EndTime = DateTime.Now.AddDays(1), MovieId = moveID, RoomId = roomID, StartTime = DateTime.Now.AddDays(1) });
            _context.SaveChanges();

            var query = new GetAvailableShow(_context, DateTime.Now);
            var result = query.Execute().ToList();

            Assert.IsNotNull(result);
            Assert.IsTrue(result[0].MovieId == expectedMoveID, "wrong result");
            Assert.IsTrue(result[0].RoomId == expectedRoomID, "wrong result");
            Dispose();
        }

        [Test]
        [TestCase(1, 1, 1, 1, 1, 1)]
        public void GetAllSeatsByRoomIdListTest(int roomId, int rowNumber, int seatNumber, int expectedId, int expectedRowNumber, int expectedSeatNumber)
        {
            _context.Seat.Add(new Models.Seat { RoomId = roomId, RowNumber = rowNumber, SeatNumber = seatNumber });
            _context.SaveChanges();

            var query = new GetAllSeatsByRoomIdList(_context, new List<Int64>() { 1 });
            var result = query.Execute().ToList();


            Assert.IsNotNull(result);
            Assert.IsTrue(result[0].Id == expectedId, "wrong result");
            Assert.IsTrue(result[0].RowNumber == expectedRowNumber, "wrong result");
            Assert.IsTrue(result[0].SeatNumber == expectedSeatNumber, "wrong result");
            Dispose();
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
        }
    }
}
