using System;

namespace App.Algorithms.RodCutting
{
  class Program
  {
    static void Main(string[] args)
    {
      int[] prices = { 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 };

      var slowRodCutter = new SlowRodCutter();
      var memoizedRodCutter = new MemoizedRodCutter();
      var result = memoizedRodCutter.CutRods(prices, 50);

      foreach (var length in result.CutLengths)
        Console.WriteLine(length);

      Console.WriteLine();
      Console.WriteLine(result.TotalPrice);
    }
  }
}
