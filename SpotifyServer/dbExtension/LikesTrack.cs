using ModelsApi;
using System;

namespace SpotifyServer.db
{
    public partial class LikesTrack
    {
        public static explicit operator LikesTrackApi(LikesTrack likesTrack)
        {
            if (likesTrack == null)
                return null;
            return new LikesTrackApi
            {
                Id = likesTrack.Id,
                IdTrack = likesTrack.Id,
                IdUser = likesTrack.IdUser,
            };
        }

        public static explicit operator LikesTrack(LikesTrackApi likesTrack)
        {
            if (likesTrack == null)
                return null;
            return new LikesTrack
            {
                Id = likesTrack.Id,
                IdTrack = likesTrack.Id,
                IdUser = likesTrack.IdUser,
            };
        }
    }
}
