using System;
using System.Collections.Generic;

#nullable disable

namespace SpotifyServer.db
{
    public partial class User
    {
        public User()
        {
            LikesAlbums = new HashSet<LikesAlbum>();
            LikesTracks = new HashSet<LikesTrack>();
            TrackHistories = new HashSet<TrackHistory>();
            UserAlbums = new HashSet<UserAlbum>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] Image { get; set; }

        public virtual ICollection<LikesAlbum> LikesAlbums { get; set; }
        public virtual ICollection<LikesTrack> LikesTracks { get; set; }
        public virtual ICollection<TrackHistory> TrackHistories { get; set; }
        public virtual ICollection<UserAlbum> UserAlbums { get; set; }
    }
}
