using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repository;
using DataAccessLayer.Contexts;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfAnnouncementDal : GenericRepository<Announcement>, IAnnouncementDal
    {
        public void AnnouncementStatuesToFalse(int id)
        {
            using var context = new AgricultureContext();
            Announcement values = context.Announcements.Find(id);
            values.Status = false;
            context.SaveChanges();
        }

        public void AnnouncementStatuesToTrue(int id)
        {
            using var context = new AgricultureContext();
            Announcement values = context.Announcements.Find(id);
            values.Status = true;
            context.SaveChanges();
        }
    }
}
