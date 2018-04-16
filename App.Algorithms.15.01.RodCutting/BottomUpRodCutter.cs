using System;

namespace App.Algorithms.RodCutting
{
  public class BottomUpRodCutter : RodCutterBase
  {
    public override RodCutterResult CutRods(int[] prices, int rodLength)
    {
      if (rodLength <= 0)
        return RodCutterResult.Empty;

      RodCutterResult bestResult = new RodCutterResult();

      for (int j = 1; j <= rodLength && j <= prices.Length; j++)
      {
        int maxPrice = Int32.MinValue;
        int maxIndex = 0;

        for (int i = 1; i <= j; i++)
        {
          //if ()
          //{

          //}
        }

        bestResult.CutLengths.Clear();

        //if (innerResult.TotalPrice + prices[i - 1] > bestResult.TotalPrice)
        //{
        //  bestResult.CutLengths.Clear();
        //  bestResult.CutLengths.Add(i);
        //  bestResult.CutLengths.AddRange(innerResult.CutLengths);
        //  bestResult.TotalPrice = prices[i - 1] + innerResult.TotalPrice;
        //}
      }

      // priorResults.Add(rodLength, bestResult);

      return bestResult;
    }
  }
}
