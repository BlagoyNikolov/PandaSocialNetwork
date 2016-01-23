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

		internal static PandaDTO ConvertToDto(IPanda panda)
		{
			return new PandaDTO {Name = panda.Name, Email = panda.Email, Gender = panda.Gender};
		}

		internal static IPanda ConvertToPanda(PandaDTO dto)
		{
			return new Panda(dto.Name,dto.Email,dto.Gender);
		}
	}
}
