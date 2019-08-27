using System;
using Microsoft.AspNetCore.Mvc;
using aaron_favorite_music_data;
namespace aaron_favorite_music.ViewComponents
{
     public class MusicAlbumCountViewComponent : ViewComponent
     {
        private readonly IMusicAlbum musicAlbumData;

        public MusicAlbumCountViewComponent(IMusicAlbum musicAlbumData)
        {
            this.musicAlbumData = musicAlbumData;
        }

        public IViewComponentResult Invoke ()
        {   
            var count = musicAlbumData.GetCountOfMusicAlbums();
            return View(count);    
        }
    }
}