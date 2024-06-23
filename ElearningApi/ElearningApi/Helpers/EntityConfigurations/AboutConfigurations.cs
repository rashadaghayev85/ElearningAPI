using ElearningApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElearningApi.Helpers.EntityConfigurations
{
    public class AboutConfigurations : IEntityTypeConfiguration<About>
    {

        public void Configure(EntityTypeBuilder<About> builder)
        {
            builder.Property(e => e.Title).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Description).IsRequired();
            builder.Property(e => e.Image).IsRequired();



        }

    }
}
