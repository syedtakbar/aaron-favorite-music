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
                                    Description = "Early Beatles",
                                    Artist = "Beatles",
                                    Genre = GenreType.rock,
                                    YearRelase = "1964"
                               },
                new MusicAlbum {
                                    Id = 2, 
                                    AlbumName = "Beatles for sale",
                                    Description = "Early Beatles",
                                    Artist = "Beatles",
                                    Genre = GenreType.rock,
                                    YearRelase = "1964"
                               },
                new MusicAlbum {
                                    Id = 3, 
                                    AlbumName = "Please please me",
                                    Description = "Early Beatles",
                                    Artist = "Beatles",
                                    Genre = GenreType.rock,
                                    YearRelase = "1963"
                               },                                                              

            };
        }
        public IEnumerable<MusicAlbum> GetAll()
        {
            return from r in musicAlbums
                    orderby r.AlbumName
                    select r;
        }
    }
}