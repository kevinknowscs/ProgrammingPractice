using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace App.Problems.DigitalTrees
{
  public class DigitalTree : IEnumerable<string>
  {
    public DigitalTree()
    {
      RootNode = new DigitalTreeNode();
    }

    public DigitalTreeNode RootNode { get; private set; }

    public void LoadWords(string[] words)
    {
      DigitalTreeNode currNode, newNode;

      foreach (string word in words)
      {
        currNode = RootNode;

        foreach (char ch in word)
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
