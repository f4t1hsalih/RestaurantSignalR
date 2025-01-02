using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;

namespace DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(Context context) : base(context)
        {
        }

        public void BookingStatusApproved(int id)
        {
            var value = _context.Bookings.Find(id);
            value.Description = "Rezervasyon Onaylandı";
            _context.SaveChanges();
        }

        public void BookingStatusCancelled(int id)
        {
            var value = _context.Bookings.Find(id);
            value.Description = "Rezervasyon İptal Edildi";
            _context.SaveChanges();
        }
    }
}
