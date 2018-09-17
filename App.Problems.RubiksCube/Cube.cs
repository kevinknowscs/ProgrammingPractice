using System;
using System.Collections.Generic;
using System.Text;

namespace App.Problems.RubiksCube
{
  public class Cube
  {

    public Cube()
    {
      var blueFace = new CubeFace(0);
      var redFace = new CubeFace(1);
      var greenFace = new CubeFace(2);
      var orangeFace = new CubeFace(3);
      var yellowFace = new CubeFace(4);
      var whiteFace = new CubeFace(5);

      Top = blueFace;
      Front = redFace;
      Bottom = greenFace;
      Back = orangeFace;
      Right = yellowFace;
      Left = whiteFace;
    }

    public CubeFace Top { get; private set; }

    public CubeFace Front { get; private set; }

    public CubeFace Bottom { get; private set; }

    public CubeFace Back { get; private set; }

    public CubeFace Right { get; private set; }

    public CubeFace Left { get; private set; }
  }
}
