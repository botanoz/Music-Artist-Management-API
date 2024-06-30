using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Music.Core;
using Music.Core.Model;
using Music.Core.Services;

namespace Music.Services;

public class ArtistService : IArtistService
{
    private readonly IUnitOfWork unitOfWork;
    public ArtistService(IUnitOfWork _unitOfWork)
    {
        this.unitOfWork = _unitOfWork;
    }

    public async Task<Artist> CreateArtist(Artist Newartist)
    {
        await unitOfWork.Artists.AddAsync(Newartist);
        await unitOfWork.CommitAsync();
        return Newartist;
    }

    public async Task DeleteArtist(Artist artist)
    {
        unitOfWork.Artists.Remove(artist);
        await unitOfWork.CommitAsync();
    }



    public async Task<IEnumerable<Artist>> GetAllArtistsAsync()
    {
        return await unitOfWork.Artists.GetAllAsync();
    }

    public async Task<Artist> GetArtistByIdAsync(int id)
    {
        return await unitOfWork.Artists.GetByIdAsync(id);
    }

    public async Task UpdateArtist(Artist ArtistToBeUpdate, Artist artist)
    {
        ArtistToBeUpdate.Name = artist.Name;
        await unitOfWork.CommitAsync();
    }
}

