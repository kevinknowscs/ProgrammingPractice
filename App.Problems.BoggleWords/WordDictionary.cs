using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
  }
}
