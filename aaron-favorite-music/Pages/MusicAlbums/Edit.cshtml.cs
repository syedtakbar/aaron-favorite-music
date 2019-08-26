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
        private readonly IMusicAlbium musicAlbumData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public MusicAlbum MusicAlbum { get; set; }
        public IEnumerable<SelectListItem>  Genres;  
        public EditModel(IMusicAlbium MusicAlbumInt, IHtmlHelper HtmlHelper)
        {
            this.musicAlbumData = MusicAlbumInt;
            htmlHelper = HtmlHelper;
        }
        public IActionResult OnGet(int musicAlbumId)
        {
            Genres = htmlHelper.GetEnumSelectList<GenreType>();
            MusicAlbum = this.musicAlbumData.GetById(musicAlbumId);
            if (MusicAlbum == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            //Console.WriteLine("OnPost executed!!!");
            Genres = htmlHelper.GetEnumSelectList<GenreType>();

            if (ModelState.IsValid)
            {           
                this.musicAlbumData.UpdateAlbum(MusicAlbum);            
                this.musicAlbumData.Commit();   
                return RedirectToPage("./Detail", new {musicAlbumId = MusicAlbum.Id});             
            }

            return Page();
        }
    }
}