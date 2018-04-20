using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Problems.Enumerators.cs
{
  class Program
  {
    static void Main(string[] args)
    {
      // Just a simple program to demonstrate how to write Enumerators using C#,
      // both with the traditional Reset/MoveNext/Current style, and using yield return.

      var myRange = new RangeOfIntegers(10, 20);

      Console.WriteLine();
      Console.WriteLine("List Range of Integers with Standard Enumerator");
      Console.WriteLine("-----------------------------------------------");

      foreach (int val in myRange.GetStandardCursor())
        Console.WriteLine(val);

      Console.WriteLine();

      Console.WriteLine("List Range of Integers with Yielding Enumerator");
      Console.WriteLine("-----------------------------------------------");

      foreach (int val in myRange.GetYieldingCursor())
        Console.WriteLine(val);

      Console.WriteLine();
    }
  }
}
