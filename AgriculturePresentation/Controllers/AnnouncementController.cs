using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;

        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public IActionResult Index()
        {
            var values = _announcementService.GetListAll();
            return View(values);
        }

        public IActionResult AddAnnouncement()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAnnouncement(Announcement announcement)
        {
            announcement.Date = DateTime.Now;
            announcement.Status = false;
            _announcementService.Insert(announcement);
            return RedirectToAction("Index");
        }

        public IActionResult EditAnnouncement(int id)
        {
            var values = _announcementService.GetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditAnnouncement(Announcement announcement)
        {
            _announcementService.Update(announcement);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAnnouncement(int id)
        {
            var value = _announcementService.GetById(id);
            _announcementService.Delete(value);
            return RedirectToAction("Index");
        }

        public IActionResult ChangesStatusToTrue(int id)
        {
            _announcementService.AnnouncementStatuesToTrue(id);
            return RedirectToAction("Index");
        }

        public IActionResult ChangeStatusToFalse(int id)
        {
            _announcementService.AnnouncementStatuesToFalse(id);
            return RedirectToAction("Index");
        }
    }
}
