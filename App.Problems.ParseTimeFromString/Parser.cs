
namespace App.Problems.ParseTimeFromString
{
  public class Parser
  {
    private const string RetriesLabel = "Retries";
    private const string TotalTimeLabel = "TotalTime";

    private int SkipChar(string val, int pos, char ch)
    {
      while (pos < val.Length && val[pos] == ch)
        pos++;

      return pos;
    }

    private int SkipColon(string val, int pos)
    {
      return SkipChar(val, pos, ':');
    }

    private int SkipSemicolon(string val, int pos)
    {
      return SkipChar(val, pos, ';');
    }

    private int SkipSpaces(string val, int pos)
    {
      return SkipChar(val, pos, ' ');
    }

    private bool IsDigit(char ch)
    {
      return ch >= '0' && ch <= '9';
    }

    private int GetIntFromChar(char ch)
    {
      return (int)(ch - '0');
    }

    private int GetNextValue(string val, int pos, out int result)
    {
      result = 0;

      while (pos < val.Length && IsDigit(val[pos]))
        result = result * 10 + GetIntFromChar(val[pos++]);

      pos = SkipSpaces(val, pos);
      pos = SkipSemicolon(val, pos);
      pos = SkipSpaces(val, pos);

      return pos;
    }

    private int GetRetries(string val, int pos, out int result)
    {
      result = 0;

      pos += RetriesLabel.Length;
      pos = SkipColon(val, pos);
      pos = SkipSpaces(val, pos);

      return GetNextValue(val, pos, out result);
    }

    private int GetTotalTime(string val, int pos, out int result)
    {
      result = 0;

      pos += TotalTimeLabel.Length;
      pos = SkipColon(val, pos);
      pos = SkipSpaces(val, pos);

      return GetNextValue(val, pos, out result);
    }

    public int GetTotalTimeSum(string val)
    {
      int pos = 0;
      int retries = 0;
      int totalTime = 0;
      int sum = 0;

      pos = GetRetries(val, pos, out retries);

      for (int x=0; x < retries + 1; x++)
      {
        pos = GetTotalTime(val, pos, out totalTime);
        sum += totalTime;
      }

      return sum;
    }
  }
}
