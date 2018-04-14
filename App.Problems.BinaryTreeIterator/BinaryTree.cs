using System.Collections.Generic;

namespace App.Problems.BinaryTreeIterator
{
  public class BinaryTree<TData>
  {
    public BinaryTree(IComparer<TData> comparer)
    {
      Comparer = comparer;
    }

    public IComparer<TData> Comparer { get; private set; }

    public BinaryTreeNode<TData> RootNode { get; private set; }

    private BinaryTreeNode<TData> GetFirstNodeInSubtree(BinaryTreeNode<TData> baseNode)
    {
      if (baseNode == null)
        return null;

      var result = baseNode;

      while (result.LeftNode != null)
        result = result.LeftNode;

      return result;
    }

    private BinaryTreeNode<TData> GetLastNodeInSubtree(BinaryTreeNode<TData> baseNode)
    {
      if (baseNode == null)
        return null;

      var result = baseNode;

      while (result.RightNode != null)
        result = result.RightNode;

      return result;
    }

    public BinaryTreeNode<TData> Insert(TData val)
    {
      if (RootNode == null)
      {
        RootNode = new BinaryTreeNode<TData>();
        RootNode.Data = val;

        return RootNode;
      }

      var baseNode = FindClosestNode(RootNode, val);
      var newNode = new BinaryTreeNode<TData>();

      newNode.Data = val;
      newNode.ParentNode = baseNode;

      if (Comparer.Compare(baseNode.Data, val) > 0)
      {
        newNode.LeftNode = baseNode.LeftNode;
        baseNode.LeftNode = newNode;
      }
      else
      {
        newNode.RightNode = baseNode.RightNode;
        baseNode.RightNode = newNode;
      }

      return newNode;
    }

    public BinaryTreeNode<TData> FindClosestNode(BinaryTreeNode<TData> baseNode, TData val)
    {
      if (baseNode == null)
        return null;

      if (Comparer.Compare(baseNode.Data, val) > 0)
        return (baseNode.LeftNode != null) ? FindClosestNode(baseNode.LeftNode, val) : baseNode;

      return (baseNode.RightNode != null) ? FindClosestNode(baseNode.RightNode, val) : baseNode;
    }

    public BinaryTreeNode<TData> GetFirstNode()
    {
      return GetFirstNodeInSubtree(RootNode);
    }

    public BinaryTreeNode<TData> GetLastNode()
    {
      return GetLastNodeInSubtree(RootNode);
    }

    public BinaryTreeNode<TData> GetNextNode(BinaryTreeNode<TData> currentNode)
    {
      if (currentNode == null)
        return null;

      if (currentNode.RightNode != null)
        return GetFirstNodeInSubtree(currentNode.RightNode);

      var result = currentNode;

      // This is the trick to a non-recursive binary tree iterator. If the current node is on
      // the right hand side of the parent node, then we need to keep going up the chain until
      // we're on the left hand side, or we reach the root. Then, the next node is the parent.
      while (result != null && result.ParentNode != null && result.ParentNode.RightNode == result)
        result = result.ParentNode;

      return (result == null) ? result : result.ParentNode;
    }

    public BinaryTreeNode<TData> GetPrevNode(BinaryTreeNode<TData> currentNode)
    {
      if (currentNode == null)
        return null;

      if (currentNode.LeftNode != null)
        return GetLastNodeInSubtree(currentNode.LeftNode);

      var result = currentNode;

      // Same technique as used for GetNextNode(), except this time we check if we're on the left hand side
      while (result != null && result.ParentNode != null && result.ParentNode.LeftNode == result)
        result = result.ParentNode;

      return (result == null) ? result : result.ParentNode;
    }
  }
}
