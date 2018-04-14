using System;

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
    }
  }
}
