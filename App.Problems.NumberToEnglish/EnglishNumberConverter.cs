﻿using System;
using System.Text;

namespace App.Problems.NumberToEnglish
{
  public class EnglishNumberConverter
  {
    private static int GetHundredsValue(int val) => val / 100;

    private static int GetTensValue(int val) => (val % 100) / 10;

    private static int GetOnesValue(int val) => val % 10;

    private static string GetDigitText(int val)
    {
      switch (val)
      {
        case 0: return String.Empty;
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

    private static string GetTweenerText(int val)
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

    private static string GetTensText(int val)
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

    private static string GetThousandsSuffix(int thousandsCounter)
    {
      switch (thousandsCounter)
      {
        case 0: return "";
        case 1: return " Thousand";
        case 2: return " Million";
        case 3: return " Billion";
        default: throw new ArgumentOutOfRangeException();
      }
    }

    private static void AppendThousandsValueText(int val, StringBuilder output)
    {
      // Handle numbers from 0 to 999

      if (val < 0 || val >= 1000)
        throw new ArgumentOutOfRangeException();

      if (val >= 0 && val < 10)
      {
        // Handle 0 - 9
        output.Append(GetDigitText(val));
      }
      else if (val >= 10 && val < 20)
      {
        // Handle 10 - 19
        output.Append(GetTweenerText(val));
      }
      else if (val >= 20 && val < 100)
      {
        // Handle 20 - 99
        int tensVal = GetTensValue(val);
        int onesVal = GetOnesValue(val);

        output.Append(GetTensText(tensVal));

        if (onesVal > 0)
        {
          output.Append(" ");
          output.Append(GetDigitText(onesVal));
        }
      }
      else if (val >= 100 && val < 1000)
      {
        // Handle 100 - 999
        int hundredsVal = GetHundredsValue(val);
        int remainderVal = val % 100;

        output.Append(GetDigitText(hundredsVal));
        output.Append(" Hundred");

        if (remainderVal > 0)
        {
          output.Append(" ");
          AppendThousandsValueText(remainderVal, output);
        }
      }
    }

    private static void AppendValueText(int origVal, int currVal, int thousandsCounter, StringBuilder output)
    {
      if (origVal == 0)
      {
        // Handle special case: Zero
        output.Append("Zero");
        return;
      }

      if (origVal < 0)
      {
        output.Append("Negative ");
        AppendValueText(-origVal, -currVal, thousandsCounter, output);
        return;
      }

      int currThousandsVal = currVal % 1000;
      int nextVal = currVal / 1000;

      if (nextVal > 0)
        AppendValueText(origVal, nextVal, thousandsCounter + 1, output);

      if (currThousandsVal > 0)
      {
        if (nextVal > 0)
          output.Append(" ");

        AppendThousandsValueText(currThousandsVal, output);
        output.Append(GetThousandsSuffix(thousandsCounter));
      }
    }

    public static string Convert(int val)
    {
      var output = new StringBuilder();
      AppendValueText(val, val, 0, output);

      return output.ToString();
    }
  }
}
