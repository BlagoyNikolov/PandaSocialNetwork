using System;
using PandaSocialNetwork;
using PandaSocialNetworkInterfaces;
using SocialNetworkJsonStorageProvider;

namespace PandaSocialNetworkApp {
    class Program {
        static void Main(string[] args) {
            var network = new SocialNetwork();
            Panda blago = new Panda("Ivo", "blago@pandamail.com", GenderType.Male);
            Panda rado = new Panda("Rado", "rado@pandamail.com", GenderType.Male);
            Panda tony = new Panda("Tony", "tony@pandamail.com", GenderType.Female);
            Console.WriteLine(blago.ToString()); 
            Console.WriteLine(rado.ToString());
            Console.WriteLine(tony.ToString());

            Console.WriteLine(network.HasPanda(blago));

            network.AddPanda(blago);
            network.AddPanda(rado);
            network.AddPanda(tony);

            Console.WriteLine(network.HasPanda(blago));

            network.MakeFriends(blago, rado);
            network.MakeFriends(rado, tony);

            Console.WriteLine(network.AreFriends(blago, rado));
            Console.WriteLine(network.AreFriends(tony, rado));

			Console.WriteLine(network.ConnectionLevel(blago, rado));
			Console.WriteLine(network.ConnectionLevel(blago, tony));

            Console.WriteLine(network.HowManyGenderInNetwork(1, rado, GenderType.Female)); // 1 true

			var provider = new JsonStorageProvider();
			provider.Save(network);

        }
    }
}
