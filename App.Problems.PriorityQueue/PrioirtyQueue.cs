using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Problems.PriorityQueue
{
  public class PriorityQueue<T>
  {
    public PriorityQueue()
    {
      Items = new SortedDictionary<int, Queue<T>>();
      Count = 0;
    }

    private SortedDictionary<int, Queue<T>> Items { get; set; }

    public int Count { get; private set; }

    public bool IsEmpty => Count == 0;

    public PriorityQueue<T> Enqueue(int priority, T item)
    {
      Queue<T> queue;

      if (!Items.TryGetValue(priority, out queue))
      {
        queue = new Queue<T>();
        Items.Add(priority, queue);
      }

      queue.Enqueue(item);
      Count++;

      return this;
    }

    public T Dequeue()
    {
      if (Count == 0)
        throw new Exception("Queue is empty");

      var firstPriority = Items.First();
      var queue = firstPriority.Value;

      T item = queue.Dequeue();
      Count--;

      if (queue.Count == 0)
        Items.Remove(firstPriority.Key);

      return item;
    }
  }
}
