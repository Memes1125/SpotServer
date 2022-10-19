using System;
using System.Collections.Generic;

#nullable disable

namespace SpotifyServer.db
{
    public partial class Track
    {
        public Track()
        {
            ArtistsTraks = new HashSet<ArtistsTrak>();
            LikesTracks = new HashSet<LikesTrack>();
            TrackHistories = new HashSet<TrackHistory>();
            TrackLines = new HashSet<TrackLine>();
        }

        public int Id { get; set; }
        public TimeSpan Duration { get; set; }
        public int IdAlbum { get; set; }
        public string Track1 { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }

        public virtual Album IdAlbumNavigation { get; set; }
        public virtual ICollection<ArtistsTrak> ArtistsTraks { get; set; }
        public virtual ICollection<LikesTrack> LikesTracks { get; set; }
        public virtual ICollection<TrackHistory> TrackHistories { get; set; }
        public virtual ICollection<TrackLine> TrackLines { get; set; }
    }
}
