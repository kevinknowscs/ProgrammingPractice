using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace App.Problems.BoggleWords
{
  public class DigitalTree : IEnumerable<string>
  {
    public DigitalTree()
    {
      RootNode = new DigitalTreeNode();
    }

    public DigitalTreeNode RootNode { get; private set; }

    private void LoadWord(string word)
    {
      DigitalTreeNode currNode, newNode;

      var upperWord = word.ToUpper();
      currNode = RootNode;

      foreach (char ch in upperWord)
      {
        if (currNode.NextNodes.ContainsKey(ch))
          currNode = currNode.NextNodes[ch];
        else
        {
          newNode = new DigitalTreeNode();
          currNode.NextNodes.Add(ch, newNode);
          currNode = newNode;
        }
      }

      currNode.IsCompleteWord = true;
    }

    public void LoadWords(string[] words)
    {
      foreach (string word in words)
        LoadWord(word);
    }

    public void LoadWords(Stream wordStream)
    {
      using (var reader = new StreamReader(wordStream))
      {
        string line;

        while ((line = reader.ReadLine()) != null)
          LoadWord(line.Trim());
      }
    }

    public bool ContainsWord(string word)
    {
      DigitalTreeNode currNode = RootNode;

      foreach (char ch in word)
      {
        if (!currNode.NextNodes.ContainsKey(ch))
          return false;

        currNode = currNode.NextNodes[ch];
      }

      return (currNode == null) ? false : currNode.IsCompleteWord;
    }

    private IEnumerable<string> InnerEnumerator(DigitalTreeNode currNode, StringBuilder prefix)
    {
      if (currNode.IsCompleteWord)
        yield return prefix.ToString();

      foreach (char ch in currNode.NextNodes.Keys)
      {
        prefix.Append(ch);

        foreach (string word in InnerEnumerator(currNode.NextNodes[ch], prefix))
          yield return word;

        prefix.Remove(prefix.Length - 1, 1);
      }
    }

    private IEnumerator<string> InnerEnumerator()
    {
      var prefix = new StringBuilder();

      foreach (string word in InnerEnumerator(RootNode, prefix))
        yield return word;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return this.InnerEnumerator();
    }

    IEnumerator<string> IEnumerable<string>.GetEnumerator()
    {
      return this.InnerEnumerator();
    }
  }
}
