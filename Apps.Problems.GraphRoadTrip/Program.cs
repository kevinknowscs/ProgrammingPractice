using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Problems.GraphRoadTrip
{
  class Program
  {
    static void Main(string[] args)
    {
      // Given a bi-directionally linked graph of nodes, where each node represents
      // a location with a population, consider the case where the entire population
      // must travel on a road trip to visit a given node. Nodes must travel through
      // their neighbors to get to the ultimate destination. For any given node, find
      // which neighbor will be bringing the largest population, and the magnitude
      // that neighbor is bringing. There are no cycles in the graph.
      //
      // Example: In the below example, if everyone needs to travel to Denver, then
      // 6 people are coming from Cheyenne, 15 are coming from Santa Fe (the 7 in 
      // Santa Fe itself, plush 3 from Las Cruce and 5 from Albuquerque), and 11 are
      // coming from Topeka. So the answer would be (Santa Fe, 15) because that is the
      // neighbor delivering the largest magnitude.
      //
      // Similarly, if everyone needs to travel to Santa Fe, then the answer would be
      // (Denver, 29).
      //
      // Assume the graph is large and the question may be posed repeatedly (i.e., think
      // about ways to maximize performance).

      var graph = new Graph();

      var denver = new Node() { Name = "Denver", Population = 12 };
      var cheyenne = new Node { Name = "Cheyenne", Population = 6 };
      var santafe = new Node() { Name = "Santa Fe", Population = 7 };
      var lascruces = new Node { Name = "Las Cruces", Population = 3 };
      var albuquerque = new Node() { Name = "Albuquerque", Population = 5 };
      var topeka = new Node() { Name = "Topeka", Population = 8 };
      var columbia = new Node() { Name = "Columbia", Population = 1 };
      var beatrice = new Node() { Name = "Beatrice", Population = 2 };

      denver.Neighbors.Add(cheyenne);
      denver.Neighbors.Add(santafe);
      denver.Neighbors.Add(topeka);

      cheyenne.Neighbors.Add(denver);

      santafe.Neighbors.Add(denver);
      santafe.Neighbors.Add(lascruces);
      santafe.Neighbors.Add(albuquerque);

      lascruces.Neighbors.Add(santafe);
      albuquerque.Neighbors.Add(santafe);

      topeka.Neighbors.Add(denver);
      topeka.Neighbors.Add(columbia);
      topeka.Neighbors.Add(beatrice);

      columbia.Neighbors.Add(topeka);
      beatrice.Neighbors.Add(topeka);

      graph.Nodes.Add(denver);
      graph.Nodes.Add(cheyenne);
      graph.Nodes.Add(santafe);
      graph.Nodes.Add(lascruces);
      graph.Nodes.Add(albuquerque);
      graph.Nodes.Add(topeka);
      graph.Nodes.Add(columbia);
      graph.Nodes.Add(beatrice);

      RoadTripMagnitudeResult result = null;

      Console.WriteLine("Travel to Denver");
      result = graph.GetRoadTripMagnitude(denver);
      Console.WriteLine(result.Node.Name);
      Console.WriteLine(result.Magnitude);
      Console.WriteLine();

      Console.WriteLine("Travel to Cheyenne");
      result = graph.GetRoadTripMagnitude(cheyenne);
      Console.WriteLine(result.Node.Name);
      Console.WriteLine(result.Magnitude);
      Console.WriteLine();

      Console.WriteLine("Travel to Santa Fe");
      result = graph.GetRoadTripMagnitude(santafe);
      Console.WriteLine(result.Node.Name);
      Console.WriteLine(result.Magnitude);
      Console.WriteLine();

      Console.WriteLine("Travel to Topeka");
      result = graph.GetRoadTripMagnitude(topeka);
      Console.WriteLine(result.Node.Name);
      Console.WriteLine(result.Magnitude);
      Console.WriteLine();
    }
  }
}
