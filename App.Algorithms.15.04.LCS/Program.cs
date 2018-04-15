using System;
using System.Text;

namespace App.Algorithms.LCS
{
  class Program
  {
    private class LcsSearchContext
    {
      public LcsLengthCell[,] LcsLengths { get; set; }

      public StringBuilder Output { get; set; }

      public string X { get; set; }

      public string Y { get; set; }
    }

    private static LcsLengthCell[,] GetLcsLength(string x, string y)
    {
      var result = new LcsLengthCell[x.Length + 1, y.Length + 1];

      for (int i = 1; i <= x.Length; i++)
        result[i, 0] = new LcsLengthCell() { Direction = SearchDirection.None, Length = 0 };

      for (int j = 1; j <= y.Length; j++)
        result[0, j] = new LcsLengthCell() { Direction = SearchDirection.None, Length = 0 };

      for (int i = 1; i <= x.Length; i++)
      {
        for (int j = 1; j <= y.Length; j++)
        {
          if (x[i-1] == y[j-1])
            result[i, j] = new LcsLengthCell() { Direction = SearchDirection.Diagonal, Length = result[i-1, j-1].Length + 1 };
          else if (result[i - 1, j].Length >= result[i, j - 1].Length)
            result[i, j] = new LcsLengthCell() { Direction = SearchDirection.Up, Length = result[i - 1, j].Length };
          else
            result[i, j] = new LcsLengthCell() { Direction = SearchDirection.Left, Length = result[i, j - 1].Length };
        }
      }

      return result;
    }

    private static void GetLcs(LcsSearchContext context, int lengthOfX, int lengthOfY)
    {
      if (lengthOfX == 0 || lengthOfY == 0)
        return;

      if (context.LcsLengths[lengthOfX, lengthOfY].Direction == SearchDirection.Diagonal)
      {
        GetLcs(context, lengthOfX - 1, lengthOfY - 1);
        context.Output.Append(context.X[lengthOfX - 1]);
      }
      else if (context.LcsLengths[lengthOfX, lengthOfY].Direction == SearchDirection.Up)
      {
        GetLcs(context, lengthOfX - 1, lengthOfY);
      }
      else
      {
        GetLcs(context, lengthOfX, lengthOfY - 1);
      }
    }

    private static string GetLcs(string x, string y)
    {
      var context = new LcsSearchContext();

      context.X = x;
      context.Y = y;
      context.Output = new StringBuilder();
      context.LcsLengths = GetLcsLength(x, y);

      GetLcs(context, x.Length, y.Length);

      return context.Output.ToString();
    }

    static void Main(string[] args)
    {
      // Compute the "Longest Common Subsequence" of two input strings, per the
      // dynamic programming algorithm outlined in Section 15.4 of Introduction to Algorithms

      var x = "ABCBDAB";
      var y = "BDCABA";

      Console.WriteLine();
      Console.WriteLine("x = {0}", x);
      Console.WriteLine("y = {0}", y);
      Console.WriteLine("Longest Common Subsequence = {0}", GetLcs(x, y));

      x = "ACCGGTCGAGTGCGCGGAAGCCGGCCGAA";
      y = "GTCGTTCGGAATGCCGTTGCTCTGTAAA";

      Console.WriteLine();
      Console.WriteLine("x = {0}", x);
      Console.WriteLine("y = {0}", y);
      Console.WriteLine("Longest Common Subsequence = {0}", GetLcs(x, y));
      Console.WriteLine();
    }
  }
}
