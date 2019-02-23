using RSS.Data.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace RSS.Data.Mapping
{
   public class URLMap
    {
        public URLMap(EntityTypeBuilder<URL> entityBuilder)
        {
            entityBuilder.HasKey(p => p.ID);
            entityBuilder.HasMany(p => p.RSSFeeds).WithOne(e => e.URL)
                .HasForeignKey(c=>c.URLID);
            entityBuilder.ToTable("URL");

        }
    }
}
