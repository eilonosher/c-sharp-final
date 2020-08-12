using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading;
using System.Windows;

namespace GameService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
          ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class GameServiceClass : IGameService
    {
        int numClients = 0;
        static int GAME_ID = 1;
        Dictionary<string, ICallback> avilableClinets = new Dictionary<string, ICallback>();
        Dictionary<string, GameZone> games = new Dictionary<string, GameZone>();
        public void Disconnect(string player)
        {
            avilableClinets.Remove(player);
            if (this.games[player] != null)
                this.games.Remove(player);
            foreach (var callBack in avilableClinets.Values)
            {
                callBack.OtherPlayerDisconnected(player);
            }
        }

        public void DisconnectBeforeGame(int player)
        {
            --numClients;
        }
        public void Register(string name,string pass)
        {
            if (avilableClinets.ContainsKey(name) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pass))
             {
                 OpponentDisconnectedFault userExsists = new OpponentDisconnectedFault
                 {
                     
                     Details = $"Error need to specific"
                 };
                 throw new FaultException<OpponentDisconnectedFault>(userExsists);
             }
            ICallback callback = OperationContext.Current.GetCallbackChannel<ICallback>();
            //To do : add to data base and check valiadtion of pass and user name
            this.updateAllClinetToUpdateList(name);
            avilableClinets.Add(name, callback);
            

        }

        private void updateAllClinetToUpdateList(string name)
        {
            
            
            
            foreach(var callBack in avilableClinets.Values)
            {
                callBack.OtherPlayerSignIn(name);
            }
        }

        public MoveResult ReportMove(int col, string player)
        {
           return games[player].VerifyMove(col , player);
        }

        public void DisconnectBeforeGame(string player)
        {
            throw new NotImplementedException();
        }

     
        public Dictionary<string, ICallback> GetAvliableClients()
        {
            return avilableClinets;
        }

        public bool StartGame(string by, string player)
        {
            ICallback c = this.avilableClinets[player];
            bool result = c.ConfirmGame(by);
            return result;
        }

        public void StartGameBetweenPlayers(string p1, string p2)
        {
            this.avilableClinets[p2].StartGameUser(p1);
            GameZone gameZone = new GameZone(p1, p2, this.avilableClinets[p1], this.avilableClinets[p2]);
            this.games.Add(p1, gameZone);
            this.games.Add(p2, gameZone);
            updateAllOtherUserToUpdateList(p1, p2);
        }

        private void updateAllOtherUserToUpdateList(string p1, string p2)
        {
            foreach (var pair in avilableClinets)
            {
                if(!pair.Key.Equals(p1) && !pair.Key.Equals(p2))
                     pair.Value.OtherPlayerStartedGame(p1,p2);
            }
        }

        public Dictionary<string, ICallback> GetAvliableClientsForUser(string user)
        {
            Dictionary<string, ICallback> temp = new Dictionary<string, ICallback>(this.avilableClinets);
            temp.Remove(user);
            temp = filterUserThatPlaying(temp);
            return temp;
        }

        private Dictionary<string, ICallback> filterUserThatPlaying(Dictionary<string, ICallback> list)
        {
            Dictionary<string, ICallback> temp = new Dictionary<string, ICallback>();
            foreach (var key in list.Keys)
            {
                if (!games.ContainsKey(key))
                {
                    temp.Add(key, list[key]);
                }
            }
            return temp;
        }

        public void PlayerRetrunToList(string player)
        {
            if (this.games[player] != null)
                this.games.Remove(player);
            this.updateAllClinetToUpdateList(player);
        }

        public void SingIn(string user, string pass)
        {
            if (!isValidUser(user, pass))
            {
                OpponentDisconnectedFault userExsists = new OpponentDisconnectedFault
                {

                    Details = $"Error need to implmnet"
                };
                throw new FaultException<OpponentDisconnectedFault>(userExsists);
            }
            ICallback callback = OperationContext.Current.GetCallbackChannel<ICallback>();
            this.updateAllClinetToUpdateList(user);
            avilableClinets.Add(user, callback);
        }

        private bool isValidUser(string user, string pass)
        {
            //need to implnet check in data base if is cuurect
            return false;
        }

    }
}
