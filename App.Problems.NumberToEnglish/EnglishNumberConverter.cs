using System;
using System.Collections.Generic;
using System.Text;

namespace App.Problems.NumberToEnglish
{
  public class EnglishNumberConverter
  {
    public static int GetHundredsValue(int val)
    {
      return val / 100;
    }

    public static int GetTensValue(int val)
    {
      return (val % 100) / 10;
    }

    public static int GetOnesValue(int val)
    {
      return val % 10;
    }

    public static string GetDigitText(int val, bool displayZero)
    {
      switch (val)
      {
        case 0: return displayZero ? "Zero" : String.Empty;
        case 1: return "One";
        case 2: return "Two";
        case 3: return "Three";
        case 4: return "Four";
        case 5: return "Five";
        case 6: return "Six";
        case 7: return "Seven";
        case 8: return "Eight";
        case 9: return "Nine";
        default: throw new ArgumentOutOfRangeException();

      }
    }

    public static string GetTweenerText(int val)
    {
      switch (val)
      {
        case 10: return "Ten";
        case 11: return "Eleven";
        case 12: return "Twelve";
        case 13: return "Thirteen";
        case 14: return "Fourteen";
        case 15: return "Fifteen";
        case 16: return "Sixteen";
        case 17: return "Seventeen";
        case 18: return "Eighteen";
        case 19: return "Nineteen";
        default: throw new ArgumentOutOfRangeException();
      }
    }

    public static string GetTensText(int val)
    {
      switch (val)
      {
        case 1: return "Ten";
        case 2: return "Twenty";
        case 3: return "Thirty";
        case 4: return "Forty";
        case 5: return "Fifty";
        case 6: return "Sixty";
        case 7: return "Seventy";
        case 8: return "Eighty";
        case 9: return "Ninety";
        default: throw new ArgumentOutOfRangeException();
      }
    }

    public static string GetThousandsSuffix(int thousandsCounter)
    {
      switch (thousandsCounter)
      {
        case 0: return "";
        case 1: return "Thousand";
        case 2: return "Million";
        case 3: return "Billion";
        default: throw new ArgumentOutOfRangeException();
      }
    }

    public static string ConvertSmallNumber(int val, bool displayZero)
    {
      if (val >= 0 && val < 10)
        return GetDigitText(val, displayZero);

      if (val >= 10 && val < 20)
        return GetTweenerText(val);

      if (val >= 20 && val < 100)
        return GetTensText(GetTensValue(val)) + " " + GetDigitText(GetOnesValue(val), false);

      if (val >= 100 && val < 1000)
        return GetDigitText(GetHundredsValue(val), false) + " Hundred " + ConvertSmallNumber(val % 100, false);

      throw new ArgumentOutOfRangeException();
    }

    public static void Convert(int val, bool displayZero, int thousandsCounter, StringBuilder output)
    {
      int currVal = val;

      if (currVal >= 1000)
      {
        Convert(val / 1000, false, thousandsCounter + 1, output);
        output.Append(" ");
        output.Append(GetThousandsSuffix(thousandsCounter + 1));
        currVal %= 1000;

        if (currVal > 0)
          output.Append(", ");
      }

      output.Append(ConvertSmallNumber(currVal, thousandsCounter == 0 && val < 1000));
    }

    public static string Convert(int val)
    {
      var output = new StringBuilder();
      Convert(val, true, 0, output);

      return output.ToString();
    }
  }
}
