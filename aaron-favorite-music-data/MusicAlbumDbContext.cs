using Microsoft.EntityFrameworkCore;
using aaron_favorite_music_domain;

namespace aaron_favorite_music_data
{
    public class MusicAlbumDbContext: DbContext
    {
        public MusicAlbumDbContext(DbContextOptions<MusicAlbumDbContext> options)
                    : base(options)
        {
            
        }
        public DbSet<MusicAlbum>  MusicAlbums { get; set; }
    }
}