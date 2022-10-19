using System;
using System.Collections.Generic;

#nullable disable

namespace SpotifyServer.db
{
    public partial class Album
    {
        public Album()
        {
            AlbumsArtists = new HashSet<AlbumsArtist>();
            LikesAlbums = new HashSet<LikesAlbum>();
            TrackHistories = new HashSet<TrackHistory>();
            TrackLines = new HashSet<TrackLine>();
            Tracks = new HashSet<Track>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public int TrackNumber { get; set; }

        public virtual ICollection<AlbumsArtist> AlbumsArtists { get; set; }
        public virtual ICollection<LikesAlbum> LikesAlbums { get; set; }
        public virtual ICollection<TrackHistory> TrackHistories { get; set; }
        public virtual ICollection<TrackLine> TrackLines { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
