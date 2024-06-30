using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Music.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Data.Cofiguration
{
    public class ArtistCofiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.ToTable("Artists");
        }
    }
}
