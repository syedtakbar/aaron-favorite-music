using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using aaron_favorite_music_data;
using aaron_favorite_music_domain;

namespace aaron_favorite_music.Pages.MusicAlbums
{
    public class DetailModel : PageModel
    {

        [TempData]
        public string Message { get; set; }
        public MusicAlbum MusicAlbum { get; set; }
        private readonly IMusicAlbium musicAlbum;
        public DetailModel(IMusicAlbium musicAlbum)
        {
            this.musicAlbum = musicAlbum;
        }

        public IActionResult OnGet(int musicAlbumId)
        {
            MusicAlbum = musicAlbum.GetById(musicAlbumId);
            if (MusicAlbum == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}