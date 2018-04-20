using System;

namespace App.Algorithms.RodCutting
{
  class Program
  {
    static void PrintResults(int[] prices, string name, RodCutterBase rodCutter)
    {
      string header = "Cutting Rods: ";

      Console.WriteLine(header + name);
      Console.WriteLine(new String('-', header.Length + name.Length));

      int index = 0;
      var result = rodCutter.CutRods(prices, 99);

      foreach (var length in result.CutLengths)
      {
        Console.WriteLine("Cut: {0}, Length: {1}, Price: {2}", (index++) + 1, length, prices[length - 1]);
      }

      Console.WriteLine();
      Console.WriteLine("Total Price of Cut Rods: {0}", result.TotalPrice);
      Console.WriteLine();
    }

    static void Main(string[] args)
    {
      int[] prices = { 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 };

      var slowRodCutter = new SlowRodCutter();
      var memoizedRodCutter = new MemoizedRodCutter();
      var bottomUpRodCutter = new BottomUpRodCutter();

      Console.WriteLine();

      // PrintResults(prices, "Slow Version", slowRodCutter);
      PrintResults(prices, "Memoized Version", memoizedRodCutter);
      PrintResults(prices, "Bottom Up Version", bottomUpRodCutter);
    }
  }
}
