using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsApi
{
    public class UserAlbumApi : ApiBaseType
    {
        public int IdUser { get; set; }
        public int IdAlbum { get; set; }
    }
}
