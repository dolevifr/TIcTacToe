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

        private int m_currGameStepCounter = 0;
        private int m_playerOneVictoriesCount = 0;
        private int m_playerTwoVictoriesCount = 0;
        private int m_boardSize;
        private bool m_isComputerPlayer;

        public static void Main()
        {
            UserInterface ui = new UserInterface();
            ui.GameWithScoreTrack();
        }

        public UserInterface()
        {
            m_boardSize = configureGameBoardSize();
            m_isComputerPlayer = configureIfComputerPlayer();
        }

        private void GameWithScoreTrack()
        {

            bool continuePlaying = true;
            GameLogic.eStepOutcome? finalOutcomeOfGame;
            
            while (continuePlaying)
            {
                Console.WriteLine(TextUIMessages.k_quitMessage);
                finalOutcomeOfGame = StartOneMatch();

                if (finalOutcomeOfGame == GameLogic.eStepOutcome.PlayerLost && m_currGameStepCounter % 2 == 0)
                {
                    m_playerTwoVictoriesCount++;
                }
                else if (finalOutcomeOfGame == GameLogic.eStepOutcome.ComputerLost ||
                         (finalOutcomeOfGame == GameLogic.eStepOutcome.PlayerLost && m_currGameStepCounter % 2 == 1))
                {
                    m_playerOneVictoriesCount++;
                }
                else if (finalOutcomeOfGame == null)
                {
                    Ex02.ConsoleUtils.Screen.Clear();
                    continue;
                }

                Ex02.ConsoleUtils.Screen.Clear();
                Console.WriteLine(string.Format(TextUIMessages.k_scoreMessage, m_playerOneVictoriesCount, m_playerTwoVictoriesCount));
                Thread.Sleep(5000);
                Ex02.ConsoleUtils.Screen.Clear();
            }
        }

        public GameLogic.eStepOutcome? StartOneMatch()
        {
            GameLogic currentGame;
            TextBoardDisplayer textBoardDisplayer;
            Point? currentUserCoordinates;

            GameLogic.eStepOutcome? currentStepOutcome = GameLogic.eStepOutcome.ValidMove;
            Console.WriteLine(TextUIMessages.k_welcomeMessage);

            m_currGameStepCounter = 0;
            currentGame = new GameLogic(m_boardSize, m_isComputerPlayer);
            textBoardDisplayer = new TextBoardDisplayer(currentGame.GameBoard);

            while (currentStepOutcome == GameLogic.eStepOutcome.ValidMove || currentStepOutcome == GameLogic.eStepOutcome.InvalidMove)
            {
                textBoardDisplayer.printBoard();
                currentUserCoordinates = getCoordinatesFromUser();

                if (!currentUserCoordinates.HasValue)
                {
                    currentStepOutcome = null;
                    break;
                }

                Ex02.ConsoleUtils.Screen.Clear();
                currentStepOutcome = currentGame.GameStep(currentUserCoordinates.Value.X - 1, currentUserCoordinates.Value.Y - 1);

                if (currentStepOutcome == GameLogic.eStepOutcome.ValidMove)
                {
                    m_currGameStepCounter++;
                }
                else if(currentStepOutcome == GameLogic.eStepOutcome.InvalidMove)
                {
                    Console.WriteLine(TextUIMessages.k_invalidInputMessage);
                    Thread.Sleep(1000);
                }
            }

            if (currentStepOutcome.HasValue)
            {
                printEndGameMessage(currentStepOutcome.Value, m_currGameStepCounter);
            }

            return currentStepOutcome;
        }

        private int configureGameBoardSize()
        {
            int value;

            while (true) {
                Console.WriteLine(TextUIMessages.k_gameBoardSizeSelectionMessage);
                string rawUserInput = Console.ReadLine();

                if (int.TryParse(rawUserInput, out value) && value >= k_lowerBoardSizeLimit && value <= k_upperBoardSizeLimit)
                {
                    break;
                }

                Console.WriteLine(TextUIMessages.k_invalidInputMessage);
            }

            return value;
        }

        private Point? getCoordinatesFromUser()
        {
            Point? point;

            while (true)
            {
                Console.WriteLine(TextUIMessages.k_cellSelectionMessage);
                string[] input = Console.ReadLine().Split();

                if (input.Length == 1 && input[0] == "Q")
                {
                    point = null;
                    break;
                }

                if (input.Length == 2 && int.TryParse(input[0], out int valueX) && int.TryParse(input[1], out int valueY))
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
            char computerOrhumanRival;
            bool isComputerPlayer;

            while (true)
            {
                Console.WriteLine(TextUIMessages.k_selectIfComputerPlayerMessage);
                string input = Console.ReadLine();

                if (char.TryParse(input, out computerOrhumanRival) && computerOrhumanRival == 'y' || computerOrhumanRival == 'n')
                {
                    isComputerPlayer = computerOrhumanRival == 'y';
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
                case GameLogic.eStepOutcome.PlayerLost:
                    Console.WriteLine(String.Format(TextUIMessages.k_humanWonMessage, (i_stepCounter % 2) + 1));
                    break;
                case GameLogic.eStepOutcome.ComputerLost:
                    Console.WriteLine(TextUIMessages.k_computerWonMessage);
                    break;
                case GameLogic.eStepOutcome.Draw:
                    Console.WriteLine(TextUIMessages.k_drawOutcomeMessage);
                    break;
            }

        }
    }
}

