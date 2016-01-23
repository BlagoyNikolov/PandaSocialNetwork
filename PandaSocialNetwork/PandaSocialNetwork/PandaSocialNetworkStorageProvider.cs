using System;
using System.IO;
using PandaSocialNetworkInterfaces;

namespace PandaSocialNetwork
{
    public class PandaSocialNetworkStorageProvider : IPandaSocialNetworkStorageProvider
	{
	    public ISocialNetwork Load()
	    {
			 throw new NotImplementedException();
	    }

	    public void Save(ISocialNetwork network)
	    {
		    using (var sr = new StreamReader("pandasave.pandanet"))
		    {
			    
		    }
		}
	}
}
