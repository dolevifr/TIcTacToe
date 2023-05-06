using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIcTacToe
{
    class UserInterface
    {
        Game m_gameLogic;
       


        private void printBoard(Board gameBoard)
        {
            int m_boardSize = boardSize();
            for (int i = 0; i < m_boardSize; i++)
            {
                for(int j = 0;j < m_boardSize; j++)
                {
                    System.Console.WriteLine(m_gameLogic.GameBoard[i, j]);
                }
            }
        }

        private void getUserChoice()
        {
            int m_boardSize = boardSize();
            bool isValidChoice = true;
            do
            {
                string userInput = System.Console.ReadLine();
                int x = int.Parse(userInput.Substring(userInput.IndexOf("x:") + 2, userInput.IndexOf("y:") - userInput.IndexOf("x:") - 2));
                int y = int.Parse(userInput.Substring(userInput.IndexOf("y:") + 2));
                if (!userInput.StartsWith("x:") || !userInput.Contains("y:") || x > m_boardSize || y > m_boardSize)
                {
                    isValidChoice = false;
                }
            } while (isValidChoice);
        }
        private int boardSize()
        {
            return m_gameLogic.GameBoard.GetLength(0);
        }
        private void printWinOrLose(bool isWinner)
        {
            if (isWinner)
            {
                System.Console.WriteLine("You won the game!!!");
            }
            else
            {
                System.Console.WriteLine("You lost the game!!!");
            }
        }
    }
}
