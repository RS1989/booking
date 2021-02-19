using Cinema.Shows.Booking.Repository.Factory;
using Cinema.Shows.Booking.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Cinema.Shows.Booking.Services;

namespace Cinema.Shows.Booking.Tests.UniteTests
{
    public class BookingServiceTests
    {
        private Mock<ICommandFactory> _commandFcatory;
        private Mock<IQueryFactory> _queryFcatory;
        private IBookingService _service;

        [SetUp]
        public void Setup()
        {
            _commandFcatory = new Mock<ICommandFactory>();
            _queryFcatory = new Mock<IQueryFactory>();
            _service = new BookingService(_commandFcatory.Object, _queryFcatory.Object);
        }

        [Test]
        [TestCase(1, "123", "123", 1, 1)]
        public void GetAvailableShowTest(int expectedCount, string expectedMovieName, string expectedRoomName, int expectedRowNumber, int expectedSeatNumber)
        {
            _queryFcatory.Setup(q => q.GetAvailableShow(It.IsAny<DateTime>())).Returns(new List<Show>() 
            { 
                new Show()
                { 
                    Id = 1, 
                    RoomId = 1, 
                    Movie = new Movie
                    { 
                        Name = "123"
                    },
                    Room = new Room
                    {
                        Name = "123"
                    }                    
                } 
            }.AsQueryable());
            _queryFcatory.Setup(q => q.GetBookingsByShowList(It.IsAny<List<Int64>>())).Returns(new List<Models.Booking>() { }.AsQueryable());
            _queryFcatory.Setup(q => q.GetAllSeatsByRoomIdList(It.IsAny<List<Int64>>())).Returns(new List<Models.Seat>() 
            { 
                new Seat() 
                {
                    Id = 1,
                    RoomId = 1, 
                    RowNumber = 1,
                    SeatNumber = 1 
                } 
            }.AsQueryable());

            var result = _service.GetAvailableShow(DateTime.Now);
            Assert.IsNotNull(result, "Wrong result");
            Assert.IsTrue(result.Count() == expectedCount, "Wrong result");
            Assert.IsNotNull(result[0], "Wrong result");
            Assert.IsTrue(result[0].MovieName == expectedMovieName, "Wrong result");
            Assert.IsTrue(result[0].RoomName == expectedRoomName, "Wrong result");
            Assert.IsTrue(result[0].Seats[0].RowNumber == expectedRowNumber, "Wrong result");
            Assert.IsTrue(result[0].Seats[0].SeatNumber == expectedSeatNumber, "Wrong result");
        }

        [Test]
        [TestCase(1, "123", "123", 1, 1)]
        [TestCase(2, "123", "123", 1, 1)]
        public void GetAvailableSeatForShow(Int64 id, string expectedMovieName, string expectedRoomName, int expectedRowNumber, int expectedSeatNumber)
        {
            _queryFcatory.Setup(q => q.GetShowById(It.IsAny<Int64>())).Returns(
                new Show()
                {
                    Id = 1,
                    RoomId = 1,
                    Movie = new Movie
                    {
                        Name = "123"
                    },
                    Room = new Room
                    {
                        Name = "123"
                    }
                }
           );

            _queryFcatory.Setup(q => q.GetSeatsByRoomId(It.IsAny<Int64>())).Returns(
               new List<Seat>() 
               {
                   new Seat 
                   {
                       Id = 1,
                       RoomId = 1,
                       RowNumber = 1, 
                       SeatNumber = 1
                   }
               }.AsQueryable()
           );
            _queryFcatory.Setup(q => q.GetBookingsByShowId(It.IsAny<Int64>())).Returns(new List<Models.Booking>() { }.AsQueryable());

            var result = _service.GetAvailableSeatForShow(id);
            Assert.IsNotNull(result, "Wrong result");            
            Assert.IsTrue(result.MovieName == expectedMovieName, "Wrong result");
            Assert.IsTrue(result.RoomName == expectedRoomName, "Wrong result");
            Assert.IsTrue(result.Seats[0].RowNumber == expectedRowNumber, "Wrong result");
            Assert.IsTrue(result.Seats[0].SeatNumber == expectedSeatNumber, "Wrong result");
        }
    }
}
