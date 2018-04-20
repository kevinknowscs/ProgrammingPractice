using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Problems.Enumerators.cs
{
  class RangeOfIntegersStandardCursor : IEnumerable<int>
  {
    public RangeOfIntegersStandardCursor(RangeOfIntegers innerRange)
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
      public StandardEnumerator(RangeOfIntegersStandardCursor cursor)
      {
        Cursor = cursor;
        CurrentValue = Cursor.InnerRange.FirstValue - 1;
      }

      public RangeOfIntegersStandardCursor Cursor { get; private set; }

      private int CurrentValue { get; set; }

      object IEnumerator.Current
      {
        get
        {
          return CurrentValue;
        }
      }

      int IEnumerator<int>.Current
      {
        get
        {
          return CurrentValue;
        }
      }

      public bool MoveNext()
      { 
        if (CurrentValue >= Cursor.InnerRange.LastValue)
          return false;

        CurrentValue++;

        return true;
      }

      public void Reset()
      {
        CurrentValue = Cursor.InnerRange.FirstValue - 1;
      }

      public void Dispose()
      {
      }
    }
  }
}
