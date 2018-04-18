using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Problems.PyramidHeight
{
  class Program
  {
    // A pyramid is similar to a binary tree, except that each node can have
    // two parents (except the root). In our example, the value of each node
    // represents a height. We wish to calculate the maximum height of the 
    // pyramid.
    //
    // For example ...
    //
    //              3
    //            /   \
    //           2     1
    //          / \   / \
    //         5    4    3
    //
    // The answer is 10 (3 + 2 + 5) = 10.
    //
    // The 3 other paths give us:
    // 3 + 2 + 4 = 9
    // 3 + 1 + 4 = 8
    // 3 + 1 + 3 = 7
    //
    // So the maxmimum height is 10, the correct answer.
    //
    // The pyramid is represented as a two dimensional array. The above pyramid
    // is represented as follows:
    //
    // 3  0  0
    // 2  1  0
    // 5  4  3
    //
    // Assume there are no missing nodes. Calculate the maximum height.

    static int MaxPath(int[][] pyramid, Dictionary<int, int> maxPaths, int row, int col)
    {
      // Here we use dynamic programming to keep track of previously computed heights
      // so that we don't need to recompute them over and over again.

      int totalCols = pyramid.Length; // Total row and column count are the same
      int colCount = row + 1; // The number of columns in this row

      if (maxPaths.ContainsKey(row * totalCols + col))
        return maxPaths[row * totalCols + col];

      if (row >= pyramid.Length)
      {
        maxPaths.Add(row, 0);
        return 0;
      }

      if (row == pyramid.Length - 1)
      {
        maxPaths.Add(row * totalCols + col, pyramid[row][col]);
        return pyramid[row][col];
      }

      int left = MaxPath(pyramid, maxPaths, row + 1, col);
      int right = MaxPath(pyramid, maxPaths, row + 1, col + 1);
      int result = Math.Max(left, right) + pyramid[row][col];

      maxPaths.Add(row * totalCols + col, result);

      return result;
    }

    static int MaxPath(int[][] pyramid)
    {
      return MaxPath(pyramid, new Dictionary<int, int>(), 0, 0);
    }

    static void Main(string[] args)
    {
      int[][] pyramid1 =
      {
        new int[] { 3, 0, 0 },
        new int[] { 2, 1, 0 },
        new int[] { 5, 4, 3 }
      };

      Console.WriteLine(MaxPath(pyramid1));

      int[][] pyramid2 =
      {
        new int[] { 4, 0, 0, 0 },
        new int[] { 3, 1, 0, 0 },
        new int[] { 2, 7, 3, 0 },
        new int[] { 3, 2, 1, 1 }
      };

      Console.WriteLine(MaxPath(pyramid2));
    }
  }
}
