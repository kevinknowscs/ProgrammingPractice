using System;

namespace App.Problems.TicTacToe
{
  public class SlowTicTacToeBoard
  {
    public SlowTicTacToeBoard(int size)
    {
      Size = size;
      Cells = new int[size, size];
      EraseBoard();
    }

    public int Size { get; private set; }

    public int TotalMovesMade { get; private set; }

    public int RemainingMoves => Size * Size - TotalMovesMade;

    private int[,] Cells { get; set; }

    private bool CheckForWinAtRow(int row, int playerId)
    {
      for (int col = 0; col < Size; col++)
      {
        if (Cells[row, col] != playerId)
          return false;
      }

      return true;
    }

    private bool CheckForWinAtColumn(int col, int playerId)
    {
      for (int row = 0; row < Size; row++)
      {
        if (Cells[row, col] != playerId)
          return false;
      }

      return true;
    }

    private bool IsCellAlongDiagnoal1(int row, int col)
    {
      return row == col;
    }

    private bool IsCellAlongDiagonal2(int row, int col)
    {
      return row == Size - 1 - col;
    }

    private bool CheckForWinAtDiagonal1(int playerId)
    {
      for (int row = 0; row < Size; row++)
      {
        if (Cells[row, row] != playerId)
          return false;
      }

      return true;
    }

    private bool CheckForWinAtDiagonal2(int playerId)
    {
      for (int row = Size - 1; row >= 0; row--)
      {
        if (Cells[row, Size - 1 - row] != playerId)
          return false;
      }

      return true;
    }

    private bool CheckForWinAtAllRows(int playerId)
    {
      // Scan each row
      for (int currRow = 0; currRow < Size; currRow++)
      {
        if (CheckForWinAtRow(currRow, playerId))
          return true;
      }

      return false;
    }

    private bool CheckForWinAtAllColumns(int playerId)
    {
      // Scan each column
      for (int currCol = 0; currCol < Size; currCol++)
      {
        if (CheckForWinAtColumn(currCol, playerId))
          return true;
      }

      return false;
    }

    private bool HasPlayerWon(int playerId)
    {
      // Slow O(N^2) algorithm
      // Re-scan all rows, columns, and diagonals

      return (
        CheckForWinAtAllRows(playerId) ||
        CheckForWinAtAllColumns(playerId) ||
        CheckForWinAtDiagonal1(playerId) ||
        CheckForWinAtDiagonal2(playerId)
      );
    }

    public void EraseBoard()
    {
      for (int row = 0; row < Size; row++)
      {
        for (int col = 0; col < Size; col++)
          Cells[row, col] = 0;
      }

      TotalMovesMade = 0;
    }

    public bool MakeMoveAndCheckForWin(int row, int col, int playerId)
    {
      if (Cells[row, col] != 0)
        throw new Exception("The cell is not available");

      if (TotalMovesMade == Size * Size)
        throw new Exception("The board is full");

      Cells[row, col] = playerId;
      TotalMovesMade++;

      return HasPlayerWon(playerId);
    }
  }
}
