using Music.Core;
using Music.Core.Repositorys;
using Music.Data.Repositoriys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MusicDbContext context;
        private MusicRepository musicRepository;
        private ArtistRepository artistsRepository;
        public UnitOfWork(MusicDbContext _context)
        {
            context = _context;
        }
        IMusicRepository IUnitOfWork.Musics => musicRepository = musicRepository ?? new MusicRepository(context);

        IArtistRepository IUnitOfWork.Artists => artistsRepository = artistsRepository ?? new ArtistRepository(context);

        public async Task<int> CommitAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
