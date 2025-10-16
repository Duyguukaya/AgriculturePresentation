using AgriculturePresentation.Models;
using ClosedXML.Excel;
using DataAccessLayer.Contexts;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace AgriculturePresentation.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StaticReport()
        {
            ExcelPackage.License.SetNonCommercialPersonal("Duygu Kaya");

            using (var excelPackage = new ExcelPackage())
            {

                var workBook = excelPackage.Workbook.Worksheets.Add("Dosya1");


                workBook.Cells[1, 1].Value = "Ürün Adı";
                workBook.Cells[1, 2].Value = "Ürün Kategorisi";
                workBook.Cells[1, 3].Value = "Ürün Stok";


                workBook.Cells[2, 1].Value = "Mercimek";
                workBook.Cells[2, 2].Value = "Bakliyat";
                workBook.Cells[2, 3].Value = "785 Kg";

                workBook.Cells[3, 1].Value = "Buğday";
                workBook.Cells[3, 2].Value = "Tahıl";
                workBook.Cells[3, 3].Value = "1500 Kg";

                workBook.Cells[4, 1].Value = "Havuç";
                workBook.Cells[4, 2].Value = "Sebze";
                workBook.Cells[4, 3].Value = "167 Kg";

                // Başlık hücrelerini kalın yap
                using (var range = workBook.Cells[1, 1, 1, 3])
                {
                    range.Style.Font.Bold = true;
                }

                // Tüm sütunları otomatik genişlet
                workBook.Cells.AutoFitColumns();

                // Dosyayı byte dizisine çevir
                var bytes = excelPackage.GetAsByteArray();

                // Excel dosyasını indirilebilir hale getir
                return File(bytes,
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    "BakliyatRaporu.xlsx");
            }
        }

        public List<ContactModel> ContactList()
        {
            List<ContactModel> contactModels = new List<ContactModel>();
            using (var context = new AgricultureContext())
            {
                contactModels = context.Contacts.Select(x => new ContactModel
                {
                    ContactId = x.ContactId,
                    ContactName = x.Name,
                    ContactMail = x.Mail,
                    ContactMessage = x.Message,
                    ContactDate = x.Date
                }).ToList();
            }

            return contactModels;
        }

        public IActionResult ContactReport()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Mesaj Listesi");
                workSheet.Cell(1, 1).Value = "Mesaj ID";
                workSheet.Cell(1, 2).Value = "Gönderen Adı";
                workSheet.Cell(1, 3).Value = "Gönderen Mail";
                workSheet.Cell(1, 4).Value = "Mesaj İçeriği";
                workSheet.Cell(1, 5).Value = "Mesaj Tarihi";

                int contactRowCount = 2;
                foreach (var item in ContactList())
                {
                    workSheet.Cell(contactRowCount, 1).Value = item.ContactId;
                    workSheet.Cell(contactRowCount, 2).Value = item.ContactName;
                    workSheet.Cell(contactRowCount, 3).Value = item.ContactMail;
                    workSheet.Cell(contactRowCount, 4).Value = item.ContactMessage;
                    workSheet.Cell(contactRowCount, 5).Value = item.ContactDate;
                    contactRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MesajRaporları.xlsx");
                }
            }

        }

        public List<AnnouncementModel> AnnouncementList()
        {
            List<AnnouncementModel> announcementModels = new List<AnnouncementModel>();
            using (var context = new AgricultureContext())
            {
                announcementModels = context.Announcements.Select(x => new AnnouncementModel
                {
                    AnnouncementId = x.AnnouncementId,
                    Title = x.Title,
                    Description = x.Description,
                    Date = x.Date,
                    Statues = x.Status

                }).ToList();
            }

            return announcementModels;
        }

        public IActionResult DuyuruReport()
        {
            ExcelPackage.License.SetNonCommercialPersonal("Duygu Kaya");

            using (var excelPackage = new ExcelPackage())
            {

                var workBook = excelPackage.Workbook.Worksheets.Add("Duyuru Listesi");


                workBook.Cells[1, 1].Value = "Duyuru Id";
                workBook.Cells[1, 2].Value = "Duyuru Başlığı";
                workBook.Cells[1, 3].Value = "Duyuru Tarihi";
                workBook.Cells[1, 4].Value = "Duyuru İçeriği";
                workBook.Cells[1, 5].Value = "Duyuru Durumu";

                int contactRowCount = 2;
                foreach (var item in AnnouncementList())
                {
                    workBook.Cells[contactRowCount, 1].Value = item.AnnouncementId;
                    workBook.Cells[contactRowCount, 2].Value = item.Title;
                    workBook.Cells[contactRowCount, 3].Value = item.Date.ToString("g");
                    workBook.Cells[contactRowCount, 4].Value = item.Description;
                    workBook.Cells[contactRowCount, 5].Value = item.Statues ? "Aktif" : "Pasif";
                    contactRowCount++;

                }


                // Başlık hücrelerini kalın yap
                using (var range = workBook.Cells[1, 1, 1, 3])
                {
                    range.Style.Font.Bold = true;
                }

                // Tüm sütunları otomatik genişlet
                workBook.Cells.AutoFitColumns();

                // Dosyayı byte dizisine çevir
                var bytes = excelPackage.GetAsByteArray();

                // Excel dosyasını indirilebilir hale getir
                return File(bytes,
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    "DuyuruRaporu.xlsx");
            }
        }


    }
}
