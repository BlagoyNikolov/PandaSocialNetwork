using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaSocialNetworkInterfaces {
    public interface ISocialNetwork {
        void AddPanda(IPanda panda);
        bool HasPanda(IPanda panda);
        void MakeFriends(IPanda panda1, IPanda panda2);
        bool AreFriends(IPanda panda1, IPanda panda2);
        List<IPanda> FriendsOf(IPanda panda);
        int ConnectionLevel(IPanda panda1, IPanda panda2);
        bool AreConnected(IPanda panda1, IPanda panda2);
        int HowManyGenderInNetwork(int level, IPanda panda, GenderType gender);
    }
}
