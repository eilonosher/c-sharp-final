using GamePlay.GameServiceRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Forms;

namespace GamePlay
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        private ClientCallback clientCallback;
        private GameServiceClient connectionToServer;

        public Register()
        {
            clientCallback = new ClientCallback();
            connectionToServer = new GameServiceClient(new InstanceContext(clientCallback));
            InitializeComponent();
        }

        private void signUpClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                connectionToServer.Register(name.Text.Trim(), (pass.Password.Trim()));
                WaitingForGame waitingForGame = new WaitingForGame(name.Text.Trim(), clientCallback, connectionToServer);
                waitingForGame.Show();
                this.Close();
            }
            catch (FaultException<ConnectedFault> err)
            {
                System.Windows.MessageBox.Show(err.Detail.Details, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }
    }
}
