using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIcTacToe
{
    class TextBoardDisplayer
    {
        private Board.eCell[,] m_board;
        private int m_boardSize;

        public TextBoardDisplayer(Board.eCell[,] io_board)
        {
            m_board = io_board;
            m_boardSize = m_board.GetLength(0);
        }

        public void printBoard()
        {
            printBoardHeader();

            for (int i = 0; i < m_boardSize; i++)
            {
                Console.Write(string.Format("{0}|", i + 1));

                for (int j = 0; j < m_boardSize; j++)
                {
                    Console.Write(string.Format(" {0} |", cellToChar(m_board[j, i])));
                }

                printBoardFooter();
            }
        }

        private void printBoardFooter()
        {
            Console.WriteLine();
            Console.Write(" =");

            for (int j = 0; j < m_boardSize; j++)
            {
                Console.Write("====");
            }

            Console.WriteLine();
        }

        private void printBoardHeader()
        {
            for (int i = 1; i <= m_boardSize; i++)
            {
                Console.Write(string.Format("  {0} ", i));
            }

            Console.WriteLine();
        }

        private char cellToChar(Board.eCell boardCell)
        {
            char cellChar = ' ';

            switch (boardCell)
            {
                case Board.eCell.Empty:
                    cellChar = ' ';
                    break;
                case Board.eCell.X:
                    cellChar = 'X';
                    break;
                case Board.eCell.O:
                    cellChar = 'O';
                    break;
            }

            return cellChar;
        }
    }
}
