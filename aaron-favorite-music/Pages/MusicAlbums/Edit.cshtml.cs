using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using aaron_favorite_music_data;
using aaron_favorite_music_domain;

namespace aaron_favorite_music.Pages.MusicAlbums
{
    public class EditModel : PageModel
    {
        private readonly IMusicAlbium musicAlbum;
        private readonly IHtmlHelper htmlHelper;

        public MusicAlbum MusicAlbum { get; set; }
        public IEnumerable<SelectListItem>  Genres;  
        public EditModel(IMusicAlbium MusicAlbum, IHtmlHelper HtmlHelper)
        {
            this.musicAlbum = MusicAlbum;
            htmlHelper = HtmlHelper;
        }
        public IActionResult OnGet(int musicAlbumId)
        {
            Genres = htmlHelper.GetEnumSelectList<GenreType>();
            MusicAlbum = this.musicAlbum.GetById(musicAlbumId);
            if (MusicAlbum == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}