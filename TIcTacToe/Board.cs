using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIcTacToe
{
    class Board
    {
        public enum eCell {Empty, X, O};

        private eCell[,] m_board;
        private  int m_boardSize;
        public Board(int i_size)
        {
            m_boardSize = i_size;
            m_board = new eCell[i_size, i_size];
        }

        public eCell[,] GameBoard
        {
            get { return m_board; }
        }

        public int BoardSize
        {
            get { return m_boardSize; }
        }


        public bool SetCellInBoard(int i_x, int i_y, eCell playerSymbol)
        {
            bool isValidInsertion = IsInRange(i_x, i_y) && isCellEmpty(i_x, i_y);

            if (isValidInsertion)
            {
                m_board[i_x, i_y] = playerSymbol;
            }

            return isValidInsertion;
        }

        public eCell? GetCellAtCoordinate(int i_x, int i_y)
        {
            return IsInRange(i_x, i_y) ? m_board[i_x, i_y] : null;
        }

        public bool IsInRange(int i_x, int i_y)
        {
            return i_x < m_boardSize && i_y < m_boardSize;
        }

        private bool isCellEmpty(int i_x, int i_y)
        {
            return m_board[i_x, i_y] == eCell.Empty;
        }
    }
}
