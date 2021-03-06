﻿using System;

namespace App.Problems.NumberToEnglish
{
  class Program
  {
    static void PrintRange(int low, int high)
    {
      Console.WriteLine();
      Console.WriteLine("Values from {0} to {1}:", low, high);

      for (int x = low; x <= high; x++)
        Console.WriteLine("{0} = '{1}'", x, EnglishNumberConverter.Convert(x));
    }

    static void PrintValue(int val)
    {
      Console.WriteLine("{0} = '{1}'", val, EnglishNumberConverter.Convert(val));
    }

    static void TestValue(int val, string expected)
    {
      string result = EnglishNumberConverter.Convert(val);

      if (result != expected)
      {
        Console.WriteLine("FAILED at Value: {0}", val);
        Console.WriteLine("  Expected: '{0}'", expected);
        Console.WriteLine("  Received: '{0}'", result);
      }

      Console.WriteLine("PASSED: {0} = '{1}'", val, result);
    }
    static void Main(string[] args)
    {
      PrintRange(0, 20);
      PrintRange(95, 105);
      PrintRange(995, 1010);

      Console.WriteLine();
      Console.WriteLine("Some Edge Cases");
      Console.WriteLine("---------------");
      PrintValue(Int32.MaxValue);
      PrintValue(Int32.MinValue + 1);

      Console.WriteLine();
      Console.WriteLine("Some Random Values");
      Console.WriteLine("------------------");
      var rng = new Random(0);

      for (int x = 0; x < 10; x++)
        PrintValue(rng.Next(10, 100));

      for (int x = 0; x < 10; x++)
        PrintValue(rng.Next(995, 1999));

      for (int x = 0; x < 10; x++)
        PrintValue(rng.Next(999950, 1500000));

      Console.WriteLine();
      Console.WriteLine("Testing Values");
      Console.WriteLine("--------------");
      TestValue(0, "Zero");
      TestValue(10, "Ten");
      TestValue(15, "Fifteen");
      TestValue(99, "Ninety Nine");
      TestValue(101, "One Hundred One");
      TestValue(999, "Nine Hundred Ninety Nine");
      TestValue(1000, "One Thousand");
      TestValue(1001, "One Thousand One");
      TestValue(9999, "Nine Thousand Nine Hundred Ninety Nine");
      TestValue(567891, "Five Hundred Sixty Seven Thousand Eight Hundred Ninety One");
      TestValue(10000, "Ten Thousand");
      TestValue(10001, "Ten Thousand One");
      TestValue(100000, "One Hundred Thousand");
      TestValue(100001, "One Hundred Thousand One");
      TestValue(1000000, "One Million");
      TestValue(1000001, "One Million One");
      TestValue(10000000, "Ten Million");
      TestValue(10000001, "Ten Million One");
      TestValue(100000000, "One Hundred Million");
      TestValue(100000001, "One Hundred Million One");
      TestValue(1000000000, "One Billion");
      TestValue(1000000001, "One Billion One");
    }
  }
}
