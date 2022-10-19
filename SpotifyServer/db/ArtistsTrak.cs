using System;
using System.Collections.Generic;

#nullable disable

namespace SpotifyServer.db
{
    public partial class ArtistsTrak
    {
        public int Id { get; set; }
        public int IdTrack { get; set; }
        public int IdArtist { get; set; }

        public virtual Artist IdArtistNavigation { get; set; }
        public virtual Track IdTrackNavigation { get; set; }
    }
}
