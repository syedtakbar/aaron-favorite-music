using System.Collections.Generic;
using aaron_favorite_music_domain;

namespace aaron_favorite_music_data
{
    public interface IMusicAlbum 
    {
        IEnumerable<MusicAlbum> GetAlbumByName(string AlbumName);
        MusicAlbum GetById(int Id);
        MusicAlbum UpdateAlbum(MusicAlbum updatedMusicAlbum);
        MusicAlbum AddAlbum(MusicAlbum newMusicAlbum);
        
        MusicAlbum Delete(int Id);
        int GetCountOfMusicAlbums();
        int Commit();

    }

}