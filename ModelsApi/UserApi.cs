﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsApi
{
    public class UserApi : ApiBaseType
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] Image { get; set; }


        public IEnumerable<TrackHistoryApi> TrackHistories { get; set; }
        public IEnumerable<UserAlbumApi> UserAlbums { get; set; }
    }
}