﻿using System;
using System.Collections.Generic;

#nullable disable

namespace SpotifyServer.db
{
    public partial class LikesTrack
    {
        public int Id { get; set; }
        public int IdTrack { get; set; }
        public int IdUser { get; set; }

        public virtual Track IdTrackNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}