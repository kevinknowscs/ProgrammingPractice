using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Problems.BoggleWords
{
  class Program
  {
    static void Main(string[] args)
    {
      var dictionary = new string[]
      {
        "a",
        "about",
        "above",
        "across",
        "after",
        "along",
        "among",
        "around",
        "at",
        "before",
        "behind",
        "below"
      };

      var wordDictionary = new WordDictionary();

      Console.WriteLine("Loading words into dictionary ...");
      wordDictionary.LoadWords(dictionary);

      var boggleBoard = new BoggleBoard(4, 4);

      var finder = new BoggleWordFinder(boggleBoard, wordDictionary);
      var result = finder.FindWords();

      foreach (int randomNumber in new RandomNumberEnumerator(16))
        Console.WriteLine(randomNumber);
    }
  }
}
