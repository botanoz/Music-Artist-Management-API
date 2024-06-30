using Microsoft.EntityFrameworkCore;
using Music.Core.Model;
using Music.Core.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Data.Repositoriys
{
    public class MusicRepository : Repository<Track>, IMusicRepository
    {
        private MusicDbContext MusicDbContext { get { return Context as MusicDbContext; } }
        public MusicRepository(MusicDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Track>> GetAllWithArtistAsync()
        {
            return await MusicDbContext.Musics.Include(x=>x.Artist).ToListAsync();
        }

        public async Task<IEnumerable<Track>> GetAllWithArtistByArtistIdAsync(int artistid)
        {
            return await MusicDbContext.Musics.Include(x => x.Artist).Where(x=>x.ArtistId==artistid).ToListAsync();
        }

        public async Task<Track> GetWithArtistByIdAsync(int id)
        {
            return await MusicDbContext.Musics.Include(x => x.Artist).SingleOrDefaultAsync();
        }
    }
}
