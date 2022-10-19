using ModelsApi;
using System;

namespace SpotifyServer.db
{
    public partial class LikesAlbum
    {
        public static explicit operator LikesAlbumApi(LikesAlbum likesAlbum)
        {
            if (likesAlbum == null)
                return null;
            return new LikesAlbumApi
            {
                Id = likesAlbum.Id,
                IdAlbum = likesAlbum.IdAlbum,
                IdUser = likesAlbum.IdUser,
            };
        }

        public static explicit operator LikesAlbum(LikesAlbumApi likesAlbum)
        {
            if (likesAlbum == null)
                return null;
            return new LikesAlbum
            {
                Id = likesAlbum.Id,
                IdAlbum = likesAlbum.IdAlbum,
                IdUser = likesAlbum.IdUser,
            };
        }
    }
}
