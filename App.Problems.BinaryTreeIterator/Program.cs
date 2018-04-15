using System;
using System.Collections.Generic;

namespace App.Problems.BinaryTreeIterator
{
  class Program
  {
    static void Main(string[] args)
    {
      // This program shows how to iterate over a binary tree with a non-recursive algorithm.
      // The main idea is to show how to write GetNextNode() and GetPrevNode() without the
      // benefit of recursion. In a recursive algorithm, the runtime stack keeps some important
      // contextual information for us. With a non-recursive algorithm, we don't have the benefit
      // of the stack, so we have to do a little more work. See the implementations of 
      // BinaryTree.GetNextNode() and BinaryTree.GetPrevNode().

      var tree = new BinaryTree<string>(StringComparer.Create(System.Globalization.CultureInfo.CurrentCulture, false));

      // Note: My Insert() algorithm doesn't guarantee the tree is balanced, but that's not important
      // for the purpose of this exercise. I'm merely trying to demonstrate that GetNextNode() and
      // GetPrevNode() work as expected.
      //
      // The nodes are inserted in sorted order.

      tree.Insert("One");
      tree.Insert("Two");
      tree.Insert("Three");
      tree.Insert("Four");
      tree.Insert("Five");
      tree.Insert("Kevin");
      tree.Insert("Alias");
      tree.Insert("Heavy");
      tree.Insert("Murky");
      tree.Insert("Added");
      tree.Insert("Birch");
      tree.Insert("Viva");
      tree.Insert("Money");

      Console.WriteLine("Iterate Forwards Through Tree");
      Console.WriteLine("-----------------------------");

      var node = tree.GetFirstNode();

      while (node != null)
      {
        Console.WriteLine(node.Data);
        node = tree.GetNextNode(node);
      }

      Console.WriteLine();
      Console.WriteLine("Iterate Backwards Through Tree");
      Console.WriteLine("------------------------------");

      node = tree.GetLastNode();

      while (node != null)
      {
        Console.WriteLine(node.Data);
        node = tree.GetPrevNode(node);
      }

      Console.WriteLine();
      Console.WriteLine("Iterate Through Tree with Recursive Iterator using yield return");
      Console.WriteLine("---------------------------------------------------------------");

      var recursiveWrapper = new RecursivelyEnumerableBinaryTreeWrapper<string>(tree);

      foreach (string val in recursiveWrapper)
        Console.WriteLine(val);

      // Using the enumerator's MoveNext() method, we're essentially accomplishing the same
      // thing as the non-recursive version of GetNextNode(). In most languages, it isn't
      // possible to implement a recursive, manually-controllable enumerator because we need 
      // a way of returning the next result back to the caller. However, using C#'s
      // "yield return" technique, we can accomplish this in an elegant way.

      var enumerator = (recursiveWrapper as IEnumerable<string>).GetEnumerator();

      Console.WriteLine();
      Console.WriteLine("Calling the Enumerator methods manually (without foreach)");
      Console.WriteLine("---------------------------------------------------------");

      while (enumerator.MoveNext())
        Console.WriteLine(enumerator.Current);
    }
  }
}
