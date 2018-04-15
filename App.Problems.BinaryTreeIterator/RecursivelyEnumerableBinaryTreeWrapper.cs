using System;
using System.Collections;
using System.Collections.Generic;

namespace App.Problems.BinaryTreeIterator
{
  public class RecursivelyEnumerableBinaryTreeWrapper<TData> : IEnumerable<TData>
  {
    // This class demonstrates how to use "yield return" recursively

    public RecursivelyEnumerableBinaryTreeWrapper(BinaryTree<TData> tree)
    {
      Tree = tree;
    }

    public BinaryTree<TData> Tree { get; set; }

    private IEnumerable<TData> EnumerateNodes(BinaryTreeNode<TData> node)
    {
      if (node != null)
      {
        if (node.LeftNode != null)
        {
          foreach (TData val in EnumerateNodes(node.LeftNode))
            yield return val;
        }

        yield return node.Data;

        if (node.RightNode != null)
        {
          foreach (TData val in EnumerateNodes(node.RightNode))
            yield return val;
        }
      }
    }

    private IEnumerator<TData> InnerEnumerator()
    {
      foreach (TData val in EnumerateNodes(Tree.RootNode))
        yield return val;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return this.InnerEnumerator();
    }

    IEnumerator<TData> IEnumerable<TData>.GetEnumerator()
    {
      return this.InnerEnumerator();
    }
  }
}
