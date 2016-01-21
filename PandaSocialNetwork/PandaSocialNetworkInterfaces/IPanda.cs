using System.Collections.Generic;

namespace PandaSocialNetworkInterfaces {
    public interface IPanda {
        string Name { get; }
        string Email { get; }
        GenderType Gender { get; }
        bool IsMale { get; }
        bool IsFemale { get; }
		List<IPanda> Friends { get; } 

        string ToString();
        int GetHashCode();
        bool IsValidEmail(string Email);
    }
}
