using System;
using System.Collections.Generic;
using PandaSocialNetwork;
using PandaSocialNetworkInterfaces;

namespace SocialNetworkJsonStorageProvider
{
	[Serializable]
	internal class PandaDTO
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public GenderType Gender { get; set; }

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
