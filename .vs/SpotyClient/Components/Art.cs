using ModelsApi;
using SpotyClient.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotyClient.Components
{
    public class Art : Notify
    {
        private ArtistApi entry;
        public ArtistApi Entry
        {
            get => entry;
            set
            {
                entry = value;
                SignalChanged();
            }
        }
    }
}
