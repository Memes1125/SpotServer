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
            TrackLines = new HashSet<TrackLine>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? IdHistory { get; set; }
        public int? IdAlbums { get; set; }
        public byte[] Image { get; set; }

        public virtual Album IdAlbumsNavigation { get; set; }
        public virtual TrackHistory IdHistoryNavigation { get; set; }
        public virtual ICollection<LikesAlbum> LikesAlbums { get; set; }
        public virtual ICollection<LikesTrack> LikesTracks { get; set; }
        public virtual ICollection<TrackLine> TrackLines { get; set; }
    }
}
