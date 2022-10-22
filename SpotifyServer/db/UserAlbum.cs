using System;
using System.Collections.Generic;

#nullable disable

namespace SpotifyServer.db
{
    public partial class UserAlbum
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdAlbum { get; set; }

        public virtual Album IdAlbumNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
