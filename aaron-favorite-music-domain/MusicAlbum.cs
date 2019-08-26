using System;
using System.ComponentModel.DataAnnotations;

namespace aaron_favorite_music_domain
{
    public class MusicAlbum
    {
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string AlbumName { get; set; }
        [Required, StringLength(255)]
        public string Description { get; set; }

        [Required, StringLength(8)]        public string Artist { get; set; }
        public string YearRelase { get; set; }
        [Required]    
        public GenreType Genre { get; set; }

    }
}
