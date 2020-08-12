using GamePlay.GameServiceRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading;
using System.Windows;
using System.Windows.Documents;

namespace GamePlay
{
    public class ClientCallback : IGameServiceCallback
    {
        #region Delegates
        private GameServiceClient gameServiceClient;
        private WaitingForGame cuurentWindow;
        private GameWindow cuurentGameWindow;


        public ClientCallback()
        {
        }
        #endregion

        public void OtherPlayerConnected()
        {
            MessageBox.Show("Sdsdsdsdsdssssssssssssssssssssssssssssss");
           /// throw new System.NotImplementedException();
        }

        public void OtherPlayerMoved(MoveResult moveResult, int location)
        {
            ///  throw new System.NotImplementedException();
            string a = null;
        }


        bool IGameServiceCallback.ConfirmGame(string userToGame)
        {
            return GameWindowManger.Instance.WaitingForGameWindow.confirmGame(userToGame);
        }

        public void StartGameUser(string p1)
        {
            GameWindowManger.Instance.WaitingForGameWindow.startWithAnotherPlayer(p1);
        }

        public void OtherPlayerMoved(MoveResult moveResult, int row, int col)
        {
            GameWindowManger.Instance.GameWindow.playerMove(moveResult, row, col);
        }

        public void OtherPlayerConnected(string user)
        {
          
        }

        public void OtherPlayerSignIn(string user)
        {
            GameWindowManger.Instance.WaitingForGameWindow.updateUserList(user, "Add");
        }

        public void OtherPlayerDisconnected(string user)
        {
            GameWindowManger.Instance.WaitingForGameWindow.updateUserList(user, "Del");
        }

        public void OtherPlayerStartedGame(string user1, string user2)
        {
            GameWindowManger.Instance.WaitingForGameWindow.updateUserList(user1, "Del");
            GameWindowManger.Instance.WaitingForGameWindow.updateUserList(user2, "Del");
        }
    }
}