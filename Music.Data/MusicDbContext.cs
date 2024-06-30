using Microsoft.EntityFrameworkCore;
using Music.Core.Model;
using Music.Data.Cofiguration;

namespace Music.Data
{
    public class MusicDbContext : DbContext
    {
        public MusicDbContext(DbContextOptions<MusicDbContext> options) : base(options)
        {
        }

        public DbSet<Track> Musics { get; set; }
        public DbSet<Artist> Artists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MusicConfiguration());
            modelBuilder.ApplyConfiguration(new ArtistCofiguration());
        }
    }
}
