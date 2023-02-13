using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsApi
{
    public class TrackHistoryApi : ApiBaseType
    {
        public int IdTrack { get; set; }
        public int IdAlbum { get; set; }
        public int IdUser { get; set; }

    }
}
