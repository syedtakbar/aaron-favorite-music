--Entity framework migration thru dotnet cli
-- dotnet ef dbcontext info -s ../aaron-favorite-music/aaron-favorite-music.csproj
-- dotnet ef migrations add initialcreate -s ../aaron-favorite-music/aaron-favorite-music.csproj 


use FavoriteMusic
select * from MusicAlbums