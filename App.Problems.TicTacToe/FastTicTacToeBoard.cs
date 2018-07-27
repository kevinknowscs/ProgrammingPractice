using System;

namespace App.Problems.TicTacToe
{
  class FastTicTacToeBoard
  {
    public FastTicTacToeBoard(int size)
    {
      Size = size;
      Cells = new int[size, size];
      RowCounts = new int[size];
      ColumnCounts = new int[size];
      EraseBoard();
    }

    public int Size { get; private set; }

    public int TotalMovesMade { get; private set; }

    public int RemainingMoves => Size * Size - TotalMovesMade;

    private int[,] Cells { get; set; }

    private int[] RowCounts { get; set; }

    private int[] ColumnCounts { get; set; }

    private int Diagonal1Count { get; set; }

    private int Diagonal2Count { get; set; }

    public void EraseBoard()
    {
      for (int row = 0; row < Size; row++)
      {
        for (int col = 0; col < Size; col++)
          Cells[row, col] = 0;
      }

      for (int row = 0; row < Size; row++)
        RowCounts[row] = 0;

      for (int col = 0; col < Size; col++)
        ColumnCounts[col] = 0;

      Diagonal1Count = 0;
      Diagonal2Count = 0;
      TotalMovesMade = 0;
    }

    private bool IsCellAlongDiagnoal1(int row, int col)
    {
      return row == col;
    }

    private bool IsCellAlongDiagonal2(int row, int col)
    {
      return row == Size - 1 - col;
    }

    private bool CheckForWinAtRow(int row)
    {
      return Math.Abs(RowCounts[row]) == Size;
    }

    private bool CheckForWinAtColumn(int col)
    {
      return Math.Abs(ColumnCounts[col]) == Size;
    }

    private bool CheckForWinAtDiagonal1()
    {
      return Math.Abs(Diagonal1Count) == Size;
    }

    private bool CheckForWinAtDiagonal2()
    {
      return Math.Abs(Diagonal2Count) == Size;
    }

    private bool HasPlayerWonAfterMove(int row, int col)
    {
      // Fast algorithm for checking for a win
      // O(1) - Only check to see if the counters indicate a win. Don't
      // need to re-scan every cell

      return (
        CheckForWinAtRow(row) ||
        CheckForWinAtColumn(col) ||
        CheckForWinAtDiagonal1() ||
        CheckForWinAtDiagonal2()
      );
    }

    public bool MakeMoveAndCheckForWin(int row, int col, int playerId)
    {
      if (Cells[row, col] != 0)
        throw new Exception("The cell is not available");

      if (TotalMovesMade == Size * Size)
        throw new Exception("The board is full");

      Cells[row, col] = playerId;

      int increment = (playerId == 1) ? 1 : -1;
      RowCounts[row] += increment;
      ColumnCounts[col] += increment;

      if (IsCellAlongDiagnoal1(row, col))
        Diagonal1Count += increment;

      if (IsCellAlongDiagonal2(row, col))
        Diagonal2Count += increment;

      TotalMovesMade++;

      return HasPlayerWonAfterMove(row, col);
    }
  }
}
