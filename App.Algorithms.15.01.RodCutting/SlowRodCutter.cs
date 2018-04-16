
namespace App.Algorithms.RodCutting
{
  public class SlowRodCutter : RodCutterBase
  {
    public override RodCutterResult CutRods(int[] prices, int rodLength)
    {
      if (rodLength <= 0)
        return RodCutterResult.Empty;

      RodCutterResult bestResult = new RodCutterResult();

      for (int i = 1; i <= rodLength && i <= prices.Length; i++)
      {
        var innerResult = CutRods(prices, rodLength - i);

        if (innerResult.TotalPrice + prices[i - 1] > bestResult.TotalPrice)
        {
          bestResult.CutLengths.Clear();
          bestResult.CutLengths.Add(i);
          bestResult.CutLengths.AddRange(innerResult.CutLengths);
          bestResult.TotalPrice = prices[i - 1] + innerResult.TotalPrice;
        }
      }

      return bestResult;
    }
  }
}
