using GamePlay.GamrServiceRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GamePlay
{
    /// <summary>
    /// Interaction logic for WaitingForGame.xaml
    /// </summary>
    public partial class WaitingForGame : Window
    {
        private string userName;
        private ClientCallback clientCallback;
        private GameServiceClient connectionToServer;
        public delegate void UpdateUsers();
        public event UpdateUsers updateUsers;
        private List<string> userList;
        public WaitingForGame()
        {
            InitializeComponent();
            clientCallback.addWindowRef(this);
        }

        public WaitingForGame(string name, ClientCallback clientCallback, GameServiceClient connectionToServer)
        {
            this.userName = name;
            this.clientCallback = clientCallback;
            this.connectionToServer = connectionToServer;
            InitializeComponent();
            userList = connectionToServer.GetAvliableClientsForUser(this.userName).Keys.ToList();
            listOfAvliablePlayers.ItemsSource = connectionToServer.GetAvliableClientsForUser(this.userName).Keys.ToList();
            clientCallback.addWindowRef(this);

        }

        private void btnRefreshRivals_Click(object sender, RoutedEventArgs e)
        {

        }

        internal bool confirmGame(string userToGame)
        {
            DialogResult result = System.Windows.Forms.MessageBox.Show("Do you want to play with " + userToGame + " ?", "Request Game" , MessageBoxButtons.YesNo);
            if (result.ToString() == "Yes")
            {
                return true;
            }
               
            return false;

        }

        private void windowClosed(object sender, System.ComponentModel.CancelEventArgs e)
        {
            connectionToServer.Disconnect(this.userName);
        }

        public void updateUserList(string user,string action)
        {
            // System.Windows.MessageBox.Show(user);
            /* listOfAvliablePlayers = null;
             userList.Add(user);
             listOfAvliablePlayers.ItemsSource = userList;
             listOfAvliablePlayers.Items.Refresh();*/
            if (action.Equals("Add"))
            {
                userList.Add(user);
                listOfAvliablePlayers.ItemsSource = null;
                listOfAvliablePlayers.ItemsSource = userList;
                listOfAvliablePlayers.Items.Refresh();
            }
            else
            {
                userList.Remove(user);
                listOfAvliablePlayers.ItemsSource = null;
                listOfAvliablePlayers.ItemsSource = userList;
                listOfAvliablePlayers.Items.Refresh();
            }
             


        }

        internal void startWithAnotherPlayer(string p1)
        {
            GameWindow newGame = new GameWindow(this.userName, p1, this.connectionToServer,clientCallback);
            newGame.Show();
            this.Hide();
        }

        private async void startGameClicked(object sender, RoutedEventArgs e)
        {
            string selectPlayer = listOfAvliablePlayers.SelectedItem.ToString();
            bool result = this.connectionToServer.StartGameAsync(this.userName, selectPlayer).Result;
            if(result == true)
            {
                startWithAnotherPlayer(selectPlayer);
                connectionToServer.StartGameBetweenPlayers(this.userName, selectPlayer);
            }
        }

        private void windowClosed(object sender, EventArgs e)
        {
            connectionToServer.Disconnect(this.userName);
        }

    
    }
}
