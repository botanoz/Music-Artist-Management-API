using Music.Core.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IMusicRepository Musics { get; }
        IArtistRepository Artists { get; }
        Task<int> CommitAsync();
    }
}
