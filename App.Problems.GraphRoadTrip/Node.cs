using System.Collections.Generic;

namespace App.Problems.GraphRoadTrip
{
  class Node
  {
    public Node()
    {
      Neighbors = new List<Node>();
    }

    public string Name { get; set; }

    public int Population { get; set; }

    public List<Node> Neighbors { get; private set; }
  }
}
