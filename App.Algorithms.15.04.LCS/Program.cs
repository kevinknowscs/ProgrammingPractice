using System;

namespace App.Algorithms.LCS
{
  internal class Program
  {
    private static void PrintResults(string x, string y, string lcs)
    {
      Console.WriteLine();
      Console.WriteLine("x = {0}", x);
      Console.WriteLine("y = {0}", y);
      Console.WriteLine("Longest Common Subsequence = {0}", lcs);
    }

    internal static void Main(string[] args)
    {
      // Compute the "Longest Common Subsequence" of two input strings, per the
      // dynamic programming algorithm outlined in Section 15.4 of Introduction to Algorithms

      string x, y;
      var lcsFinder = new LcsFinder();

      x = "ABCBDAB";
      y = "BDCABA";
      PrintResults(x, y, lcsFinder.FindLcs(x, y));

      x = "ACCGGTCGAGTGCGCGGAAGCCGGCCGAA";
      y = "GTCGTTCGGAATGCCGTTGCTCTGTAAA";
      PrintResults(x, y, lcsFinder.FindLcs(x, y));

      x = "10010101";
      y = "010110110";
      PrintResults(x, y, lcsFinder.FindLcs(x, y));

      Console.WriteLine();
    }
  }
}
