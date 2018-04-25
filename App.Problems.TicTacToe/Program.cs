using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Problems.TicTacToe
{
  class Program
  {
    static void Main(string[] args)
    {
      var board = new TicTacToeBoard(3);

      // 1 = X
      // 2 = 0

      //    |   |
      // ---+---+---
      //    | X |
      // ---+---+---
      //    |   |
      if (board.MakeMoveAndCheckForWin(1, 1, 1))
        Console.WriteLine("X has won the game");

      //  O |   |
      // ---+---+---
      //    | X |
      // ---+---+---
      //    |   |
      if (board.MakeMoveAndCheckForWin(0, 0, 2))
        Console.WriteLine("O has won the game");

      //  O |   |
      // ---+---+---
      //    | X |
      // ---+---+---
      //    |   | X
      if (board.MakeMoveAndCheckForWin(2, 2, 1))
        Console.WriteLine("X has won the game");

      //  O | O |
      // ---+---+---
      //    | X |
      // ---+---+---
      //    |   | X
      if (board.MakeMoveAndCheckForWin(0, 1, 2))
        Console.WriteLine("O has won the game");

      //  O | O | X
      // ---+---+---
      //    | X |
      // ---+---+---
      //    |   | X
      if (board.MakeMoveAndCheckForWin(0, 2, 1))
        Console.WriteLine("X has won the game");

      //  O | O | X
      // ---+---+---
      //    | X | O
      // ---+---+---
      //    |   | X
      if (board.MakeMoveAndCheckForWin(1, 2, 2))
        Console.WriteLine("O has won the game");

      //  O | O | X
      // ---+---+---
      //    | X | O
      // ---+---+---
      //  X |   | X
      //
      // X Wins
      if (board.MakeMoveAndCheckForWin(2, 0, 1))
        Console.WriteLine("X has won the game");
    }
  }
}
