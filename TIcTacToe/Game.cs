using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIcTacToe
{
    class Game
    {
        public enum eStepOutcome {ComputerWon, PlayerWon, InvalidMove}

        private Board m_gameBoard;
        private ValidateWin m_winValidator;
        private bool m_isComputerRival;
        private int m_stepCount;

        private Game(int boardSize, bool isComputerRival)
        {
            m_gameBoard = new Board(boardSize);
            m_winValidator = new ValidateWin(m_gameBoard);
            m_isComputerRival = isComputerRival;
            m_stepCount = 0;
        }

    public Board.eCell[,] GameBoard
        {
            get { return m_gameBoard.GameBoard; }
        }

        public void GameStep(int i_x, int i_y, eStepOutcome o_stepOutcome)
        {
            bool isValidMove = makeStep(i_x, i_y, ref o_stepOutcome);

            if(isValidMove && m_isComputerRival)
            {
                makeComputerStep();
            }

        }

        private void makeStep(int i_x, int i_y, ref eStepOutcome o_stepOutcome)
        {
            Board.eCell curPlayerSymbol = m_stepCount % 2 == 0 ? Board.eCell.O : Board.eCell.X;
            bool isValidMove = m_gameBoard.SetCellInBoard(i_x, i_y, curPlayerSymbol);

            if(isValidMove)
            {
                m_stepCount++;

                if(m_winValidator.IsWinner(i_x, i_y))
                {
                    o_stepOutcome = PlayerWon;
                }
            }
        }

        private void makeComputerStep()
        {
            int randomX, randomY;
            bool validMoveFlag = false;
            Random randomNumGenerator = new Random();

            while(validMoveFlag == false)
            {
                randomX = randomNumGenerator.Next() % m_gameBoard.BoardSize;
                randomY = randomNumGenerator.Next() % m_gameBoard.BoardSize;
                validMoveFlag = makeStep(randomX, randomY);
            }
        }

    }
}
