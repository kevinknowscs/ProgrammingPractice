using System;

namespace App.Algorithms.MaxSubarray
{
  public class BruteForceFinder : MaxSubarrayFinderBase
  {
    public override MaxSubarrayResult FindMaxSubarray(int[] values)
    {
      // A slow, O(n^2) algorithm

      var result = new MaxSubarrayResult() { Value = Int32.MinValue };

      for (int startIndex = 0; startIndex < values.Length; startIndex++)
      {
        int sum = 0;

        for (int endIndex = startIndex; endIndex < values.Length; endIndex++)
        {
          sum += values[endIndex];
          if (sum > result.Value)
          {
            result.StartIndex = startIndex;
            result.EndIndex = endIndex;
            result.Value = sum;
          }
        }
      }

      return result;
    }
  }
}
