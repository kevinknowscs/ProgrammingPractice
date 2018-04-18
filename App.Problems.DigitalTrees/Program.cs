using System;

namespace App.Problems.DigitalTrees
{ 
  /// <summary>
  /// A simple implementation of a digital search tree that can store and
  /// find words with similar prefixes
  /// </summary>
  
  class Program
  {
    static void Main(string[] args)
    {
      var digitalTree = new DigitalTree();

      var words = new string[]
      {
        "",
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

      digitalTree.LoadWords(words);

      var testWords = new string[]
      {
        "about",
        "abo",
        "ab",
        "above",
        "missing",
        "aboutxxx",
        ""
      };

      foreach (string testWord in testWords)
      {
        Console.WriteLine("'{0}' : {1}", testWord, digitalTree.ContainsWord(testWord) ? "Found" : "Not Found");
      }

      Console.WriteLine();
      Console.WriteLine("Here are the words in the dictionary");
      Console.WriteLine("------------------------------------");

      foreach (string word in digitalTree)
        Console.WriteLine("'{0}'", word);

      Console.WriteLine();
    }
  }
}
