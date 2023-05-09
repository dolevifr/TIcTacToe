using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIcTacToe
{
    class TextUIMessages
    {
        public const string k_welcomeMessage =
            "Hello and welcome to reverse tic tac toe game!";

        public const string k_gameBoardSizeSelectionMessage =
            "Please select an integer between 3-9 repressenting the size of the game board.";

        public const string k_cellSelectionMessage =
            "Please select a two integers representing between 1-boardSize repressenting a cell: example: '1 2'";

        public const string k_continueToPlayMessage =
            "Please select whether you want to continue playing another round (type y/n)";

        public const string k_selectIfComputerPlayerMessage =
            "Please select whether you want to play against the computer (type y/n)";

        public static string k_scoreMessage =
                "+---------------------+\n" +
                $"| PLAYER 1  | {0}   |\n" +
                $"| PLAYER 2  | {1}   |\n" +
                "+---------------------+\n";

        public const string k_quitMessage =
            "Please select whether you want to quit the game type Q for quiting";

        public const string k_invalidInputMessage = "Invalid input. Please try again.";

        public const string k_computerWonMessage = "Computer player has won the game.";

        public const string k_humanWonMessage = "Player{0} has won the game.";

        public const string k_drawOutcomeMessage = "Draw!";

        public const string k_gameOverMessage = @"
          _____          __  __ ______    ______      ________ _____  
         / ____|   /\   |  \/  |  ____|  / __ \ \    / /  ____|  __ \ 
        | |  __   /  \  | \  / | |__    | |  | \ \  / /| |__  | |__) |
        | | |_ | / /\ \ | |\/| |  __|   | |  | |\ \/ / |  __| |  _  / 
        | |__| |/ ____ \| |  | | |____  | |__| | \  /  | |____| | \ \ 
         \_____/_/    \_\_|  |_|______|  \____/   \/   |______|_|  \_\
         ";
    }
}
