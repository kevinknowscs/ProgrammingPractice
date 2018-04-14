using System;

namespace App.Problems.Palindrome
{
  class Program
  {
    static bool IsPalindrome(string s)
    {
      // A simple function to determine if an arbitrary string is a Palindrome.

      if (s.Length <= 1)
        return true;

      for (int index = 0; index < s.Length / 2; index++)
      {
        if (s[index] != s[s.Length - 1 - index])
          return false;
      }

      return true;
    }

    static void Main(string[] args)
    {
      string[] testWords = { "", "x", "kevin", "kayak", "bb", "ab", "abba", "aba", "bbc" };

      foreach (string word in testWords)
      {
        Console.WriteLine("Word: '{0}', IsPalindrome: {1}", word, IsPalindrome(word));
      }
    }
  }
}
