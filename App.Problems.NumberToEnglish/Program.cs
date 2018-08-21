using System;

namespace App.Problems.NumberToEnglish
{
  class Program
  {
    static void Main(string[] args)
    {
      for (int x = 500000; x < 501000; x++)
        Console.WriteLine("{0} : {1}", x, EnglishNumberConverter.Convert(x));
    }
  }
}
