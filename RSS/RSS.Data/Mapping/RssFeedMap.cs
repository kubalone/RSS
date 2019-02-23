using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RSS.Data.Model;

namespace RSS.Data.Mapping
{
   public class RssFeedMap
    {
        public RssFeedMap(EntityTypeBuilder<RssFeed> entityBuilder)
        {
            entityBuilder.HasKey(p => p.ID);
            entityBuilder.Property(p => p.PubDate)
                .HasColumnType("datetime2");
            entityBuilder.ToTable("RssFeed");
        }  
    }
}
