using GamePlay.GamrServiceRef;
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
            connectionToServer = new GameServiceClient(new InstanceContext(clientCallback));

            InitializeComponent();
        }

        private void signInClicked(object sender, RoutedEventArgs e)
        {
            SingIn signIn = new SingIn();
            signIn.Show();
            this.Close();
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
