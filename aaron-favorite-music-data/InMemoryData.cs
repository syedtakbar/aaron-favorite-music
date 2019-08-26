using System;
using System.Collections.Generic;
using System.Linq;
using aaron_favorite_music_domain;
namespace aaron_favorite_music_data
{
    public class InMemoryData : IMusicAlbium
    {
        readonly List<MusicAlbum> musicAlbums;
        public InMemoryData()
        {
            musicAlbums = new List<MusicAlbum>()
            {
                new MusicAlbum {
                                    Id = 1, 
                                    AlbumName = "Hard Days Night",
                                    Description = "One of the best early album",
                                    Artist = "Beatles",
                                    Genre = GenreType.rock,
                                    YearRelase = "1964"
                               },
                new MusicAlbum {
                                    Id = 2, 
                                    AlbumName = "Beatles for sale",
                                    Description = "First U.S. album?",
                                    Artist = "Beatles",
                                    Genre = GenreType.rock,
                                    YearRelase = "1964"
                               },
                new MusicAlbum {
                                    Id = 3, 
                                    AlbumName = "Please please me",
                                    Description = "Very first album",
                                    Artist = "Beatles",
                                    Genre = GenreType.rock,
                                    YearRelase = "1963"
                               },   
                new MusicAlbum {
                                    Id = 4, 
                                    AlbumName = "Help!",
                                    Description = "Right after Hard days night",
                                    Artist = "Beatles",
                                    Genre = GenreType.rock,
                                    YearRelase = "1965"
                               },                                                              


            };
        }
        public IEnumerable<MusicAlbum> GetAlbumByName(string AlbumName = null)
        {
            
            return from r in musicAlbums
                    where string.IsNullOrEmpty(AlbumName) || r.AlbumName.StartsWith(AlbumName)
                    orderby r.AlbumName
                    select r;
        }

        public MusicAlbum GetById(int Id)
        {
            
            return musicAlbums.SingleOrDefault(r => r.Id == Id);
        }

        public MusicAlbum UpdateAlbum (MusicAlbum updatedAlbum)
        {
            //Console.WriteLine($"updating album id: {updatedAlbum.Id}");
            var album = musicAlbums.SingleOrDefault(x => x.Id == updatedAlbum.Id);
            if (album != null)
            {
                album.AlbumName = updatedAlbum.AlbumName;
                album.Description = updatedAlbum.Description;
                album.YearRelase = updatedAlbum.YearRelase;
                album.Genre = updatedAlbum.Genre;
            }
            return album;
        }

        public int Commit()
        {
            return 0;
        }
    }
}