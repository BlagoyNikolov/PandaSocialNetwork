using PandaSocialNetworkInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PandaSocialNetwork {
    class Panda : IPanda {
        private string _email; 

        public string Name { get; private set; }

        public string Email {
            get {
                return _email;
            }
            set {
                if (IsValidEmail(value)) {
                    _email = value;
                }         
            }
        }

        public GenderType Gender { get; private set; }

        public bool IsMale { get; private set; }

        public bool IsFemale { get; private set; }

        public List<IPanda> Friends { get; private set; }

        public override string ToString() {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("Panda: Name: {0}, Email: {1}, Gender: {2}, IsMale: {3}, IsFemale: {4} + \nList of friends:\n", Name, Email, Gender, IsMale, IsFemale);
            foreach (var item in Friends) {
                output.Append(item + " ");
            }
            return output.ToString();
        }

        public override int GetHashCode() {
            unchecked {
                int hash = 17;
                hash = hash * 23 + Name.GetHashCode();
                hash = hash * 23 + Email.GetHashCode();
                hash = hash * 23 + Gender.GetHashCode();
                hash = hash * 23 + IsMale.GetHashCode();
                hash = hash * 23 + IsFemale.GetHashCode();
                hash = hash * 23 + Friends.GetHashCode();
                return hash;
            }
        }

        public bool IsValidEmail(string email) {
            string expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion)) {
                if (Regex.Replace(email, expresion, string.Empty).Length == 0) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return false;
            }
        }
    }
}
