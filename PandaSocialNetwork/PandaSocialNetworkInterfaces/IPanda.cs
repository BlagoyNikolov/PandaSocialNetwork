using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
