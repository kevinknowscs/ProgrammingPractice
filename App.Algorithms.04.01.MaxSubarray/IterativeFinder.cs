using System;

namespace App.Algorithms.MaxSubarray
{
  public class IterativeFinder : MaxSubarrayFinderBase
  {
    public override MaxSubarrayResult FindMaxSubarray(int[] values)
    {
      // Fast algorithm by Kadane - O(n)
      //
      // Discussed briefly in Section 4.1-5 of Introduction to Algorithms, the reader
      // is encouraged to develop a non-recursive solution. This algorithm is also known
      // as Kadane's algorithm.
      //
      // More information: https://en.wikipedia.org/wiki/Maximum_subarray_problem
      //
      // My algorithm here is just slightly enhanced to track the start and end index, as
      // well as the actual value.
      //
      // This is a simple form of dynamic programming - results of solving subproblems
      // are passed up the solution chain.

      var result = new MaxSubarrayResult()
      {
        StartIndex = -1,
        EndIndex = -1,
        Value = Int32.MinValue
      };

      if (values.Length == 0)
        return result;

      result.StartIndex = 0;
      result.EndIndex = 0;
      result.Value = values[0];

      int currStartIndex = 0;
      int currEndIndex = 0;
      int currMax = values[0];

      for (int endIndex = 1; endIndex < values.Length; endIndex++)
      {
        if (currMax + values[endIndex] > values[endIndex])
        {
          currMax += values[endIndex];
          currEndIndex = endIndex;
        }
        else
        {
          currStartIndex = endIndex;
          currEndIndex = endIndex;
          currMax = values[endIndex];
        }

        if (currMax > result.Value)
        {
          result.StartIndex = currStartIndex;
          result.EndIndex = currEndIndex;
          result.Value = currMax;
        }
      }

      return result;
    }
  }
}
