using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsApi
{
    public class AlbumApi : ApiBaseType
    {
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public int TrackNumber { get; set; }

        public List<TrackApi> Trscks { get; set; }
        public UserApi User { get; set; }
    }
}
