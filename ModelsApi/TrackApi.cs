using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsApi
{
    public class TrackApi : ApiBaseType
    {
        public TimeSpan Duration { get; set; }
        public int IdAlbum { get; set; }
        public string Track1 { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }

        public IEnumerable<AlbumTrackApi> AlbumTracks { get; set; }
        public IEnumerable<ArtistsTrakApi> ArtistsTraks { get; set; }
        public IEnumerable<LikesTrackApi> LikesTracks { get; set; }
        public IEnumerable<TrackHistoryApi> TrackHistories { get; set; }
    }
}
