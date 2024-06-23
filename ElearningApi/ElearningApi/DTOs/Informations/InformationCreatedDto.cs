using ElearningApi.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace ElearningApi.DTOs.Informations
{
    public class InformationCreatedDto
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public string IconClassName { get; set; }

        [SwaggerSchema(ReadOnly =true)]
        public InformationIcon ? InformationIcon { get; set; }

      
    }
}
