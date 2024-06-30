using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Music.api.DTO;
using Music.api.Validators;
using Music.Core.Model;
using Music.Core.Services;

namespace Music.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IMusicService musicService;
        private readonly IMapper mapper;
        public MusicController(IMusicService _musicService,IMapper _mapper)
        {
            this.musicService = _musicService;
            this.mapper = _mapper;
        }
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Track>>> GetAllMusic()
        {
            var music = await musicService.GetAllWithArtist();
            var musicResources = mapper.Map<IEnumerable<MusicDTO>>(music);
            return Ok(musicResources);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<MusicDTO>> GetMusicById(int id) 
        { 
            var track = await musicService.GetMusicById(id);
            var musicResources = mapper.Map<Track, MusicDTO>(track);
            return Ok(musicResources);
        }

        [HttpPost]
        public async Task<ActionResult<MusicDTO>> CreateMusic(SaveMusicDTO saveMusiResources) 
        {
            var validator = new SaveMusicResourcesValidator();
            var validationResult = await validator.ValidateAsync(saveMusiResources);
            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);
            var music = mapper.Map<SaveMusicDTO, Track>(saveMusiResources);
            var newMusic = await musicService.CreateMusic(music);
            var musicFinal = await musicService.GetMusicById(newMusic.Id);
            var musicResources = mapper.Map<Track, MusicDTO>(musicFinal);
            return Ok(musicResources);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MusicDTO>> UpdateMusic(int id,SaveMusicDTO saveMusicResources)
        {
            var validator = new SaveMusicResourcesValidator();
            var validationResult = await validator.ValidateAsync(saveMusicResources);
            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);
            var musicOld = await musicService.GetMusicById(id);
            if (musicOld == null) return NotFound();
            var music = mapper.Map<SaveMusicDTO, Track>(saveMusicResources);
            await musicService.UpdateTrack(musicOld, music);
            var updatedMusic = await musicService.GetMusicById(id);
            var updatedMusicResources = mapper.Map<Track, MusicDTO>(updatedMusic);
            return Ok(updatedMusicResources);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusic(int id) 
        {
            if (id == 0) return BadRequest();
            var music = await musicService.GetMusicById(id);
            if (music == null) return NotFound();
            await musicService.DeleteTrack(music);
            return NoContent();
        }
    }
}
