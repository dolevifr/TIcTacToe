using System;

namespace TIcTacToe
{
    class GameLogic
    {
        public enum eStepOutcome {ComputerWon, PlayerWon, InvalidMove, ValidMove, Draw}

        private Board m_GameBoard;
        private WinValidator m_WinValidator;
        private bool m_IsComputerRival;
        private int m_StepCount;
        
        public GameLogic(int boardSize, bool isComputerRival)
        {
            m_GameBoard = new Board(boardSize);
            m_WinValidator = new WinValidator(m_GameBoard);
            m_IsComputerRival = isComputerRival;
            m_StepCount = 0;
        }

    public Board.eCell[,] GameBoard
        {
            get { return m_GameBoard.GameBoard; }
        }

        public eStepOutcome GameStep(int i_x, int i_y)
        {
            eStepOutcome humanStepOutcome, computerStepOutcome;
            const bool k_ComputerMove = true;

            computerStepOutcome = eStepOutcome.InvalidMove;
            humanStepOutcome = makeStep(i_x, i_y, !k_ComputerMove);
            
            if (m_StepCount == Math.Pow(m_GameBoard.BoardSize, 2))
            {
                humanStepOutcome = eStepOutcome.Draw;
            }

            if (m_IsComputerRival && humanStepOutcome == eStepOutcome.ValidMove)
            {
                computerStepOutcome = makeComputerStep();
            }

            return computerStepOutcome == eStepOutcome.ComputerWon ? computerStepOutcome : humanStepOutcome;
        }

        private eStepOutcome makeStep(int i_x, int i_y, bool i_isComputerStep)
        {
            Board.eCell curPlayerSymbol = m_StepCount % 2 == 0 ? Board.eCell.O : Board.eCell.X;
            eStepOutcome stepOutcome = eStepOutcome.InvalidMove;

            bool isValidMove = m_GameBoard.SetCellInBoard(i_x, i_y, curPlayerSymbol);

            if (isValidMove)
            {
                stepOutcome = eStepOutcome.ValidMove;
                m_StepCount++;

                if (m_WinValidator.IsWinner(i_x, i_y))
                {
                    stepOutcome = i_isComputerStep ? eStepOutcome.ComputerWon : eStepOutcome.PlayerWon;
                }
            }

            return stepOutcome;
        }

        private eStepOutcome makeComputerStep()
        {
            int randomX, randomY;
            const bool v_isComputerStep = true;
            Random randomNumGenerator = new Random();
            eStepOutcome stepOutcome = eStepOutcome.InvalidMove;

            while (stepOutcome == eStepOutcome.InvalidMove)
            {
                randomX = randomNumGenerator.Next() % m_GameBoard.BoardSize;
                randomY = randomNumGenerator.Next() % m_GameBoard.BoardSize;
                stepOutcome = makeStep(randomX, randomY, v_isComputerStep);
            }

            return stepOutcome;
        }

    }
}
