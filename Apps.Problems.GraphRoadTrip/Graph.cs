﻿using System.Collections.Generic;

namespace Apps.Problems.GraphRoadTrip
{
  class Graph
  {
    public Graph()
    {
      Nodes = new List<Node>();
      Magnitudes = new Dictionary<Node, RoadTripMagnitudeResult>();
      Populations = new Dictionary<Node, int>();
    }

    public List<Node> Nodes { get; private set; }

    public Dictionary<Node, RoadTripMagnitudeResult> Magnitudes { get; set; }

    public Dictionary<Node, int> Populations { get; set; }

    public RoadTripMagnitudeResult GetRoadTripMagnitude(Node node)
    {
      if (Magnitudes.ContainsKey(node))
        return Magnitudes[node];

      var result = new RoadTripMagnitudeResult() { Magnitude = 0 };

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
      int population = node.Population;

      foreach (var neighbor in node.Neighbors)
      {
        if (neighbor != excludeNode)
          population += GetPopulation(neighbor, node);
      }

      return population;
    }
  }
}
