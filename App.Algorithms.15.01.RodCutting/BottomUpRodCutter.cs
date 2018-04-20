using System;
using System.Collections.Generic;

namespace App.Algorithms.RodCutting
{
  public class BottomUpRodCutter : RodCutterBase
  {
    public override RodCutterResult CutRods(int[] prices, int rodLength)
    {
      if (rodLength <= 0)
        return RodCutterResult.Empty;

      var results = new Dictionary<int, RodCutterResult>();

      results.Add(0, RodCutterResult.Empty);

      for (int j = 1; j <= rodLength; j++)
      {
        int maxPrice = Int32.MinValue;
        int maxLength = 0;
        RodCutterResult maxPriorResult = null;

        for (int i = 1; i <= j && i <= prices.Length; i++)
        {
          int currPrice = prices[i - 1] + results[j - i].TotalPrice;
          if (currPrice > maxPrice)
          {
            maxPrice = currPrice;
            maxLength = i;
            maxPriorResult = results[j - i];
          }
        }

        var currResult = new RodCutterResult();

        currResult.TotalPrice = maxPrice;
        currResult.CutLengths.Add(maxLength);
        currResult.CutLengths.AddRange(maxPriorResult.CutLengths);

        results.Add(j, currResult);
      }

      return results[rodLength];
    }
  }
}
