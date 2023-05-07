using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIcTacToe
{
    class WinValidator
    {
        private Board m_board;


        public WinValidator(Board io_board)
        {
            m_board = io_board;
        }

        public bool IsWinner(int i_x, int i_y)
        {
            return validateWinHorizontal(i_y) || validateWinVertical(i_x) ||
                   validateWinDiagonalRight() || validateWinDiagonalLeft();
        }

        private bool validateWinHorizontal(int i_y)
        {
            return validateWin(0, i_y, 1, 0);
        }

        private bool validateWinVertical(int i_x)
        {
            return validateWin(i_x, 0, 0, 1);
        }

        private bool validateWinDiagonalRight()
        {
            return validateWin(0, 0, 1, 1);
        }

        private bool validateWinDiagonalLeft()
        {
            return validateWin(0, m_board.BoardSize - 1, 1, -1);
        }

        private bool validateWin(int i_x, int i_y, int i_dx, int i_dy)
        {
            Board.eCell? initialCell = m_board.GetCellAtCoordinate(i_x, i_y);
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
