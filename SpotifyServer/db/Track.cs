using System;
using System.Collections.Generic;

#nullable disable

namespace SpotifyServer.db
{
    public partial class Track
    {
        public Track()
        {
            AlbumTracks = new HashSet<AlbumTrack>();
            ArtistsTraks = new HashSet<ArtistsTrak>();
            LikesTracks = new HashSet<LikesTrack>();
            TrackHistories = new HashSet<TrackHistory>();
        }

        public int Id { get; set; }
        public TimeSpan Duration { get; set; }
        public string Track1 { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public virtual ICollection<AlbumTrack> AlbumTracks { get; set; }
        public virtual ICollection<ArtistsTrak> ArtistsTraks { get; set; }
        public virtual ICollection<LikesTrack> LikesTracks { get; set; }
        public virtual ICollection<TrackHistory> TrackHistories { get; set; }
    }
}
