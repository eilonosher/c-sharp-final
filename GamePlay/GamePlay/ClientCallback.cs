using GamePlay.GamrServiceRef;
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
        internal Action<string> endGame;
        internal Action updateGame;
        internal Action startGame;
        private GameServiceClient gameServiceClient;
        internal List<string> userList;
        private WaitingForGame cuurentWindow;
        private GameWindow cuurentGameWindow;

        public ClientCallback(GameServiceClient gameServiceClient)
        {
            this.gameServiceClient = gameServiceClient;
        }

        public ClientCallback()
        {
        }

        internal void addWindowRef(WaitingForGame cuurentWindow)
        {
            this.cuurentWindow = cuurentWindow;
        }

        internal void addGameRef(GameWindow window)
        {
            this.cuurentGameWindow = window;
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

        public void OtherPlayerSignIn(string user,string action)
        {
            if(this.cuurentWindow != null )
            this.cuurentWindow.updateUserList(user,"Add");
        }


        bool IGameServiceCallback.ConfirmGame(string userToGame)
        {
            return this.cuurentWindow.confirmGame(userToGame);
        }

        public void StartGameUser(string p1)
        {
            this.cuurentWindow.startWithAnotherPlayer(p1);
        }

        public void OtherPlayerMoved(MoveResult moveResult, int row, int col)
        {
            this.cuurentGameWindow.playerMove(moveResult, row, col);
        }

    }
}