using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsApi
{
    public class ArtistsTrakApi : ApiBaseType
    {
        public int IdTrack { get; set; }
        public int IdArtist { get; set; }

        public TrackApi Tracks { get; set; }
        public ArtistApi artists { get; set; }
    }
}
