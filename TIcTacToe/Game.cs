using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIcTacToe
{
    class Game
    {
        public static void Main()
        {
            Board board = new Board(3);
            ValidateWin validator = new ValidateWin(board);

            for(int i = 0; i < 3; i++)
            {
                board.SetCellInBoard(i, i, Board.eCell.X);
                System.Console.WriteLine(validator.IsWinner(i, i));
            }
        }
    }
}
