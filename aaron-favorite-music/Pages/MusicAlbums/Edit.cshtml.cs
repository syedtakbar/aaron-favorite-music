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
        private readonly IMusicAlbum musicAlbumData;
        private readonly IHtmlHelper htmlHelper;


        [BindProperty]
        public MusicAlbum MusicAlbum { get; set; }
        public IEnumerable<SelectListItem>  Genres;  
        public EditModel(IMusicAlbum MusicAlbumInt, IHtmlHelper HtmlHelper)
        {
            this.musicAlbumData = MusicAlbumInt;
            htmlHelper = HtmlHelper;
        }
        public IActionResult OnGet(int? musicAlbumId)
        {
            Genres = htmlHelper.GetEnumSelectList<GenreType>();
            if (musicAlbumId.HasValue)
            {
                MusicAlbum = this.musicAlbumData.GetById(musicAlbumId.Value);               
            }
            else
            {
                MusicAlbum  = new MusicAlbum();
            }

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
                if (MusicAlbum.Id > 0)
                {
                    TempData["Message"] = "Album Saved!";
                    this.musicAlbumData.UpdateAlbum(MusicAlbum);
                }
                else
                {
                    TempData["Message"] = "Album Added!";
                    this.musicAlbumData.AddAlbum(MusicAlbum);
                }
                                             
                this.musicAlbumData.Commit();   
                return RedirectToPage("./Detail", new {musicAlbumId = MusicAlbum.Id});             
            }

            return Page();
        }
    }
}