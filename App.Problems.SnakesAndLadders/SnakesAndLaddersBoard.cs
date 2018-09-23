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

    private int GetRow(int cellNo)
    {
      return Size - (cellNo - 1) / Size - 1;
    }

    private int GetColumn(int cellNo)
    {
      int rowOffset = (cellNo - 1) / Size;
      int offset = (cellNo - 1) % Size;

      return (rowOffset % 2 == 0) ? offset : Size - offset - 1;
    }

    private int GetCellNo(int row, int col)
    {
      return 0;
    }

    private Dictionary<int, List<int>> ScanCells()
    {
      var result = new Dictionary<int, List<int>>();

      for (int cellNo=1; cellNo <= Size * Size; cellNo++)
      {
        int row = GetRow(cellNo);
        int col = GetColumn(cellNo);

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

      int min = Int32.MaxValue;

      if (scanned.ContainsKey(cellNo))
      {
        foreach (int indirectCellNo in scanned[cellNo])
        {
          if (!currentSearch.Contains(indirectCellNo))
          {
            int currResult = Solve(scanned, currentSearch, saved, indirectCellNo);
            if (currResult < min)
              min = currResult;
          }
        }
      }

      for (int prevCellNo=cellNo-1; prevCellNo > cellNo - 1 - Size && prevCellNo > 0; prevCellNo--)
      {
        int currRow = GetRow(prevCellNo);
        int currColumn = GetColumn(prevCellNo);

        if (Input[currRow, currColumn] == -1)
        {
          if (!currentSearch.Contains(prevCellNo))
          {
            int currResult = Solve(scanned, currentSearch, saved, prevCellNo) + 1;
            if (currResult < min)
              min = currResult;
          }
        }
      }

      saved.Add(cellNo, min);
      currentSearch.Remove(cellNo);

      return min;
    }

    public int Solve()
    {
      return Solve(ScanCells(), new HashSet<int>(), new Dictionary<int, int>(), Size * Size);
    }
  }
}
