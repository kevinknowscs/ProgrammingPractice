using System;
using System.Collections.Generic;

namespace App.Algorithms.LCS
{
  public class LcsLengthsMatrix
  {
    public LcsLengthsMatrix(string x, string y)
    {
      X = x;
      Y = y;

      LcsLengths = new Dictionary<int, LcsLengthCell>();
      ZeroNone = new LcsLengthCell() { Direction = SearchDirection.None, Length = 0 };
      ZeroUp = new LcsLengthCell() { Direction = SearchDirection.Up, Length = 0 };
      ZeroLeft = new LcsLengthCell() { Direction = SearchDirection.Left, Length = 0 };
    }

    private string X { get; set; }

    private string Y { get; set; }

    private LcsLengthCell ZeroNone { get; set; }

    private LcsLengthCell ZeroUp { get; set; }

    private LcsLengthCell ZeroLeft { get; set; }

    private Dictionary<int, LcsLengthCell> LcsLengths { get; set; }

    public LcsLengthCell this[int i, int j]
    {
      get
      {
        if (i < 0 && j < 0)
          return ZeroNone;

        if (j < 0)
          return ZeroUp;

        if (i < 0)
          return ZeroLeft;

        int key = i * Y.Length + j;

        if (LcsLengths.ContainsKey(key))
          return LcsLengths[key];

        var cell = new LcsLengthCell();
        var upLength = this[i - 1, j].Length;
        var leftLength = this[i, j -1].Length;

        cell.Length = Math.Max(upLength, leftLength) + 1;

        if (i >= X.Length - 1)
          cell.Direction = SearchDirection.Right;
        else if (j >= Y.Length - 1)
          cell.Direction = SearchDirection.Down;
        else if (X[i] == Y[j])
          cell.Direction = SearchDirection.Diagonal;
        else
        {
          var downLength = this[i + 1, j].Length;
          var rightLength = this[i, j + 1].Length;
          cell.Direction = (rightLength >= downLength) ? SearchDirection.Right : SearchDirection.Down;
        }

        LcsLengths.Add(key, cell);

        return cell;
      }
    }
  }
}
