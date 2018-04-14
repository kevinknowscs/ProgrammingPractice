using System;

namespace App.Algorithms.MaxSubarray
{
  class Program
  {
    static void PrintResult(string method, MaxSubarrayResult result)
    {
      string heading = "Max Subarray Result, Method = ";

      Console.WriteLine("{0}{1}", heading, method);
      Console.WriteLine(new String('-', heading.Length + method.Length));

      Console.WriteLine("Start Index: {0}", result.StartIndex);
      Console.WriteLine("End Index  : {0}", result.EndIndex);
      Console.WriteLine("Value      : {0}", result.Value);
      Console.WriteLine();
    }

    static void Main(string[] args)
    {
      int[] data = { 0, 13, -3, -25, -20, -3, -16, -23, 18, 20, -7, 12, -5, -22, 15, -4, 7 };

      var bruteForce = new BruteForceFinder();
      var divideAndConquer = new DivideAndConquerFinder();
      var iterative = new IterativeFinder();

      PrintResult("Brute Force", bruteForce.FindMaxSubarray(data));
      PrintResult("Divide and Conquer", divideAndConquer.FindMaxSubarray(data));
      PrintResult("Iterative", iterative.FindMaxSubarray(data));
    }
  }
}
