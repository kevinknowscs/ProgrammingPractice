using System;

namespace App.Algorithms.MaxSubarray
{
  public class DivideAndConquerFinder : MaxSubarrayFinderBase
  {
    public MaxSubarrayResult FindMaxThroughMid(int[] values, int startIndex, int midIndex, int endIndex)
    {
      var result = new MaxSubarrayResult()
      {
        StartIndex = -1,
        EndIndex = -1,
        Value = Int32.MinValue
      };

      int maxLeft = Int32.MinValue;
      int leftSum = 0;

      for (int index = midIndex; index >= startIndex; index--)
      {
        leftSum += values[index];
        if (leftSum > maxLeft)
        {
          result.StartIndex = index;
          maxLeft = leftSum;
        }
      }

      int maxRight = Int32.MinValue;
      int rightSum = 0;

      for (int index = midIndex + 1; index <= endIndex; index++)
      {
        rightSum += values[index];
        if (rightSum > maxRight)
        {
          result.EndIndex = index;
          maxRight = rightSum;
        }
      }

      result.Value = maxLeft + maxRight;

      return result;
    }


    public MaxSubarrayResult FindMaxSubarray(int[] values, int startIndex, int endIndex)
    {
      // Divide and Conquer algorithm - O(n * log[n])

      var result = new MaxSubarrayResult();

      if (startIndex == endIndex)
      {
        result.StartIndex = startIndex;
        result.EndIndex = endIndex;
        result.Value = values[startIndex];

        return result;
      }

      int midIndex = (startIndex + endIndex) / 2;

      var leftResult = FindMaxSubarray(values, startIndex, midIndex);
      var rightResult = FindMaxSubarray(values, midIndex + 1, endIndex);
      var midResult = FindMaxThroughMid(values, startIndex, midIndex, endIndex);

      if (leftResult.Value >= midResult.Value && leftResult.Value >= rightResult.Value)
        return leftResult;

      if (rightResult.Value >= leftResult.Value && rightResult.Value >= midResult.Value)
        return rightResult;

      return midResult;
    }

    public override MaxSubarrayResult FindMaxSubarray(int[] values)
    {
      return FindMaxSubarray(values, 0, values.Length - 1);
    }
  }
}
