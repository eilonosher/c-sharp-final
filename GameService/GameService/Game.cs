using System;

namespace GameService
{
    internal class GameZone
    {
        private const int ROW = 6;
        private const int COL = 7;
        private string p1;
        private string p2;
        private readonly char playerOneChar = 'A';
        private readonly char playerTwoChar = 'B';
        private ICallback callback1;
        private ICallback callback2;
        private char[,] board;
        private string currentPlayer;

        public GameZone(string p1, string p2, ICallback callback1, ICallback callback2)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.callback1 = callback1;
            this.callback2 = callback2;
            this.board = new char[ROW, COL];
            this.currentPlayer = p1;
            initBoard();
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

        internal MoveResult VerifyMove(int selectedCol, string player, System.Windows.Point p)
        {
            selectedCol = selectedCol - 1;
            //check if its player turn
            if (!player.Equals(currentPlayer))
                return MoveResult.NotYourTurn;
            int i = ROW - 1;
            //find the row to put
            for (; i >= 0; i--)
            {
                if (board[i, selectedCol] == '\0')
                    break;
            }
            //check if is unlegal move
            if (colIsFull(selectedCol))
                return MoveResult.UnlegalMove;
            //fill the board with the current move
            this.board[i, selectedCol] = player.Equals(p1) ? playerOneChar : playerTwoChar;
            //check if the player win the game
            if (ItsAWin(player))
            {
                notifyAnotherPlayer(player, i, selectedCol, MoveResult.YouLose, p);
                return MoveResult.YouWon;
            }
            this.changePlayerTurn();
            notifyAnotherPlayer(player, i, selectedCol, MoveResult.GameOn, p);
            return MoveResult.GameOn;
        }

        private void changePlayerTurn()
        {
            currentPlayer = currentPlayer.Equals(p1) ? p2 : p1;
        }

        private void notifyAnotherPlayer(string player, int i, int selectedCol, MoveResult result, System.Windows.Point p)
        {
            if (player.Equals(p1))
            {
                callback2.OtherPlayerMoved(result, i, selectedCol, p);
            }
            else
            {
                callback1.OtherPlayerMoved(result, i, selectedCol, p);
            }
        }

        private bool colIsFull(int selectedCol)
        {
            return board[0, selectedCol] != '\0';
        }

        private bool ItsAWin(string player)
        {
            char p = playerOneChar;
            if (player.Equals(p2))
                p = playerTwoChar;
            return areFourConnected(p);
        }

        public bool areFourConnected(char player)
        {
            // horizontalCheck 
            for (int j = 0; j < getHeight() - 3; j++)
            {
                for (int i = 0; i < getWidth(); i++)
                {
                    if (this.board[i, j] == player && this.board[i, j + 1] == player && this.board[i, j + 2] == player && this.board[i, j + 3] == player)
                    {
                        return true;
                    }
                }
            }
            // verticalCheck
            for (int i = 0; i < getWidth() - 3; i++)
            {
                for (int j = 0; j < this.getHeight(); j++)
                {
                    if (this.board[i, j] == player && this.board[i + 1, j] == player && this.board[i + 2, j] == player && this.board[i + 3, j] == player)
                    {
                        return true;
                    }
                }
            }
            // ascendingDiagonalCheck 
            for (int i = 3; i < getWidth(); i++)
            {
                for (int j = 0; j < getHeight() - 3; j++)
                {
                    if (this.board[i, j] == player && this.board[i - 1, j + 1] == player && this.board[i - 2, j + 2] == player && this.board[i - 3, j + 3] == player)
                        return true;
                }
            }
            // descendingDiagonalCheck
            for (int i = 3; i < getWidth(); i++)
            {
                for (int j = 3; j < getHeight(); j++)
                {
                    if (this.board[i, j] == player && this.board[i - 1, j - 1] == player && this.board[i - 2, j - 2] == player && this.board[i - 3, j - 3] == player)
                        return true;
                }
            }
            return false;
        }

        private int getWidth()
        {
            return ROW;
        }

        private int getHeight()
        {
            return COL;
        }
    }
}
