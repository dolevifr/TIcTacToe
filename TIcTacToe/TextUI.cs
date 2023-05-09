using System;
using System.Drawing;
using System.Runtime.Remoting.Channels;
using System.Threading;

namespace TIcTacToe
{
    class UserInterface
    {
        private const int k_lowerBoardSizeLimit = 3;
        private const int k_upperBoardSizeLimit = 9;

        private int m_playerOneVictoriesCount = 0;
        private int m_playerTwoVictoriesCount = 0;

        private int m_boardSize;
        private bool m_isComputerPlayer;

        public static void Main()
        {
            GameWithScoreTrack();
        }

        public UserInterface()
        {
            m_boardSize = configureGameBoardSize();
            m_isComputerPlayer = configureIfComputerPlayer();
        }

        private static void GameWithScoreTrack()
        {
            UserInterface ui = new UserInterface();
            char quitGame = ' ';
            bool continuePlaying = true;
            bool isFirstGame = true;
            GameLogic.eStepOutcome whoWon;

            while (continuePlaying)
            {
                Console.WriteLine(TextUIMessages.k_quitMessage);
                whoWon = ui.StartOneMatch(isFirstGame,ui.m_isComputerPlayer,ui.m_boardSize);
                if (whoWon == GameLogic.eStepOutcome.PlayerWon)
                {
                    ui.m_playerOneVictoriesCount++;
                }
                else if (whoWon == GameLogic.eStepOutcome.ComputerWon)
                {
                    ui.m_playerTwoVictoriesCount++;
                }
                Ex02.ConsoleUtils.Screen.Clear();
                Console.WriteLine(TextUIMessages.k_scoreMessage, ui.m_playerOneVictoriesCount,ui.m_playerTwoVictoriesCount);
                Thread.Sleep(5000);
                Ex02.ConsoleUtils.Screen.Clear();

            }
        }

        public GameLogic.eStepOutcome StartOneMatch(bool isFirstGame, bool isComputerRival, int boardSize)
        {
            GameLogic currentGame;
            TextBoardDisplayer textBoardDisplayer;
            Point currentUserCoordinates;

            GameLogic.eStepOutcome currentStepOutcome = GameLogic.eStepOutcome.ValidMove;
            Console.WriteLine(TextUIMessages.k_welcomeMessage);
            
            int stepCounter = 0;
            if(isFirstGame)
            {
                currentGame = new GameLogic(m_boardSize, m_isComputerPlayer);
            }
            else
            {
                currentGame = new GameLogic(boardSize, isComputerRival);
            }
            textBoardDisplayer = new TextBoardDisplayer(currentGame.GameBoard);

            while (currentStepOutcome == GameLogic.eStepOutcome.ValidMove || currentStepOutcome == GameLogic.eStepOutcome.InvalidMove)
            {
                textBoardDisplayer.printBoard();
                currentUserCoordinates = getCoordinatesFromUser();
                Ex02.ConsoleUtils.Screen.Clear();
                currentStepOutcome = currentGame.GameStep(currentUserCoordinates.X - 1, currentUserCoordinates.Y - 1);

                if (currentStepOutcome == GameLogic.eStepOutcome.ValidMove)
                {
                    stepCounter++;
                }
                else if(currentStepOutcome == GameLogic.eStepOutcome.InvalidMove)
                {
                    Console.WriteLine(TextUIMessages.k_invalidInputMessage);
                }
            }
            printEndGameMessage(currentStepOutcome, stepCounter);
            return currentStepOutcome;
        }

        private int configureGameBoardSize()
        {
            int value;

            while (true) {
                Console.WriteLine(TextUIMessages.k_gameBoardSizeSelectionMessage);
                string input = Console.ReadLine();

                if (int.TryParse(input, out value) && value >= k_lowerBoardSizeLimit && value <= k_upperBoardSizeLimit)
                {
                    break;
                }

                Console.WriteLine(TextUIMessages.k_invalidInputMessage);
            }

            return value;
        }

        private Point getCoordinatesFromUser()
        {
            Point point;

            while (true)
            {
                Console.WriteLine(TextUIMessages.k_cellSelectionMessage);
                string[] input = Console.ReadLine().Split();

                if (int.TryParse(input[0], out int valueX) && int.TryParse(input[1], out int valueY))
                {
                    point = new Point(valueX, valueY);
                    break;
                }

                Console.WriteLine(TextUIMessages.k_invalidInputMessage);
            }

            return point;
        }

        private bool configureIfComputerPlayer()
        {
            char option;
            bool isComputerPlayer;
            while (true)
            {
                Console.WriteLine(TextUIMessages.k_selectIfComputerPlayerMessage);
                string input = Console.ReadLine();

                if (char.TryParse(input, out option) && option == 'y' || option == 'n')
                {
                    isComputerPlayer = option == 'y';
                    break;
                }

                Console.WriteLine(TextUIMessages.k_invalidInputMessage);
            }

            return isComputerPlayer;
        }

        private void printEndGameMessage(GameLogic.eStepOutcome i_endGameOutCome, int i_stepCounter)
        {
            Console.WriteLine(TextUIMessages.k_gameOverMessage);

            switch(i_endGameOutCome)
            {
                case GameLogic.eStepOutcome.PlayerWon:
                    Console.WriteLine(String.Format(TextUIMessages.k_humanWonMessage, (i_stepCounter % 2) + 1));
                    break;
                case GameLogic.eStepOutcome.ComputerWon:
                    Console.WriteLine(TextUIMessages.k_computerWonMessage);
                    break;
                case GameLogic.eStepOutcome.Draw:
                    Console.WriteLine(TextUIMessages.k_drawOutcomeMessage);
                    break;
            }

        }
    }
}

