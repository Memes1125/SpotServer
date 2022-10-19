using ModelsApi;
using System;

namespace SpotifyServer.db
{
    public partial class User
    {
        public static explicit operator UserApi(User user)
        {
            if (user == null)
                return null;
            return new UserApi
            {
                Id = user.Id,
                Email = user.Email,
                IdAlbums = user.IdAlbums,
                IdHistory = user.IdHistory,
                Image = user.Image,
                Name = user.Name,
                Password = user.Password,
            };
        }

        public static explicit operator User(UserApi user)
        {
            if (user == null)
                return null;
            return new User
            {
                Id = user.Id,
                Email = user.Email,
                IdAlbums = user.IdAlbums,
                IdHistory = user.IdHistory,
                Image = user.Image,
                Name = user.Name,
                Password = user.Password
            };
        }
    }
}
