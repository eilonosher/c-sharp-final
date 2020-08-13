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
        Dictionary<string, ICallback> avilableClinets = new Dictionary<string, ICallback>();
        Dictionary<string, GameZone> games = new Dictionary<string, GameZone>();
        public void Disconnect(string player)
        {
            //remove from avilable clinet
            avilableClinets.Remove(player);
            //if is exit from game remove the game
            if (this.games.ContainsKey(player))
                this.games.Remove(player);
            //notify all other client that is disconnected
            foreach (var callBack in avilableClinets.Values)
            {
                Thread updateOtherPlayerThread = new Thread(() =>
                {
                    callBack.OtherPlayerDisconnected(player);
                }
              );
                updateOtherPlayerThread.Start();
            }
        }

        public void Register(string name, string pass)
        {
            if (userExist(name) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pass))
            {
                ConnectedFault userExsists = new ConnectedFault
                {
                    Details = $"Error need to specific"
                };
                throw new FaultException<ConnectedFault>(userExsists);
            }
            ICallback callback = OperationContext.Current.GetCallbackChannel<ICallback>();
            this.updateAllClinetToUpdateList(name);
            avilableClinets.Add(name, callback);
        }

        private bool userExist(string name)
        {
            //roni - need to implemenet serch in user list in db
            return false;
        }

        private void updateAllClinetToUpdateList(string name)
        {
            foreach (var callBack in avilableClinets.Values)
            {
                Thread updateOtherPlayerThread = new Thread(() =>
                {
                    callBack.OtherPlayerSignIn(name);
                }
               );
                updateOtherPlayerThread.Start();
            }
        }

        public MoveResult ReportMove(int col, string player, Point p)
        {
            return games[player].VerifyMove(col, player, p);
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
                if (!pair.Key.Equals(p1) && !pair.Key.Equals(p2))
                    pair.Value.OtherPlayerStartedGame(p1, p2);
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
                ConnectedFault userExsists = new ConnectedFault
                {

                    Details = $"Error need to implmnet"
                };
                throw new FaultException<ConnectedFault>(userExsists);
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
