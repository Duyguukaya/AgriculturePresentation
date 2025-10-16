namespace AgriculturePresentation.Models
{
    public class AnnouncementModel
    {
        public int AnnouncementId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool Statues { get; set; }
    }
}
