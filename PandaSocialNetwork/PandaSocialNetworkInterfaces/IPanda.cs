using System.Collections.Generic;

namespace PandaSocialNetworkInterfaces {
    public interface IPanda
    {

		string Name { get; set; }
        string Email { get; set; }
        GenderType Gender { get;set; }
        bool IsMale { get; }
        bool IsFemale { get; }
		List<int> Friends { get; set; } 

        string ToString();
        int GetHashCode();
        bool IsValidEmail(string Email);
    }
}
