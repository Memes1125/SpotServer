using System;
using System.Collections.Generic;

#nullable disable

namespace SpotifyServer.db
{
    public partial class AlbumsArtist
    {
        public int Id { get; set; }
        public int IdAlbums { get; set; }
        public int IdArtists { get; set; }

        public virtual Album IdAlbumsNavigation { get; set; }
        public virtual Artist IdArtistsNavigation { get; set; }
    }
}
