
namespace App.Problems.BinaryTreeIterator
{
  public class BinaryTreeNode<TData>
  {
    public BinaryTreeNode<TData> ParentNode { get; set; }

    public BinaryTreeNode<TData> LeftNode { get; set; }

    public BinaryTreeNode<TData> RightNode { get; set; }

    public TData Data { get; set; }
  }
}
