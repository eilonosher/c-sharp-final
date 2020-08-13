using GamePlay.GameServiceRef;
using System.Collections.Generic;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;


namespace GamePlay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private fields
        private Dictionary<int, Button> buttons = new Dictionary<int, Button>();
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
            catch (FaultException<ConnectedFault> err)
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
