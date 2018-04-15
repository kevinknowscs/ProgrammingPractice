using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Algorithms.LCS
{
  public class LcsSearchContext
  {
    public LcsLengthCell[,] LcsLengthsTable { get; set; }

    public StringBuilder Output { get; set; }

    public string X { get; set; }

    public string Y { get; set; }
  }
}
