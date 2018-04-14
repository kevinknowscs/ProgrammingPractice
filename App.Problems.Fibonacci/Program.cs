using System;

namespace App.Problems.Fibonacci
{
  class Program
  {
    static int RecursiveFibonacci(int n)
    {
      // An easy, but slow Fibonacci generator - O(2 ^ n) 

      if (n == 0)
        return 0;

      if (n == 1)
        return 1;

      return RecursiveFibonacci(n - 2) + RecursiveFibonacci(n - 1);
    }

    static int FastFibonacci(int n)
    {
      // A fast, iterative Fibonacci generator - O(n)

      if (n == 0)
        return 0;

      if (n == 1)
        return 1;

      int fibNMinus2 = 0;
      int fibNMinus1 = 1;
      int fibCurrent = 0;

      for (int x = 2; x <= n; x++)
      {
        fibCurrent = fibNMinus1 + fibNMinus2;

        fibNMinus2 = fibNMinus1;
        fibNMinus1 = fibCurrent;
      }

      return fibCurrent;
    }

    static void Main(string[] args)
    {
      Console.WriteLine("Recursive Fibonacci Algorithm");
      Console.WriteLine("-----------------------------");

      for (int x = 0; x < 20; x++)
        Console.WriteLine("Fib({0}) = {1}", x, RecursiveFibonacci(x));

      Console.WriteLine();
      Console.WriteLine("Fast Fibonacci Algorithm");
      Console.WriteLine("------------------------");

      for (int x = 0; x < 20; x++)
        Console.WriteLine("Fib({0}) = {1}", x, FastFibonacci(x));

      Console.WriteLine();
    }
  }
}
