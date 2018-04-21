using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public BoggleBoard(int rowCount, int columnCount)
    {
      RowCount = rowCount;
      ColumnCount = columnCount;

      boardLayout = new BoggleDice[rowCount, columnCount];

      int index = 0;
      foreach (int randomNumber in new RandomNumberEnumerator(rowCount * columnCount))
      {
        boardLayout[index / columnCount, index % columnCount] = classicGameDice[randomNumber];
        index++;
      }

      InnerCharacters = new char[rowCount, columnCount];

      for (int row = 0; row < rowCount; row++)
      {
        for (int col = 0; col < columnCount; col++)
        {
          InnerCharacters[row, col] = 'a';
        }
      }
    }

    public int RowCount { get; private set; }

    public int ColumnCount { get; private set; }

    private char[,] InnerCharacters { get; set; }

    public char GetCharacter(int row, int col)
    {
      return InnerCharacters[row, col];
    }
  }
}
