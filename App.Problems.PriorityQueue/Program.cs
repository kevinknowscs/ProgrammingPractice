using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Problems.PriorityQueue
{
  class Program
  {
    static void Main(string[] args)
    {
      var priorityQueue = new PriorityQueue<string>();

      priorityQueue.Enqueue(100, "Lowest prioirty item");
      priorityQueue.Enqueue(1, "A high priority item");
      priorityQueue.Enqueue(1, "Another high priority item");
      priorityQueue.Enqueue(10, "A middle priority item");

      while (priorityQueue.Count != 0)
      {
        var item = priorityQueue.Dequeue();
        Console.WriteLine(item);
      }
    }
  }
}
