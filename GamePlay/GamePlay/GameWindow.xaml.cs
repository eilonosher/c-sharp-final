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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Windows.Navigation;

namespace GamePlay
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private string actualPlayer;
        private string selectedPlayer;
        private GameServiceClient gameServer;
        private ClientCallback clientCallback;
        private Dictionary<int, string> colMap = new Dictionary<int, string>();
        private Dictionary<int, string> rowMap = new Dictionary<int, string>();
        private static int ROW = 6;
        private static int COL = 7;
        private char[,] board;
        private char myChar = 'x';
        private char playerChar = 'y';

        public GameWindow(string userName, string selectPlayer, GameServiceClient connectionToServer, ClientCallback clientCallback)
        {
            this.actualPlayer = userName;
            this.selectedPlayer = selectPlayer;
            this.gameServer = connectionToServer;
            this.clientCallback = clientCallback;
            this.clientCallback.addGameRef(this);
            this.board = new char[ROW, COL];
            initBoard();
            initMaps();
            InitializeComponent();
        }

        private void initBoard()
        {
            for (int i = 0; i < ROW; i++)
            {
                for (int j = 0; j < COL; j++)
                {
                    this.board[i, j] = '\0';
                }
            }
        }

        private void initMaps()
        { 
            rowMap.Add(1, "r1");
            rowMap.Add(2, "r2");
            rowMap.Add(3, "r3");
            rowMap.Add(4, "r4");
            rowMap.Add(5, "r5");
            rowMap.Add(6, "r6");
            rowMap.Add(7, "r7");
            colMap.Add(1, "c1");
            colMap.Add(2, "c2");
            colMap.Add(3, "c3");
            colMap.Add(4, "c4");
            colMap.Add(5, "c5");
            colMap.Add(6, "c6");
        }

        private void ColCliked(object sender, RoutedEventArgs e)
        {
            Button btnSender = (Button)sender;
            if (btnSender == Col1 )
            {
                //some code here
            }
           
            //some code here
        }


        private void Col1Cliked(object sender, RoutedEventArgs e)
        {
            handleMove(1);
        }

        private void handleMove(int col)
        {

            MoveResult moveResult = this.gameServer.ReportMove(col, this.actualPlayer);
            if (moveResult == MoveResult.NotYourTurn)
            {
                MessageBox.Show("Its not your turn!");
                return;
            }
               
            else if(moveResult == MoveResult.UnlegalMove)
            {
                MessageBox.Show("Unlegal move try again!");
                return;
            }
                
            else if (moveResult == MoveResult.YouWon)
            {
                this.updateMyWindowAfterMove(col);
                MessageBox.Show("ya Winner!Good bye!");
                this.Close();
                return;
            }
               
            this.updateMyWindowAfterMove(col);

        }

        private void updateMyWindowAfterMove(int col)
        {
            int rowTodraw = ROW -1;
            for(int i = 1; i < ROW; i++)
            {
                if (this.board[i, col -1] != '\0')
                { 
                    rowTodraw = i -1;
                    
                    break;
                }
                   
            }
            this.board[rowTodraw, col -1] = myChar;
            string result = rowMap[rowTodraw +1] + colMap[col];
            Label l = (Label)this.FindName(result);
            l.Background = new SolidColorBrush(Colors.Yellow);


        }

        private void Col2Cliked(object sender, RoutedEventArgs e)
        {
            handleMove(2);
        }

        private void Col3Cliked(object sender, RoutedEventArgs e)
        {
            handleMove(3);
        }

        private void Col4Cliked(object sender, RoutedEventArgs e)
        {
            handleMove(4);
        }

        private void Col5Cliked(object sender, RoutedEventArgs e)
        {
            handleMove(5);
        }

        private void Col6Cliked(object sender, RoutedEventArgs e)
        {
            handleMove(6);
        }

        private void Col7Cliked(object sender, RoutedEventArgs e)
        {
            handleMove(7);
        }

        internal void playerMove(MoveResult moveResult, int row, int col)
        {
            string result = rowMap[row + 1] + colMap[col + 1];

            Label l = (Label)this.FindName(result);

            l.Background = new SolidColorBrush(Colors.Red);

            this.board[row, col] = playerChar;
            if (moveResult == MoveResult.YouLose)
            {
                MessageBox.Show("ya Losser!Good bye!");
                this.Close();
                return;
            }
        }

    }
}
