
namespace App.Problems.Enumerators.cs
{
  class RangeOfIntegers
  {
    public RangeOfIntegers()
    {
      FirstValue = 0;
      LastValue = -1;
    }

    public RangeOfIntegers(int firstValue, int lastValue)
    {
      FirstValue = firstValue;
      LastValue = lastValue;
    }

    public int FirstValue { get; set; }

    public int LastValue { get; set; }

    public RangeOfIntegersStandardCursor GetStandardCursor()
    {
      return new RangeOfIntegersStandardCursor(this);
    }

    public RangeOfIntegersYieldingCursor GetYieldingCursor()
    {
      return new RangeOfIntegersYieldingCursor(this);
    }
  }
}
