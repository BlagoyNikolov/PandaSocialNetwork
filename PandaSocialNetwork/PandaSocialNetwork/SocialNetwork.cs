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
		    var pending = new Queue<PandaWithLevel>();
			var visited = new List<IPanda>();

			pending.Enqueue(new PandaWithLevel{Level = 0, Panda = panda1});

		    while (pending.Count > 0)
		    {
			    var currPanda = pending.Dequeue();
			    var connectionLevel = currPanda.Level + 1;

			    if (currPanda == panda2)
				    return connectionLevel;

			    if (!visited.Contains(currPanda.Panda))
			    {
				    visited.Add(currPanda.Panda);
			    }

			    foreach (var friend in currPanda.Panda.Friends)
			    {
				    pending.Enqueue(new PandaWithLevel {Level = connectionLevel, Panda = friend});
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
		    int pandasWithGender = 0;
			var pending = new Queue<PandaWithLevel>();
			var visited = new List<IPanda> {panda};
		    int connectionLevel = 0;

			pending.Enqueue(new PandaWithLevel { Level = 0, Panda = panda });

			while(pending.Count > 0 || connectionLevel <= level)
			{
				var currPanda = pending.Dequeue();
				connectionLevel = currPanda.Level + 1;

				if(!visited.Contains(currPanda.Panda))
				{
					visited.Add(currPanda.Panda);

					if (currPanda.Panda.Gender == gender)
						pandasWithGender++;
				}

				foreach(var friend in currPanda.Panda.Friends)
				{
					pending.Enqueue(new PandaWithLevel { Level = connectionLevel, Panda = friend });
				}
			}

			return pandasWithGender;
		}

	    public IEnumerable<IPanda> GetAllPandas()
	    {
		    return _pandaUsers.Values;
	    }

	    private class PandaWithLevel
	    {
		    public IPanda Panda;
		    public int Level;
	    }
	}
}
