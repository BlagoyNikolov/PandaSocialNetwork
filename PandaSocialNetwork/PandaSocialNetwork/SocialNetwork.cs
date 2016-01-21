using System.Collections.Generic;
using PandaSocialNetworkInterfaces;

namespace PandaSocialNetwork
{
    class SocialNetwork : ISocialNetwork
    {
	    private Dictionary<string, IPanda> _pandaUsers;

	    public SocialNetwork()
	    {
		    _pandaUsers = new Dictionary<string, IPanda>();
		}

	    public void AddPanda(IPanda panda)
	    {
		    throw new System.NotImplementedException();
	    }

	    public bool HasPanda(IPanda panda)
	    {
		    throw new System.NotImplementedException();
	    }

	    public void MakeFriends(IPanda panda1, IPanda panda2)
	    {
		    throw new System.NotImplementedException();
	    }

	    public bool AreFriends(IPanda panda1, IPanda panda2)
	    {
		    throw new System.NotImplementedException();
	    }

	    public List<IPanda> FriendsOf(IPanda panda)
	    {
		    throw new System.NotImplementedException();
	    }

	    public int ConnectionLevel(IPanda panda1, IPanda panda2)
	    {
		    if (panda1 == panda2)
		    {
			    return 0;
		    }

		    var pending = new Queue<IPanda>();
			var visited = new List<IPanda>();

		    foreach (var currPanda in panda1.Friends)
		    {
			    var currConnection = ConnectionLevel(currPanda, panda2);

			    if (currConnection >= 0)
			    {
				    return currConnection + 1;
			    }
		    }

		    return -1;
	    }

	    public bool AreConnected(IPanda panda1, IPanda panda2)
	    {
		    return ConnectionLevel(panda1, panda2) > 0;
	    }

	    public int HowManyGenderInNetwork(int level, IPanda panda, GenderType gender)
	    {
		    return -1;
	    }
	}
}
