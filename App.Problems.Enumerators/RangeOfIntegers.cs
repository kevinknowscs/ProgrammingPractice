
namespace App.Problems.Enumerators
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

    public RangeOfIntegersStandardEnumerable GetStandardCursor()
    {
      return new RangeOfIntegersStandardEnumerable(this);
    }

    public RangeOfIntegersYieldingEnumerable GetYieldingCursor()
    {
      return new RangeOfIntegersYieldingEnumerable(this);
    }
  }
}
