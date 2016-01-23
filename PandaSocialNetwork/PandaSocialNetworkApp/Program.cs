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
            Console.WriteLine("The Panda Social Network");
            Console.WriteLine("List of commands:\n1. AddPanda(panda) - adds a panda to the network");
            Console.WriteLine("2. HasPanda(panda) - check if a panda is already registered in the network");
            Console.WriteLine("3. MakeFriends(panda1, panda2) - make two pandas friends");
            Console.WriteLine("4. AreFriends(panda1, panda2) - check if two pandas are already friends");
            Console.WriteLine("5. FriendsOf(panda) - returns a list of friends a panda has");
            Console.WriteLine("6. ConnectionLevel(panda1, panda2) -  returns the connection level between two pandas");
            Console.WriteLine("7. AreConnected(panda1, panda2) - checks if the pandas are connected somehow, between friends");
            Console.WriteLine("8. Save - placeholder");
            Console.WriteLine("9. Load - placeholder");
            Console.WriteLine("8. HowManyGenderInNetwork(level, panda, gender) - returns the number of gender pandas in that many levels deep");
            Console.WriteLine("11. exit - exits the application");

            bool flag = false;
            StringBuilder sb = new StringBuilder();
            var network = new SocialNetwork();

            while (!flag) {
                sb.Append(Console.ReadLine());

                if (sb.ToString().Contains("takebill")) {
                }
                else if (sb.ToString().Contains("takebatch")) {
                }
                else if (sb.ToString().Contains("takebatch")) {
                }
                else if (sb.ToString().Contains("takebatch")) {
                }
                else if (sb.ToString().Contains("takebatch")) {
                }
                else if (sb.ToString().Contains("takebatch")) {
                }
                else if (sb.ToString().Contains("takebatch")) {
                }
                else if (sb.ToString().Contains("takebatch")) {
                }
                else if (sb.ToString().Contains("takebatch")) {
                }
                else if (sb.ToString().Contains("takebatch")) {
                }
                else if (sb.ToString().Contains("takebatch")) {
                }

            }
            Panda blago = new Panda("Blago", "blago@pandamail.com", GenderType.Male);
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

            Console.WriteLine(blago.ToString());
            Console.WriteLine(rado.ToString());
            Console.WriteLine(tony.ToString());

            Console.WriteLine(network.AreFriends(blago, rado));
            Console.WriteLine(network.AreFriends(tony, rado));

            Console.WriteLine(network.ConnectionLevel(blago, rado));  // 1 true 
            Console.WriteLine(network.ConnectionLevel(blago, tony)); // 2 true

            Console.WriteLine(network.AreConnected(blago, tony));

            //network.HowManyGenderInNetwork(1, rado, GenderType.Female); // 1 true

            foreach (var item in network.FriendsOf(rado)) {
                Console.WriteLine(item.Name);
            }
            
            //while (!flag) {
            //    sb.Append(Console.ReadLine());

            //    if (sb.ToString().Contains("takebill")) {
            //        sb.Replace("takebill", "");
            //        int amount = -1;
            //        if (int.TryParse(sb.ToString(), out amount)) {
            //            if (amount == 5 || amount == 10 || amount == 20 || amount == 50 || amount == 100)
            //                desk.TakeMoney(new CashDesk.Bill(amount));
            //            else
            //                Console.WriteLine("That's not a valid bill", amount);
            //        }
            //        else
            //            Console.WriteLine("Input error");
            //    }
            //    else if (sb.ToString().Contains("takebatch")) {
            //        sb.Replace("takebatch", " ");
            //        List<CashDesk.Bill> listOfBills = new List<CashDesk.Bill>();
            //        string[] array = sb.ToString().Split(' ');
            //        int amount = -1;
            //        foreach (var bill in array) {
            //            if (int.TryParse(bill, out amount)) {
            //                if (amount == 5 || amount == 10 || amount == 20 || amount == 50 || amount == 100)
            //                    listOfBills.Add(new CashDesk.Bill(amount));
            //                else
            //                    Console.WriteLine("That's not a valid bill", amount);
            //            }
            //        }
            //        desk.TakeMoney(new CashDesk.BatchBill(listOfBills));
            //    }
            //    else if (sb.ToString().Contains("total")) {
            //        Console.WriteLine("Total balance: {0}$", desk.Total());
            //    }
            //    else if (sb.ToString().Contains("inspect")) {
            //        if (desk.Total() != 0)
            //            desk.Inspect();
            //        else
            //            Console.WriteLine("Cash Desk balance: 0$");
            //    }
            //    else if (sb.ToString().Contains("exit")) {
            //        flag = true;
            //        Console.WriteLine("Exiting...");
            //    }
            //    sb.Clear();
        }
    }
}

