using PandaSocialNetworkInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PandaSocialNetwork {
    public class Panda : IPanda {

        private string _email;

        private GenderType _gender;

        public Panda(string name, string email, GenderType gender) {
            Name = name;
            Email = email;
            Gender = gender;
            Friends = new List<int>();
        }

        public string Name { get; set; }

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

        public GenderType Gender { get; set; }

        public bool IsMale {
            get {
                return _gender == GenderType.Male;
            }
        }

        public bool IsFemale {
            get {
                return _gender == GenderType.Female;
            }
        }

        public List<int> Friends { get; set; }

        public override string ToString() {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("Panda: Name: {0}, Email: {1}, Gender: {2}, IsMale: {3}, IsFemale: {4}" + "\nNumber of friends: ", Name, Email, Gender, IsMale, IsFemale);
            output.Append(Friends.Count);
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
                return hash;
            }
        }

        public bool IsValidEmail(string email) {
            var expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
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
