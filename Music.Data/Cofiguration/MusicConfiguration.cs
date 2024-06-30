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
    public class MusicConfiguration : IEntityTypeConfiguration<Track>
    {
        public void Configure(EntityTypeBuilder<Track> builder)
        {
            builder.HasKey(x=> x.Id);
            builder.Property(x=>x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.HasOne(x => x.Artist).WithMany(x => x.Musics).HasForeignKey(x => x.ArtistId);
            builder.ToTable("Musics");
        }
    }
}
