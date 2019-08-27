using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using aaron_favorite_music_data;
using aaron_favorite_music_domain;

namespace aaron_favorite_music.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicAlbumsController : ControllerBase
    {
        private readonly MusicAlbumDbContext _context;

        public MusicAlbumsController(MusicAlbumDbContext context)
        {
            _context = context;
        }

        // GET: api/MusicAlbums
        [HttpGet]
        public IEnumerable<MusicAlbum> GetMusicAlbums()
        {
            Console.WriteLine("controller called!");
            return _context.MusicAlbums;
        }

        // GET: api/MusicAlbums/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMusicAlbum([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var musicAlbum = await _context.MusicAlbums.FindAsync(id);

            if (musicAlbum == null)
            {
                return NotFound();
            }

            return Ok(musicAlbum);
        }

        // PUT: api/MusicAlbums/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMusicAlbum([FromRoute] int id, [FromBody] MusicAlbum musicAlbum)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != musicAlbum.Id)
            {
                return BadRequest();
            }

            _context.Entry(musicAlbum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusicAlbumExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MusicAlbums
        [HttpPost]
        public async Task<IActionResult> PostMusicAlbum([FromBody] MusicAlbum musicAlbum)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MusicAlbums.Add(musicAlbum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMusicAlbum", new { id = musicAlbum.Id }, musicAlbum);
        }

        // DELETE: api/MusicAlbums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusicAlbum([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var musicAlbum = await _context.MusicAlbums.FindAsync(id);
            if (musicAlbum == null)
            {
                return NotFound();
            }

            _context.MusicAlbums.Remove(musicAlbum);
            await _context.SaveChangesAsync();

            return Ok(musicAlbum);
        }

        private bool MusicAlbumExists(int id)
        {
            return _context.MusicAlbums.Any(e => e.Id == id);
        }
    }
}