using System;

namespace App.Problems.ParseTimeFromString
{
  class Program
  {
    static void Main(string[] args)
    {
      // Given a string of the form "Retries: 2; TotalTime: 10000; TotalTime: 5000; TotalTime: 2000", write
      // a function that returns  the total time
      //
      // The number of TotalTime occurrences is 1 + the number of Retries.
      //
      // DO NOT use regular expressions or any higher-level existing methods such as .NET's built-in
      // Int32.Parse() or Int32.TryParse().

      var parser = new Parser();

      int sum = parser.GetTotalTimeSum("Retries: 2; TotalTime: 10000; TotalTime: 5000; TotalTime: 2000");

      Console.WriteLine(sum);
    }
  }
}
