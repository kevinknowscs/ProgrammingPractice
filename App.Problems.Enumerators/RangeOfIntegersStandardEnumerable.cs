using System.Collections;
using System.Collections.Generic;

namespace App.Problems.Enumerators
{
  class RangeOfIntegersStandardEnumerable : IEnumerable<int>
  {
    public RangeOfIntegersStandardEnumerable(RangeOfIntegers innerRange)
    {
      InnerRange = innerRange;
    }

    public RangeOfIntegers InnerRange { get; private set; }

    private IEnumerator<int> GetInnerEnumerator()
    {
      return new StandardEnumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetInnerEnumerator();
    }

    IEnumerator<int> IEnumerable<int>.GetEnumerator()
    {
      return GetInnerEnumerator();
    }

    private class StandardEnumerator : IEnumerator<int>
    { 
      public StandardEnumerator(RangeOfIntegersStandardEnumerable owner)
      {
        Owner = owner;
        CurrentValue = Owner.InnerRange.FirstValue - 1;
      }

      public RangeOfIntegersStandardEnumerable Owner { get; private set; }

      private int CurrentValue { get; set; }

      object IEnumerator.Current => CurrentValue;

      int IEnumerator<int>.Current => CurrentValue;

      public bool MoveNext()
      { 
        if (CurrentValue >= Owner.InnerRange.LastValue)
          return false;

        CurrentValue++;

        return true;
      }

      public void Reset()
      {
        CurrentValue = Owner.InnerRange.FirstValue - 1;
      }

      public void Dispose()
      {
      }
    }
  }
}
