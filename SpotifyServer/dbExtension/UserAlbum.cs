using ModelsApi;
using System;

namespace SpotifyServer.db
{
    public partial class UserAlbum
    {
        public static explicit operator UserAlbumApi(UserAlbum userAlbum)
        {
            if (userAlbum == null)
                return null;
            return new UserAlbumApi
            {
                Id = userAlbum.Id,
                IdAlbum = userAlbum.IdAlbum,
                IdUser = userAlbum.IdUser,
            };
        }

        public static explicit operator UserAlbum(UserAlbumApi userAlbum)
        {
            if (userAlbum == null)
                return null;
            return new UserAlbum
            {
                Id = userAlbum.Id,
                IdAlbum = userAlbum.IdAlbum,
                IdUser = userAlbum.IdUser,
            };
        }
    }
}
