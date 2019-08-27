using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using aaron_favorite_music_domain;

namespace aaron_favorite_music_data
{
    public class SqlMusicAlbumData : IMusicAlbum
    {
        private readonly MusicAlbumDbContext db;

        public SqlMusicAlbumData(MusicAlbumDbContext dbCtx)
        {
            this.db = dbCtx;
        }
        public MusicAlbum AddAlbum(MusicAlbum newMusicAlbum)
        {
            db.MusicAlbums.Add(newMusicAlbum);
            return newMusicAlbum;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public MusicAlbum Delete(int Id)
        {
            var album = GetById(Id);
            if (album != null)
            {
                db.MusicAlbums.Remove(album);
            }
            return album;
        }

        public IEnumerable<MusicAlbum> GetAlbumByName(string AlbumName)
        {
            var data= from r in db.MusicAlbums
                    where string.IsNullOrEmpty(AlbumName) || r.AlbumName.StartsWith(AlbumName)
                    orderby r.AlbumName
                    select r;
            return data;
        }

        public MusicAlbum GetById(int Id)
        {
            return db.MusicAlbums.Find(Id);
        }

        public int GetCountOfMusicAlbums()
        {
            return db.MusicAlbums.Count();
        }

        public MusicAlbum UpdateAlbum(MusicAlbum updatedMusicAlbum)
        {
            var entity = db.MusicAlbums.Attach(updatedMusicAlbum);
            entity.State = EntityState.Modified;
            return updatedMusicAlbum;
        }
    }
}