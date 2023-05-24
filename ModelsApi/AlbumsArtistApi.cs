using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsApi
{
    public  class AlbumsArtistApi : ApiBaseType
    {
        public int IdAlbums { get; set; }
        public int IdArtists { get; set; }

        public AlbumApi Albums { get; set; }
    }
}
