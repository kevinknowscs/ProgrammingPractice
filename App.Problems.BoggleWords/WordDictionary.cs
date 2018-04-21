using System.IO;

namespace App.Problems.BoggleWords
{
  class WordDictionary
  {
    public WordDictionary()
    {
      InnerTree = new DigitalTree();
    }

    private DigitalTree InnerTree { get; set; }

    public DigitalTreeNode RootTreeNode => InnerTree.RootNode;

    public void LoadWords(string[] words)
    {
      InnerTree.LoadWords(words);
    }

    public void LoadWords(Stream words)
    {
      InnerTree.LoadWords(words);
    }
  }
}
