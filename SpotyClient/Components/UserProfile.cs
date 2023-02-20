using ModelsApi;
using SpotyClient.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotyClient.Components
{
    public class UserProfile : Notify
    {
        public string Name { get => result.Name; set => result.Name = value; }
        public string Image { get => result.Image; set => result.Image = value; }
        static UserProfile instance;
        internal static UserProfile GetInstance()
        {
            if (instance == null)
                instance = new UserProfile();
            return instance;
        }

        UserApi result;

        internal void UpdateUser(UserApi result)
        {
            this.result = result;
            SignalChanged(nameof(Name));
            SignalChanged(nameof(Image));
        }
    }
}
