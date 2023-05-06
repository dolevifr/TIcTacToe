using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIcTacToe
{
    class ValidateWin
    {
        private Board m_board;


        public ValidateWin(Board io_board)
        {
            m_board = io_board;
        }

        public bool IsWinner(int i_x, int i_y)
        {
            return validateWin(0, i_y, 1, 0) || validateWin(i_x, 0, 0, 1) || validateWin(0, 0, 1, 1)
                   || validateWin(0, m_board.BoardSize - 1, 1, -1);
            //validateWinHorizontal(i_x, i_y) || validateWinVertical(i_x, i_y) ||
            //validateWinDiagonalRight(i_x, i_y) || validateWinDiagonalLeft(i_x, i_y);
        }

        private bool validateWinHorizontal(int i_x, int i_y)
        {
            Board.eCell initialCell = m_board.GetCellAtCoordinate(i_x, i_y);
            bool isWinner = true;
            for (int i = 0; i < m_board.BoardSize; i++)
            {
                if (m_board.GameBoard[i,i_y] != initialCell)
                {
                    isWinner = false;
                    break;
                }
            }
            return isWinner;
        }

        private bool validateWinVertical(int i_x, int i_y)
        {
            Board.eCell initialCell = m_board.GetCellAtCoordinate(i_x, i_y);
            bool isWinner = true;
            for (int i = 0; i < m_board.BoardSize; i++)
            {
                if (m_board.GameBoard[i_x, i] != initialCell)
                {
                    isWinner = false;
                }
            }
            return isWinner;
        }

        private bool validateWinDiagonalRight(int i_x, int i_y)
        {
            Board.eCell initialCell = m_board.GetCellAtCoordinate(i_x, i_y);
            bool isWinner = true;
            for (int i = 0; i < m_board.BoardSize; i++)
            {
                if (m_board.GameBoard[i,i] != initialCell)
                {
                    isWinner = false;
                }
            }
            return isWinner;
        }

        private bool validateWinDiagonalLeft(int i_x, int i_y)
        {
            Board.eCell initialCell = m_board.GetCellAtCoordinate(i_x, i_y);
            bool isWinner = true;
            for (int i = m_board.BoardSize; i > 0; i--)
            {
                if (m_board.GameBoard[m_board.BoardSize - i - 1 , i] != initialCell)
                {
                    isWinner = false;
                }
            }
            return isWinner;
        }

        private bool validateWin(int i_x, int i_y, int i_dx, int i_dy)
        {
            Board.eCell initialCell = m_board.GetCellAtCoordinate(i_x, i_y);
            bool isWinner = true;
            
            while(m_board.IsInRange(i_x, i_y) )
            {
                if (m_board.GameBoard[i_x, i_y] != initialCell || m_board.GameBoard[i_x, i_y] == Board.eCell.Empty)
                {
                    isWinner = false;
                    break;
                }
                
                i_x += i_dx;
                i_y += i_dy;
            }

            return isWinner;
        }

        

    }
}
