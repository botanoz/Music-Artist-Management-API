using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Music.api.DTO;
using Music.api.Validators;
using Music.Core.Model;
using Music.Services;

namespace Music.api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly ArtistService artistService;
        private readonly IMapper mapper;
        public ArtistController(ArtistService _artistService, IMapper _mapper)
        {
            this.artistService = _artistService;
            this.mapper = _mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtistDTO>>> GetAllArtists()
        {
            var artists = await artistService.GetAllArtistsAsync();
            var artistResources = mapper.Map<IEnumerable<Artist>, IEnumerable<Artist>>(artists);
            return Ok(artistResources);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ArtistDTO>> GetArtistById(int id)
        {
            if (id == 0) return BadRequest();
            var artist = await artistService.GetArtistByIdAsync(id);
            if (artist == null) return NotFound();
            var artistResources = mapper.Map<Artist, ArtistDTO>(artist);
            return Ok(artistResources);
        }
        [HttpPost]
        public async Task<ActionResult<ArtistDTO>> CreateArtist([FromBody] SaveArtistDTO saveArtistResources)
        {
            var validator = new SaveArtistResourcesValidator();
            var validatorResult = await validator.ValidateAsync(saveArtistResources);
            if (!validatorResult.IsValid) return BadRequest(validatorResult.Errors);
            var artist = mapper.Map<SaveArtistDTO, Artist>(saveArtistResources);
            var newArtist = await artistService.CreateArtist(artist);
            var artistResource = await artistService.GetArtistByIdAsync(newArtist.Id);
            var newArtistResource = mapper.Map<Artist, ArtistDTO>(artistResource);
            return Ok(newArtist);

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ArtistDTO>> updateArtist(int id, SaveArtistDTO saveArtistResources)
        {
            var validator = new SaveArtistResourcesValidator();
            var validatorResult = await validator.ValidateAsync(saveArtistResources);
            if (!validatorResult.IsValid) return BadRequest();
            var artistToUpdate = await artistService.GetArtistByIdAsync(id);
            if (artistToUpdate == null) return NotFound();
            var artist = mapper.Map<SaveArtistDTO,Artist>(saveArtistResources);
            await artistService.UpdateArtist(artistToUpdate,artist);
            var updatedArtist = await artistService.GetArtistByIdAsync(artist.Id);
            var updatedArtistResource = mapper.Map<Artist, ArtistDTO>(updatedArtist);
            return Ok(updatedArtistResource);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtist(int id)
        {
            var artist = await artistService.GetArtistByIdAsync(id);
            if (artist == null) return NotFound();
            await artistService.DeleteArtist(artist);
            return NoContent();
        }
    }
}
