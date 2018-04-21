using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Problems.BoggleWords
{
  class BoggleDice
  {
    public BoggleDice(string firstChars, string secondChars)
    {
      FirstChars = firstChars;
      SecondChars = secondChars;
    }

    private string FirstChars { get; set; }

    private string SecondChars { get; set; }
  }
}
