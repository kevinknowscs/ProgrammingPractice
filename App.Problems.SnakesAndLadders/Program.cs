using System;

namespace App.Problems.SnakesAndLadders
{
  class Program
  {
    static void Main(string[] args)
    {
      var input = new int[,]
      {
        { -1, -1, -1, -1, -1, -1 },
        { -1, -1, -1, -1, -1, -1 },
        { -1, -1, -1, -1, -1, -1 },
        { -1, 35, -1, -1, 13, -1 },
        { -1, -1, -1, -1, -1, -1 },
        { -1, 15, -1, -1, -1, -1 }
      };

      var board = new SnakesAndLaddersBoard(6, input);

      Console.WriteLine(board.Solve());
    }
  }
}
