using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Problems.GraphRoadTrip
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
