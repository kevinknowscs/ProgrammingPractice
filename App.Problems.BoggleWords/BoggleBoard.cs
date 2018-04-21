using System;

namespace App.Problems.BoggleWords
{
  class BoggleBoard
  {
    private BoggleDice[] classicGameDice =
    {
      new BoggleDice("AACIOT", "      "),
      new BoggleDice("ABILTY", "      "),
      new BoggleDice("ABJMOQ", "     U"),
      new BoggleDice("ACDEMP", "      "),
      new BoggleDice("ACELRS", "      "),
      new BoggleDice("ADENVZ", "      "),
      new BoggleDice("AHMORS", "      "),
      new BoggleDice("BIFORX", "      "),
      new BoggleDice("DENOSW", "      "),
      new BoggleDice("DKNOTU", "      "),
      new BoggleDice("EEFHIY", "      "),
      new BoggleDice("EGKLUY", "      "),
      new BoggleDice("EGINTV", "      "),
      new BoggleDice("EHINPS", "      "),
      new BoggleDice("ELPSTU", "      "),
      new BoggleDice("GILRUW", "      "),
    };

    private BoggleDice[,] boardLayout;

    private int[,] selectedSides;

    public BoggleBoard(int rowCount, int columnCount)
    {
      RowCount = rowCount;
      ColumnCount = columnCount;

      boardLayout = new BoggleDice[rowCount, columnCount];
      selectedSides = new int[rowCount, columnCount];

      int index = 0;
      foreach (int randomNumber in new RandomNumberEnumerator(rowCount * columnCount))
      {
        boardLayout[index / columnCount, index % columnCount] = classicGameDice[randomNumber % classicGameDice.Length];
        index++;
      }

      var rng = new Random();

      for (int row = 0; row < rowCount; row++)
      {
        for (int col = 0; col < columnCount; col++)
        {
          selectedSides[row, col] = rng.Next(0, 5);
        }
      }
    }

    public int RowCount { get; private set; }

    public int ColumnCount { get; private set; }

    public char GetCharacter(int row, int col)
    {
      return boardLayout[row, col].FirstChars[selectedSides[row, col]];
    }

    public void Print()
    {
      for (int row=0; row < RowCount; row++)
      {
        for (int col=0; col < ColumnCount; col++)
        {
          Console.Write("{0} ", GetCharacter(row, col));
        }

        Console.WriteLine();
      }
    }
  }
}
