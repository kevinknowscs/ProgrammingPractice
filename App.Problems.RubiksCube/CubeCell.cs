using System;
using System.Collections.Generic;
using System.Text;

namespace App.Problems.RubiksCube
{
  class CubeCell
  {
    public CubeCell(int color)
    {
      Color = color;
    }

    public int Color { get; }

    public string Label { get; }

    public string TempLabel { get; }
  }
}
