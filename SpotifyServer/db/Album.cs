using System;
using System.Collections.Generic;

#nullable disable

namespace SpotifyServer.db
{
    public partial class Album
    {
        public Album()
        {
            AlbumTracks = new HashSet<AlbumTrack>();
            AlbumsArtists = new HashSet<AlbumsArtist>();
            LikesAlbums = new HashSet<LikesAlbum>();
            TrackHistories = new HashSet<TrackHistory>();
            UserAlbums = new HashSet<UserAlbum>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public string Image { get; set; }

        public virtual ICollection<AlbumTrack> AlbumTracks { get; set; }
        public virtual ICollection<AlbumsArtist> AlbumsArtists { get; set; }
        public virtual ICollection<LikesAlbum> LikesAlbums { get; set; }
        public virtual ICollection<TrackHistory> TrackHistories { get; set; }
        public virtual ICollection<UserAlbum> UserAlbums { get; set; }
    }
}
