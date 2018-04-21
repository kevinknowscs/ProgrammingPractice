using System;
using System.Reflection;

namespace App.Problems.BoggleWords
{
  class Program
  {
    static void Main(string[] args)
    {
      var wordDictionary = new WordDictionary();

      wordDictionary.LoadWords(Assembly.GetExecutingAssembly().GetManifestResourceStream("App.Problems.BoggleWords.Dictionary.txt"));

      // Have fun with it and try different board sizes
      var boggleBoard = new BoggleBoard(4, 4);

      boggleBoard.Print();
      Console.WriteLine();

      var finder = new BoggleWordFinder(boggleBoard, wordDictionary);
      var results = finder.FindWords();

      Console.WriteLine("Found {0} words", results.Count);
      Console.WriteLine();

      int index = 1;

      foreach (var pathList in results)
      {
        Console.Write("Word {0} : ", index++);

        foreach (var wordPathNode in pathList)
          Console.Write(wordPathNode.Character);

        Console.Write("   ");

        foreach (var wordPathNode in pathList)
        {
          Console.Write("({0}, {1}) = {2}  ", wordPathNode.Row, wordPathNode.Column, wordPathNode.Character);
        }

        Console.WriteLine();
      }
    }
  }
}
