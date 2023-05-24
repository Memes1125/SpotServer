using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsApi
{
    public class LikesTrackApi : ApiBaseType
    {
        public int IdTrack { get; set; }
        public int IdUser { get; set; }

        public TrackApi traksL { get; set; }
    }
}
