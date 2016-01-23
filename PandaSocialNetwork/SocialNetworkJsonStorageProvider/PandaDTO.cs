using System.Collections.Generic;
using PandaSocialNetwork;
using PandaSocialNetworkInterfaces;

namespace SocialNetworkJsonStorageProvider
{
	internal class PandaDTO
	{
		string Name { get; set; }
		string Email { get; set; }
		GenderType Gender { get; set; }

		internal static PandaDTO ConvertToDtos(IPanda panda)
		{
			return new PandaDTO {Name = panda.Name, Email = panda.Email, Gender = panda.Gender};
		}

		internal static IPanda ConvertToPanda(PandaDTO dto)
		{
//			Panda
			return new Panda();
		}
	}
}
