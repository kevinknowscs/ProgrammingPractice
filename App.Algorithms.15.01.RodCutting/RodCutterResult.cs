using System.Collections.Generic;

namespace App.Algorithms.RodCutting
{
  public class RodCutterResult
  {
    static RodCutterResult()
    {
      Empty = new RodCutterResult();
    }

    public RodCutterResult()
    {
      CutLengths = new List<int>();
      TotalPrice = 0;
    }

    public int TotalPrice { get; set; }

    public List<int> CutLengths { get; private set; }

    public static RodCutterResult Empty { get; private set; }
  }
}
