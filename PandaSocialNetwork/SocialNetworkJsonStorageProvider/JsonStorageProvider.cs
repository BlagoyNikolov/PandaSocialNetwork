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
			var serializer = new JavaScriptSerializer();
			var serializedResult = serializer.Serialize(network.GetAllPandas().Select(PandaDTO.ConvertToDto));

			using (var sw = new StreamWriter("PandaNetwork.pandanet"))
			{
				sw.WriteLine(serializedResult);
			}
		}

		public ISocialNetwork Load()
		{
			var serializer = new JavaScriptSerializer();
			var jsonString = File.ReadAllText("PandaNetwork.pandanet");
			var deserializedResult = serializer.Deserialize<IEnumerable<PandaDTO>>(jsonString).Select(PandaDTO.ConvertToPanda);

			ISocialNetwork socialNetwork = new SocialNetwork();

			foreach (var panda in deserializedResult)
			{
				socialNetwork.AddPanda(panda);
			}

			return socialNetwork;
		}
	}
}
