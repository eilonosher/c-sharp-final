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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GamePlay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private fields
        private Dictionary<int, Button> buttons = new Dictionary<int, Button>();
        private string mySign;
        private string otherSign;
        private bool serverOn = false;
        private ClientCallback clientCallback;
        private GameServiceClient connectionToServer;
        #endregion
        public MainWindow()
        {
            clientCallback = new ClientCallback();
            connectionToServer = new GameServiceClient(new InstanceContext(clientCallback));
            InitializeComponent();
        }

        private void signInClicked(object sender, RoutedEventArgs e)
        {
            loading.Content = "Loading....";
            try
            {
                connectionToServer.SingIn(name.Text.Trim(), (pass.Password.Trim()));
            }
            catch (FaultException<OpponentDisconnectedFault> err)
            {
                System.Windows.MessageBox.Show(err.Detail.Details, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
         //  Application.
        }


        private void registerClicked(object sender, RoutedEventArgs e)
        {
            Register reg = new Register();
            reg.Show();
            this.Close();
        }
    }

}
