using System.Collections.Generic;
using aaron_favorite_music_domain;

namespace aaron_favorite_music_data
{
    public interface IMusicAlbium 
    {
        IEnumerable<MusicAlbum> GetAll();

    }

}