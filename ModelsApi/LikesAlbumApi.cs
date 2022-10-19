using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsApi
{
    public class LikesAlbumApi : ApiBaseType
    {
        public int? IdAlbum { get; set; }
        public int? IdUser { get; set; }
    }
}
