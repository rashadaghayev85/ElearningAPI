using ElearningApi.Models;

namespace ElearningApi.DTOs.Informations
{
    public class InformationDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconClassName { get; set; }
        public InformationIcon InformationIcon { get; set; }
        public int InformationIconId { get; set; }
    }
}
