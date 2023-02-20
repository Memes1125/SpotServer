using ModelsApi;
using SpotyClient.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotyClient.Components
{
    public class ArtistProfile : Notify
    {
        public string Name { get => result.Name; set => result.Name = value; }
        public string Image { get => result.Image; set => result.Image = value; }
        static ArtistProfile instance;
        internal static ArtistProfile GetInstance()
        {
            if (instance == null)
                instance = new ArtistProfile();
            return instance;
        }

        ArtistApi result;

        internal void UpdateArtist(ArtistApi result)
        {
            this.result = result;
            SignalChanged(nameof(Name));
            SignalChanged(nameof(Image));
        }
    }
}
