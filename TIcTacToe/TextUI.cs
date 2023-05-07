using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIcTacToe
{
    class UserInterface
    {
        GameLogic m_gameLogic;


        UserInterface()
        {
            m_gameLogic = new GameLogic(boardSize(m_gameLogic.GameBoard), false);
            Board.eCell[,] gameBoard;
            int sizeOfBoard = boardSize(m_gameLogic.GameBoard);
            gameBoard = m_gameLogic.GameBoard;
        }
        static void Main()
        {
            UserInterface gameInformation = new UserInterface();
            Board.eCell[,] gameBoard = gameInformation.m_gameLogic.GameBoard;
            welcomeMessage();
            int BoardSize = Int32.Parse(getUserSizeOfBoard());
            printBoard(gameBoard);
        }
        private static string getUserSizeOfBoard()
        {
            return System.Console.ReadLine();
        }
        private static void welcomeMessage()
        {
            System.Console.WriteLine(@"Hello and welcome to reverse tic tac toe game!
                                    Please select if you wish to play against a computer or against another player:
                                    1 for computer
                                    2 for human rival
                                    ");
        }
        private static void printBoard(Board.eCell[,] gameBoard)
        {
            UserInterface gameInformation = new UserInterface();
            int m_boardSize = boardSize(gameBoard);
            Console.Clear();
            for (int i = 0; i < m_boardSize; i++)
            {
                for (int j = 0; j < m_boardSize; j++)
                {
                    System.Console.WriteLine(gameBoard[i, j]);
                }
            }
        }
        private void getUserChoiceOfRival()
        {
            System.Console.ReadLine();
        }

        private void getUserCellChoice(Board.eCell[,] gameBoard)
        {
            int m_boardSize = boardSize(gameBoard);
            bool isValidChoice = true;
            do
            {
                string userInput = System.Console.ReadLine();
                int x = int.Parse(userInput.Substring(userInput.IndexOf("x:") + 2, userInput.IndexOf("y:") - userInput.IndexOf("x:") - 2));
                int y = int.Parse(userInput.Substring(userInput.IndexOf("y:") + 2));
                if (!userInput.StartsWith("x:") || !userInput.Contains("y:"))
                {
                    isValidChoice = false;
                }
            } while (isValidChoice);
        }
        private static int boardSize(Board.eCell[,] gameBoard)
        {
            return gameBoard.GetLength(0);
        }
        private void printWinOrLose(bool isWinner)
        {
            string winner = "congrats! you won the game";
            string loser = "congrats! you lost the game";
            string winnOrLoseMessage = string.Format(@"
  _____          __  __ ______    ______      ________ _____  
 / ____|   /\   |  \/  |  ____|  / __ \ \    / /  ____|  __ \ 
| |  __   /  \  | \  / | |__    | |  | \ \  / /| |__  | |__) |
| | |_ | / /\ \ | |\/| |  __|   | |  | |\ \/ / |  __| |  _  / 
| |__| |/ ____ \| |  | | |____  | |__| | \  /  | |____| | \ \ 
 \_____/_/    \_\_|  |_|______|  \____/   \/   |______|_|  \_\

                      {}", isWinner ? winner : loser);
            System.Console.WriteLine(winnOrLoseMessage);

        }
    }
}

