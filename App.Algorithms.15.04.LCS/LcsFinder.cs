using System.Text;

namespace App.Algorithms.LCS
{
  public class LcsFinder
  {
    private LcsLengthCell[,] BuildLcsLengthsTable(string x, string y)
    {
      var result = new LcsLengthCell[x.Length + 1, y.Length + 1];

      for (int i = 1; i <= x.Length; i++)
        result[i, 0] = new LcsLengthCell() { Direction = SearchDirection.None, Length = 0 };

      for (int j = 1; j <= y.Length; j++)
        result[0, j] = new LcsLengthCell() { Direction = SearchDirection.None, Length = 0 };

      for (int i = 1; i <= x.Length; i++)
      {
        for (int j = 1; j <= y.Length; j++)
        {
          if (x[i - 1] == y[j - 1])
            result[i, j] = new LcsLengthCell() { Direction = SearchDirection.Diagonal, Length = result[i - 1, j - 1].Length + 1 };
          else if (result[i - 1, j].Length >= result[i, j - 1].Length)
            result[i, j] = new LcsLengthCell() { Direction = SearchDirection.Up, Length = result[i - 1, j].Length };
          else
            result[i, j] = new LcsLengthCell() { Direction = SearchDirection.Left, Length = result[i, j - 1].Length };
        }
      }

      return result;
    }

    private void FindLcs(LcsSearchContext context, int lengthOfX, int lengthOfY)
    {
      if (lengthOfX == 0 || lengthOfY == 0)
        return;

      if (context.LcsLengthsTable[lengthOfX, lengthOfY].Direction == SearchDirection.Diagonal)
      {
        FindLcs(context, lengthOfX - 1, lengthOfY - 1);
        context.Output.Append(context.X[lengthOfX - 1]);
      }
      else if (context.LcsLengthsTable[lengthOfX, lengthOfY].Direction == SearchDirection.Up)
      {
        FindLcs(context, lengthOfX - 1, lengthOfY);
      }
      else
      {
        FindLcs(context, lengthOfX, lengthOfY - 1);
      }
    }

    public string FindLcs(string x, string y)
    {
      var context = new LcsSearchContext();

      context.X = x;
      context.Y = y;
      context.Output = new StringBuilder();
      context.LcsLengthsTable = BuildLcsLengthsTable(x, y);

      FindLcs(context, x.Length, y.Length);

      return context.Output.ToString();
    }
  }
}
