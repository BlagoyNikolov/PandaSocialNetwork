using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PandaSocialNetwork;
using PandaSocialNetworkInterfaces;

namespace PandaSocialNetworkApp {
    class Program {
        static void Main(string[] args) {
            var network = new SocialNetwork();
            Panda blago = new Panda("Ivo", "ivo@pandamail.com", GenderType.Male);
            Panda rado = new Panda("Rado", "rado@pandamail.com", GenderType.Male);
            Panda tony = new Panda("Tony", "tony@pandamail.com", GenderType.Female);
            Console.WriteLine(blago.ToString()); 
            Console.WriteLine(rado.ToString());
            Console.WriteLine(tony.ToString()); 

            network.AddPanda(blago);
            network.AddPanda(rado);
            network.AddPanda(tony);

            network.MakeFriends(blago, rado);
            network.MakeFriends(rado, tony);

            //network.ConnectionLevel(blago, rado); // 1 true
            //network.ConnectionLevel(blago, tony); // 2 true

            //network.HowManyGenderInNetwork(1, rado, GenderType.Female); // 1 true
        }
    }
}
