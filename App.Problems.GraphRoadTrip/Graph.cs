using System.Collections.Generic;

namespace App.Problems.GraphRoadTrip
{
  class Graph
  {
    public Graph()
    {
      Nodes = new List<Node>();
      Magnitudes = new Dictionary<Node, RoadTripMagnitudeResult>();
      Populations = new Dictionary<KeyValuePair<Node, Node>, int>();
    }

    public List<Node> Nodes { get; private set; }

    public Dictionary<Node, RoadTripMagnitudeResult> Magnitudes { get; set; }

    public Dictionary<KeyValuePair<Node, Node>, int> Populations { get; set; }

    public RoadTripMagnitudeResult GetRoadTripMagnitude(Node node)
    {
      RoadTripMagnitudeResult result;

      if (Magnitudes.TryGetValue(node, out result))
        return result;

      result = new RoadTripMagnitudeResult() { Magnitude = 0 };

      foreach (var neighbor in node.Neighbors)
      {
        int neighborPopulation = GetPopulation(neighbor, node);

        if (neighborPopulation > result.Magnitude)
        {
          result.Node = neighbor;
          result.Magnitude = neighborPopulation;
        }
      }

      Magnitudes.Add(node, result);

      return result;
    }

    private int GetPopulation(Node node, Node excludeNode)
    {
      int population;
      var key = new KeyValuePair<Node, Node>(node, excludeNode);

      if (Populations.TryGetValue(key, out population))
        return population;

      population = node.Population;

      foreach (var neighbor in node.Neighbors)
      {
        if (neighbor != excludeNode)
          population += GetPopulation(neighbor, node);
      }

      Populations[key] = population;

      return population;
    }
  }
}
