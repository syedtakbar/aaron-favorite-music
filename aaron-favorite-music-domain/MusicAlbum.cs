using System;

namespace aaron_favorite_music_domain
{
    public class MusicAlbum
    {
        public int Id { get; set; }
        public string AlbumName { get; set; }
        public string Description { get; set; }
        public string Artist { get; set; }
        public string YearRelase { get; set; }
        public GenreType Genre { get; set; }

    }
}
