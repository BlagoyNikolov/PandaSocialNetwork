using System.Collections.Generic;

namespace PandaSocialNetworkInterfaces {
    public interface ISocialNetwork {
		Dictionary<int,IPanda> Pandas { get; }
        void AddPanda(IPanda panda);
        bool HasPanda(IPanda panda);
        void MakeFriends(IPanda panda1, IPanda panda2);
        bool AreFriends(IPanda panda1, IPanda panda2);
        List<IPanda> FriendsOf(IPanda panda);
        int ConnectionLevel(IPanda panda1, IPanda panda2);
        bool AreConnected(IPanda panda1, IPanda panda2);
        int HowManyGenderInNetwork(int level, IPanda panda, GenderType gender);
	    IEnumerable<IPanda> GetAllPandas();
    }
}
