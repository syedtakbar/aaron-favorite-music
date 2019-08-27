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
    public class DeleteModel : PageModel
    {

        public MusicAlbum MusicAlbum { get; set; }
        private readonly IMusicAlbum musicAlbum;

        public DeleteModel(IMusicAlbum musicAlbumData)
        {
            this.musicAlbum = musicAlbumData;
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

        public IActionResult OnPost(int musicAlbumId)
        {
            var deleteAlbum = musicAlbum.Delete(musicAlbumId);
            musicAlbum.Commit();

            if (deleteAlbum == null)
            {
                 return RedirectToPage("./NotFound");

            }

            TempData["Message"] = $"{deleteAlbum.AlbumName} deleted!";
            return RedirectToPage("./List");
        }
    }
}