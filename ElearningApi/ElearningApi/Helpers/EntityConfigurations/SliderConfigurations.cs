using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ElearningApi.Models;

namespace ElearningApi.Helpers.EntityConfigurations
{
    public class SliderConfigurations : IEntityTypeConfiguration<Slider>
    {
      
            public void Configure(EntityTypeBuilder<Slider> builder)
            {
                builder.Property(e => e.Title).IsRequired().HasMaxLength(100);
                builder.Property(e => e.Description).IsRequired();
                builder.Property(e => e.Image).IsRequired();



            }
        
    }
}
