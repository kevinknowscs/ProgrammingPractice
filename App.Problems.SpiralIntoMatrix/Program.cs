using System;

namespace App.Problems.SpiralIntoMatrix
{
  class Program
  {
    static void Main(string[] args)
    {
      int rowCount = 6;
      int colCount = 7;

      // States:
      //  0 -> Going left-to-right across a row
      //  1 -> Going top-to-bottom down a column
      //  2 -> Going right-to-left across a row
      //  3 -> Going bottom-to-top up a column

      int state = 0;
      int currRow = 0;
      int currCol = 0;
      int completedTopRow = -1;
      int completedBottomRow = rowCount;
      int completedLeftCol = -1;
      int completedRightCol = colCount;

      // There's more than one way to do this. Here I demonstrate how to use
      // a simple state machine to keep track of whether I'm moving right, down,
      // left, or up;

      for (int x = 0; x < rowCount * colCount; x++)
      {
        // Visit the current cell
        Console.WriteLine("Visiting {0}, {1}", currRow, currCol);

        switch (state)
        {
          case 0:
            if (currCol < completedRightCol - 1)
              currCol++;
            else
            {
              completedTopRow++;
              currRow++;
              state = 1;
            }
            break;

          case 1:
            if (currRow < completedBottomRow - 1)
              currRow++;
            else
            {
              completedRightCol--;
              currCol--;
              state = 2;
            }
            break;

          case 2:
            if (currCol > completedLeftCol + 1)
              currCol--;
            else
            {
              completedBottomRow--;
              currRow--;
              state = 3;
            }
            break;

          case 3:
            if (currRow > completedTopRow + 1)
              currRow--;
            else
            {
              completedLeftCol++;
              currCol++;
              state = 0;
            }
            break;
        }
      }
    }
  }
}
