using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IAnnouncementService:IGenericService<Announcement>
    {
        void AnnouncementStatuesToTrue(int id);
        void AnnouncementStatuesToFalse(int id);
    }
}
