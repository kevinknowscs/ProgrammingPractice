using System;
using System.Collections.Generic;
using System.Text;

namespace App.Problems.RubiksCube
{
  public class CubeFace
  {
    public CubeFace(int color)
    {
      Cells = new CubeCell[4, 4];

      for (int row=0; row < 4; row++)
      {
        for (int col=0; col < 4; col++)
        {
          Cells[row, col] = new CubeCell(color);
        }
      }
    }

    private CubeCell[,] Cells { get; }

    private CubeFace Up { get; }

    private CubeFace Down { get; }

    private CubeFace Right { get; }

    private CubeFace Left { get; }
  }
}
