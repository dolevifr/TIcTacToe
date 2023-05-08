using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIcTacToe
{
    class UserInterface
    {
        private const int k_lowerBoardSizeLimit = 3;
        private const int k_upperBoardSizeLimit = 9;


        public static void Main()
        {
            UserInterface ui = new UserInterface();
            ui.StartGame();
        }

        public void StartGame()
        {
            GameLogic currentGame;

            System.Console.WriteLine(TextUIMessages.k_welcomeMessage);
            int boardSize = configureGameBoardSize();
            bool isComputerPlayer = configureIfComputerPlayer();

            currentGame = new GameLogic(boardSize, isComputerPlayer);
            printBoard(currentGame.GameBoard);

        }

        private int configureGameBoardSize()
        {
            int value = -1;
            bool isValidInput = false;

            while (true) {
                System.Console.WriteLine(TextUIMessages.k_gameBoardSizeSelectionMessage);
                string input = Console.ReadLine();

                if (int.TryParse(input, out value) && value >= k_lowerBoardSizeLimit && value <= k_upperBoardSizeLimit)
                {
                    isValidInput = true;
                    break;
                }

                Console.WriteLine(TextUIMessages.k_invalidInputMessage);
            }

            return value;
        }

        private bool configureIfComputerPlayer()
        {
            char option = 'y';
            bool isValidInput = false;
            bool isComputerPlayer = false;
            while (true)
            {
                System.Console.WriteLine(TextUIMessages.k_gameBoardSizeSelectionMessage);
                string input = Console.ReadLine();

                if (char.TryParse(input, out option) && option == 'y' || option == 'n')
                {
                    isValidInput = true;
                    isComputerPlayer = option == 'y';
                    break;
                }

                Console.WriteLine(TextUIMessages.k_invalidInputMessage);
            }

            return isComputerPlayer;
        }

        private void printBoard(Board.eCell[,] i_GameBoard)
        {
            int boardSize = i_GameBoard.GetLength(0);

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    System.Console.WriteLine(i_GameBoard[i, j]);
                }
            }
        }


    }
}

