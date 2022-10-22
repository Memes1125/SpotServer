using System;
using System.Collections.Generic;

#nullable disable

namespace SpotifyServer.db
{
    public partial class AlbumTrack
    {
        public int Id { get; set; }
        public int IdTrack { get; set; }
        public int IdAlbum { get; set; }

        public virtual Album IdAlbumNavigation { get; set; }
        public virtual Track IdTrackNavigation { get; set; }
    }
}
