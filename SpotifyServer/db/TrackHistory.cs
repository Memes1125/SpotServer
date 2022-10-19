using System;
using System.Collections.Generic;

#nullable disable

namespace SpotifyServer.db
{
    public partial class TrackHistory
    {
        public TrackHistory()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public int IdTrack { get; set; }
        public int IdAlbum { get; set; }

        public virtual Album IdAlbumNavigation { get; set; }
        public virtual Track IdTrackNavigation { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
