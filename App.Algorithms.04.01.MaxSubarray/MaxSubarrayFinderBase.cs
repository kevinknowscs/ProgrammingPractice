using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Algorithms.MaxSubarray
{
  public abstract class MaxSubarrayFinderBase
  {
    public abstract MaxSubarrayResult FindMaxSubarray(int[] values);
  }
}
