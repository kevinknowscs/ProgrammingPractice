using System.Collections.Generic;

namespace App.Problems.DigitalTrees
{
  public class DigitalTreeNode
  {
    public DigitalTreeNode()
    {
      NextNodes = new Dictionary<char, DigitalTreeNode>();
    }

    public Dictionary<char, DigitalTreeNode> NextNodes { get; private set; }

    public bool IsCompleteWord { get; set; }
  }
}
