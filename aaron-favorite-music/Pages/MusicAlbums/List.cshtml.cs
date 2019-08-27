using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using aaron_favorite_music_data;
using aaron_favorite_music_domain;

namespace aaron_favorite_music.Pages.MusicAlbums
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IMusicAlbum musicAlbum;
        public string ConfigMessage { get; set; }

        [TempData]
        public string Message { get; set; }
        public IEnumerable<MusicAlbum> MusicAlbums { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config, IMusicAlbum musicAlbum)
        {
            this.musicAlbum = musicAlbum;
            this.config = config;
        }

        public void OnGet()
        {
            ConfigMessage = config["Message"];
            MusicAlbums = musicAlbum.GetAlbumByName(SearchTerm);
        }
    }
}