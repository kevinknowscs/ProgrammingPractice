using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Problems.BlockSizes
{
  class Program
  {
    static int GetBlocksNeeded(int countNeeded, int blockSize)
    {
      return (countNeeded + blockSize - 1) / blockSize;
    }

    static void Main(string[] args)
    {
      // This was a portion of a problem from HackerRank that was asked of me in a
      // recent online programming challenge.
      //
      // We need N units of something. The units are dished out in blocks of size M units
      // per block. How many blocks are needed to serve the number of units (you might
      // have some left over - that's okay).
      //
      // For example, if you need 7 units, and the block size is 3, you need 3 blocks
      // (with 2 unneeded units left over).
      //
      // The formula is simple enough, but maybe not super obvious ... (N + M - 1) / M
      //
      // Why? At first we might think it is simply N / M, but that won't correctly account
      // for the remainder. For example, if N = 7 and M = 3, we need 3 blocks, but N / M
      // (integer division of course) only gives us 2. Next try we think, okay, we might
      // need a whole extra block of units, so maybe (N + M) / M is the right answer. But that formula,
      // with N = 6 and M = 3, we only need 2 blocks, but (6 + 3) / 3 gives us 3, the wrong
      // answer.
      //
      // So we need one less than a whole block of M units to get the right answer. With
      // N = 6 and M = 3, we get (6 + 3 - 1) / 3 = 8 / 3 = 2, which is the correct answer.
      //
      // Let's try it out ...
      //
      // Should get the following results:
      //
      //                  BLOCK SIZE
      //      |   1    2    3    4    5    6    7    8    9    10
      // ---------------------------------------------------------
      // N  0 |   0    0    0    0    0    0    0    0    0     0   
      // E  1 |   1    1    1    1    1    1    1    1    1     1
      // E  2 |   2    1    1    1    1    1    1    1    1     1
      // D  3 |   3    2    1    1    1    1    1    1    1     1
      // E  4 |   4    2    2    1    1    1    1    1    1     1
      // D  5 |   5    3    2    2    1    1    1    1    1     1
      //    6 |   6    3    2    2    2    1    1    1    1     1
      //    7 |   7    4    3    2    2    2    1    1    1     1
      //    8 |   8    4    3    2    2    2    2    1    1     1
      //    9 |   9    5    3    3    2    2    2    2    1     1
      //   10 |  10    5    4    3    2    2    2    2    2     1

      for (int need=0; need < 20; need++)
      {
        Console.Write("{0}   ", need);

        for (int blockSize = 1; blockSize < 20; blockSize++)
          Console.Write("{0}   ", GetBlocksNeeded(need, blockSize));

        Console.WriteLine();
      }    
    }
  }
}
