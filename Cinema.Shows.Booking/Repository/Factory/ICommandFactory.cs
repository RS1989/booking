using Cinema.Shows.Booking.Models;

namespace Cinema.Shows.Booking.Repository.Factory
{
    public interface ICommandFactory
    {
        void UserAdd(User user);
        Models.Booking BookingAdd(Models.Booking booking);
        void UserBookingAdd(Models.UserBooking userBooking);
    }
}