using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaSocialNetworkInterfaces {
    public interface IPandaSocialNetworkStorageProvider {
        void Save(ISocialNetwork network);
        ISocialNetwork Load();
    }
}
