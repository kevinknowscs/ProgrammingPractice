using System;

namespace App.Problems.NumberToEnglish
{
  class Program
  {
    static void TestRange(int low, int high)
    {
      for (int x = low; x <= high; x++)
        Console.WriteLine("{0} : {1}", x, EnglishNumberConverter.Convert(x));
    }

    static void TestValue(int val)
    {
      Console.WriteLine("{0} : {1}", val, EnglishNumberConverter.Convert(val));
    }

    static void Main(string[] args)
    {
      TestRange(0, 1010);
      TestRange(9050, 10100);
      TestRange(99050, 101999);
      TestRange(9999995, 1000999);

      TestValue(1000);
      TestValue(10000);
      TestValue(100000);
      TestValue(1000000);
      TestValue(10000000);
      TestValue(100000000);
      TestValue(1000000000);
      TestValue(567891);
    }
  }
}
