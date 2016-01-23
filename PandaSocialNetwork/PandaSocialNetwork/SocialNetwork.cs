using System.Collections.Generic;
using PandaSocialNetworkInterfaces;
using System;

namespace PandaSocialNetwork {
    public class SocialNetwork : ISocialNetwork {
        private Dictionary<int, IPanda> _pandaUsers;

        public SocialNetwork() {
            _pandaUsers = new Dictionary<int, IPanda>();
        }

        public void AddPanda(IPanda panda) {
            if (_pandaUsers.ContainsKey(panda.GetHashCode())) throw new PandaAlreadyThereException();
            else _pandaUsers.Add(panda.GetHashCode(), panda);
        }

        public bool HasPanda(IPanda panda) {
            return _pandaUsers.ContainsKey(panda.GetHashCode());
        }

        public void MakeFriends(IPanda panda1, IPanda panda2) {
            bool alredyFriends = true;
            if (!_pandaUsers.ContainsKey(panda1.GetHashCode())) {
                _pandaUsers.Add(panda1.GetHashCode(), panda1);
                alredyFriends = false;
            }
            //else panda1 = _pandaUsers[panda1.GetHashCode()];

            if (!_pandaUsers.ContainsKey(panda2.GetHashCode())) {
                _pandaUsers.Add(panda2.GetHashCode(), panda2);
                alredyFriends = false;
            }
            //else panda2 = _pandaUsers[panda2.GetHashCode()];

            if (!panda1.Friends.Contains(panda2)) {
                panda1.Friends.Add(panda2);
                panda2.Friends.Add(panda1);
            } else {
                throw new PandasAlreadyFriendsException();
            }
            

            //if (alredyFriends) throw new PandasAlreadyFriendsException();
            //else {
            //    if (!panda1.Friends.Contains(panda2)) {
            //        panda1.Friends.Add(panda2);
            //        panda2.Friends.Add(panda1);
            //    }
            //}
        }

        public bool AreFriends(IPanda panda1, IPanda panda2) {
            if (HasPanda(panda1) && HasPanda(panda2)) {
                if (_pandaUsers[panda1.GetHashCode()].Friends.Contains(panda2) && _pandaUsers[panda2.GetHashCode()].Friends.Contains(panda1)) {
                    return true;
                }
            }
            return false;
        }

        public List<IPanda> FriendsOf(IPanda panda) {
            if (!_pandaUsers.ContainsKey(panda.GetHashCode())) {
                throw new PandasNotAMemberOfTheSocialNetwork();
            }
            else {
                return panda.Friends;
            }
        }

        public int ConnectionLevel(IPanda panda1, IPanda panda2) {
            var pending = new Queue<PandaWithLevel>();
            var visited = new List<IPanda>();

            pending.Enqueue(new PandaWithLevel { Level = 0, Panda = panda1 });

            while (pending.Count > 0) {
                var currPanda = pending.Dequeue();
                var connectionLevel = currPanda.Level + 1;

                if (currPanda == panda2)
                    return connectionLevel;

                if (!visited.Contains(currPanda.Panda)) {
                    visited.Add(currPanda.Panda);
                }

                foreach (var friend in currPanda.Panda.Friends) {
                    pending.Enqueue(new PandaWithLevel { Level = connectionLevel, Panda = friend });
                }
            }

            return -1;
        }

        public bool AreConnected(IPanda panda1, IPanda panda2) {
            return ConnectionLevel(panda1, panda2) > 0;
        }

        public int HowManyGenderInNetwork(int level, IPanda panda, GenderType gender) {
            int pandasWithGender = 0;
            var pending = new Queue<PandaWithLevel>();
            var visited = new List<IPanda> { panda };
            int connectionLevel = 0;

            pending.Enqueue(new PandaWithLevel { Level = 0, Panda = panda });

            while (pending.Count > 0 || connectionLevel <= level) {
                var currPanda = pending.Dequeue();
                connectionLevel = currPanda.Level + 1;

                if (!visited.Contains(currPanda.Panda)) {
                    visited.Add(currPanda.Panda);

                    if (currPanda.Panda.Gender == gender)
                        pandasWithGender++;
                }

                foreach (var friend in currPanda.Panda.Friends) {
                    pending.Enqueue(new PandaWithLevel { Level = connectionLevel, Panda = friend });
                }
            }

            return pandasWithGender;
        }

        private class PandaWithLevel {
            public IPanda Panda;
            public int Level;
        }

        public class PandaAlreadyThereException : Exception {
            public PandaAlreadyThereException() : base("Panda already there!") { }
            public PandaAlreadyThereException(string message) : base(message) { }
            public PandaAlreadyThereException(string message, Exception inner) : base(message, inner) { }
            protected PandaAlreadyThereException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }

        public class PandasAlreadyFriendsException : Exception {
            public PandasAlreadyFriendsException() : base("Pandas already friends!") { }
            public PandasAlreadyFriendsException(string message) : base(message) { }
            public PandasAlreadyFriendsException(string message, Exception inner) : base(message, inner) { }
            protected PandasAlreadyFriendsException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }

        public class PandasNotAMemberOfTheSocialNetwork : Exception {
            public PandasNotAMemberOfTheSocialNetwork() : base("The panda is not a member of the network!") { }
            public PandasNotAMemberOfTheSocialNetwork(string message) : base(message) { }
            public PandasNotAMemberOfTheSocialNetwork(string message, Exception inner) : base(message, inner) { }
            protected PandasNotAMemberOfTheSocialNetwork(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }
    }
}
