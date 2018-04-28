using System.Collections;
using System.Collections.Generic;

namespace App.Problems.Enumerators
{
  class RangeOfIntegersYieldingCursor : IEnumerable<int>
  {
    public RangeOfIntegersYieldingCursor(RangeOfIntegers innerRange)
    {
      InnerRange = innerRange;
    }

    public RangeOfIntegers InnerRange { get; private set; }

    private IEnumerator<int> GetInnerEnumerator()
    {
      for (int x = InnerRange.FirstValue; x <= InnerRange.LastValue; x++)
        yield return x;
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
