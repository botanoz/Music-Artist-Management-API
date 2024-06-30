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
    internal class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        private MusicDbContext MusicDbContext { get { return Context as MusicDbContext; } }
        public ArtistRepository(MusicDbContext context) : base(context)
        {
           
        }

        public async Task<IEnumerable<Artist>> GetAllWithMusicAsync()
        {
            return await MusicDbContext.Artists
                   .Include(a => a.Musics)
                   .ToListAsync();
        }

        public Task<Artist> GetWithMusicByIdAsync(int id)
        {
            return MusicDbContext.Artists.Include(x => x.Musics).SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
