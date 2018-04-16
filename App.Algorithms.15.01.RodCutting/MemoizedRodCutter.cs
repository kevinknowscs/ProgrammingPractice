using System.Collections.Generic;

namespace App.Algorithms.RodCutting
{
  public class MemoizedRodCutter : RodCutterBase
  {
    private RodCutterResult CutRods(int[] prices, int rodLength, Dictionary<int, RodCutterResult> priorResults)
    {
      if (rodLength <= 0)
        return RodCutterResult.Empty;

      if (priorResults.ContainsKey(rodLength))
        return priorResults[rodLength];

      RodCutterResult bestResult = new RodCutterResult();

      for (int i = 1; i <= rodLength && i <= prices.Length; i++)
      {
        var innerResult = CutRods(prices, rodLength - i, priorResults);

        if (innerResult.TotalPrice + prices[i - 1] > bestResult.TotalPrice)
        {
          bestResult.CutLengths.Clear();
          bestResult.CutLengths.Add(i);
          bestResult.CutLengths.AddRange(innerResult.CutLengths);
          bestResult.TotalPrice = prices[i - 1] + innerResult.TotalPrice;
        }
      }

      priorResults.Add(rodLength, bestResult);

      return bestResult;
    }

    public override RodCutterResult CutRods(int[] prices, int rodLength)
    {
      return CutRods(prices, rodLength, new Dictionary<int, RodCutterResult>());
    }
  }
}
