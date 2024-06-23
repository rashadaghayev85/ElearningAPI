namespace ElearningApi.Models
{
    public class Information:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public InformationIcon InformationIcon { get; set; }
        public int InformationIconId { get; set; }
    }
}
