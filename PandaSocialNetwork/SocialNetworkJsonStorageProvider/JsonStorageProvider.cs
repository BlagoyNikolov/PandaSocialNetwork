using System.Collections.Generic;
using System.IO;
using System.Linq;
using PandaSocialNetworkInterfaces;
using System.Web.Script.Serialization;
using PandaSocialNetwork;

namespace SocialNetworkJsonStorageProvider
{
	public class JsonStorageProvider : IPandaSocialNetworkStorageProvider
	{
		public void Save(ISocialNetwork network)
		{
			var pandas = network.GetAllPandas();

			WritePandas(pandas, "PandaNetwork.pandanet");
			WriteConnections(pandas, "PandaNetworkConnections.pandanetconn");
		}

		public ISocialNetwork Load()
		{
			ISocialNetwork socialNetwork = new SocialNetwork();

			LoadPandas(socialNetwork, "PandaNetwork.pandanet");
			var connections = ReadConnections("PandaNetworkConnections.pandanetconn");

			foreach (var connection in connections)
			{
				var currPanda = socialNetwork.Pandas[connection.Key];
				currPanda.Friends.AddRange(connection.Value);
			}

			return socialNetwork;
		}

		private static void WritePandas(IEnumerable<IPanda> pandas, string filename)
		{
			var serializer = new JavaScriptSerializer();
			var pandasList = pandas.Select(PandaDTO.ConvertToDto);
			var serializedResult = serializer.Serialize(pandasList.ToList());

			using(var sw = new StreamWriter(filename))
			{
				sw.WriteLine(serializedResult);
			}
		}

		private static void WriteConnections(IEnumerable<IPanda> pandas, string filename)
		{
			using(var sw = new StreamWriter(filename))
			{
				foreach(var panda in pandas)
				{
					sw.WriteLine(panda.GetHashCode());

					foreach(var friend in panda.Friends)
					{
						sw.WriteLine(friend.GetHashCode());
					}

					sw.WriteLine("END");
				}
			}
		}

		private static void LoadPandas(ISocialNetwork network, string filename)
		{
			var serializer = new JavaScriptSerializer();
			var jsonString = File.ReadAllText(filename);
			var deserializedResult = serializer.Deserialize<IEnumerable<PandaDTO>>(jsonString).Select(PandaDTO.ConvertToPanda);

			foreach(var panda in deserializedResult)
			{
				network.AddPanda(panda);
			}
		}

		private Dictionary<int, List<int>> ReadConnections(string filename)
		{
			var connections = new Dictionary<int, List<int>>();

			using (var sr = new StreamReader(filename))
			{
				string line = null;
				var currKey = -1;
				var reading = false;

				while ((line = sr.ReadLine()) != null)
				{
					if (!reading)
					{
						currKey = int.Parse(line);
						connections.Add(currKey,new List<int>());
						reading = true;
					}
					else
					{
						if (line == "END")
						{
							reading = false;
							continue;
						}
						else
			{
							connections[currKey].Add(int.Parse(line));
						}
					}
				}
			}

			return connections;
		}
	}
}
