using System;
using System.Collections.Generic;
using System.Text;

namespace App.Problems.SnakesAndLadders
{
  public class SnakesAndLaddersBoard
  {
    public SnakesAndLaddersBoard(int size, int [,] input)
    {
      Size = size;
      Input = input;
    }

    public int Size { get; }

    public int[,] Input { get; }

    private (int, int) GetRowAndColumn(int cellNo)
    {
      int row = Size - (cellNo - 1) / Size - 1;
      int rowOffset = (cellNo - 1) / Size;
      int offset = (cellNo - 1) % Size;
      int column = (rowOffset % 2 == 0) ? offset : Size - offset - 1;

      return (row, column);
    }

    private Dictionary<int, List<int>> ScanCells()
    {
      var result = new Dictionary<int, List<int>>();

      for (int cellNo=1; cellNo <= Size * Size; cellNo++)
      {
        (int row, int col) = GetRowAndColumn(cellNo);

        if (Input[row, col] != -1)
        {
          int indirectCellNo = Input[row, col];
          List<int> list = null;

          if (result.ContainsKey(indirectCellNo))
            list = result[indirectCellNo];
          else
          {
            list = new List<int>();
            result.Add(indirectCellNo, list);
          }

          list.Add(cellNo);
        }
      }

      return result;
    }

    public int Solve(Dictionary<int, List<int>> scanned, HashSet<int> currentSearch, Dictionary<int, int> saved, int cellNo)
    {
      if (saved.ContainsKey(cellNo))
        return saved[cellNo];

      if (cellNo == 1)
      {
        saved.Add(1, 0);
        return 0;
      }

      currentSearch.Add(cellNo);

      bool hasSolution = false;
      int min = Int32.MaxValue;

      if (scanned.ContainsKey(cellNo))
      {
        foreach (int indirectCellNo in scanned[cellNo])
        {
          if (!currentSearch.Contains(indirectCellNo))
          {
            int currResult = Solve(scanned, currentSearch, saved, indirectCellNo);
            if (currResult != -1 && currResult < min)
            {
              hasSolution = true;
              min = currResult;
            }
          }
        }
      }

      for (int prevCellNo=cellNo-1; prevCellNo > cellNo - 1 - Size && prevCellNo > 0; prevCellNo--)
      {
        (int currRow, int currColumn) = GetRowAndColumn(prevCellNo);

        if (Input[currRow, currColumn] == -1 && !currentSearch.Contains(prevCellNo))
        {
          int currResult = Solve(scanned, currentSearch, saved, prevCellNo);
          if (currResult != -1 && currResult + 1 < min)
          {
            hasSolution = true;
            min = currResult + 1;
          }
        }
      }

      int result = hasSolution ? min : -1;
      saved.Add(cellNo, result);
      currentSearch.Remove(cellNo);

      return result;
    }

    public int Solve()
    {
      return Solve(ScanCells(), new HashSet<int>(), new Dictionary<int, int>(), Size * Size);
    }
  }
}
