using System;
using System.Collections;
using System.Collections.Generic;

namespace App.Problems.BoggleWords
{
  class RandomNumberEnumerator : IEnumerable<int>
  {
    public RandomNumberEnumerator(int size)
    {
      Size = size;
    }

    public int Size { get; private set; }

    private IEnumerator<int> GetInnerEnumerator()
    {
      var numbers = new List<int>();
      var rng = new Random();

      for (int x = 0; x < Size; x++)
        numbers.Add(x);

      for (int x = Size - 1; x >= 0; x--)
      {
        var random = rng.Next(0, x);
        var nextNumber = numbers[random];
        numbers.RemoveAt(random);

        yield return nextNumber;
      }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetInnerEnumerator();
    }

    IEnumerator<int> IEnumerable<int>.GetEnumerator()
    {
      return GetInnerEnumerator();
    }
  }
}
