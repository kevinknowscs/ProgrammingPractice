using System.Collections.Generic;

namespace App.Problems.BoggleWords
{
  class BoggleWordFinder
  { 
    public BoggleWordFinder(BoggleBoard boggleBoard, WordDictionary wordDictionary)
    {
      BoggleBoard = boggleBoard;
      WordDictionary = wordDictionary;
      MinimumWordLength = 3;
    }

    public BoggleBoard BoggleBoard { get; private set; }

    public WordDictionary WordDictionary { get; private set; }

    public int MinimumWordLength { get; set; }

    private int GetIndex(int row, int col)
    {
      return row * BoggleBoard.ColumnCount + col;
    }

    private int GetRow(int index)
    {
      return index / BoggleBoard.ColumnCount;
    }

    private int GetColumn(int index)
    {
      return index % BoggleBoard.ColumnCount;
    }

    private bool IsLegalCell(int row, int col)
    {
      return (
        row >= 0 &&
        row < BoggleBoard.RowCount &&
        col >= 0 &&
        col < BoggleBoard.ColumnCount
      );
    }

    private IEnumerable<int> GetNeighbors(int row, int col)
    {
      if (IsLegalCell(row - 1, col - 1)) yield return GetIndex(row - 1, col - 1);
      if (IsLegalCell(row - 1, col))     yield return GetIndex(row - 1, col);
      if (IsLegalCell(row - 1, col + 1)) yield return GetIndex(row - 1, col + 1);
      if (IsLegalCell(row, col - 1))     yield return GetIndex(row, col - 1);
      if (IsLegalCell(row, col + 1))     yield return GetIndex(row, col + 1);
      if (IsLegalCell(row + 1, col - 1)) yield return GetIndex(row + 1, col - 1);
      if (IsLegalCell(row + 1, col))     yield return GetIndex(row + 1, col);
      if (IsLegalCell(row + 1, col + 1)) yield return GetIndex(row + 1, col + 1);
    }

    private void AddPathToList(List<List<WordPathNode>> list, List<WordPathNode> path)
    {
      var newPath = new List<WordPathNode>();

      foreach (var node in path)
      {
        var newNode = new WordPathNode(node.Row, node.Column, node.Character);
        newPath.Add(newNode);
      }

      list.Add(newPath);
    }

    public List<List<WordPathNode>> FindWords(int currRow, int currCol, 
      List<List<WordPathNode>> results, DigitalTreeNode currNode, List<WordPathNode> currPath, HashSet<int> visitorTracker, HashSet<DigitalTreeNode> foundWords)
    {
      if (currNode.IsCompleteWord && !foundWords.Contains(currNode))
      {
        if (currPath.Count >= MinimumWordLength)
          AddPathToList(results, currPath);

        // Keep track of found words so we don't add duplicates
        foundWords.Add(currNode);
      }

      foreach (int nextIndex in GetNeighbors(currRow, currCol))
      {
        if (visitorTracker.Contains(nextIndex))
          continue; // We've already visited this node

        int nextRow = GetRow(nextIndex);
        int nextCol = GetColumn(nextIndex);
        char nextChar = BoggleBoard.GetCharacter(nextRow, nextCol);
        DigitalTreeNode nextNode = null;

        if (!currNode.NextNodes.ContainsKey(nextChar))
          continue;

        nextNode = currNode.NextNodes[nextChar];
        // TODO: Account for the "U" that follows "Q" on the "QU" dices

        currPath.Add(new WordPathNode(nextRow, nextCol, nextChar));
        visitorTracker.Add(nextIndex);

        // Recurse into neighbors with viable prefixes
        FindWords(GetRow(nextIndex), GetColumn(nextIndex), results, nextNode, currPath, visitorTracker, foundWords);

        visitorTracker.Remove(nextIndex);
        currPath.RemoveAt(currPath.Count - 1);
      }

      return results;
    }

    public List<List<WordPathNode>> FindWords()
    {
      var results = new List<List<WordPathNode>>();
      var visitorTracker = new HashSet<int>();
      var foundWords = new HashSet<DigitalTreeNode>();

      for (int row=0; row < BoggleBoard.RowCount; row++)
      {
        for (int col=0; col < BoggleBoard.ColumnCount; col++)
        {
          var currChar = BoggleBoard.GetCharacter(row, col);
          if (!WordDictionary.RootTreeNode.NextNodes.ContainsKey(currChar))
            continue;

          var startPath = new List<WordPathNode>();
          startPath.Add(new WordPathNode(row, col, currChar));
          visitorTracker.Add(GetIndex(row, col));

          // Find all the words that start with this letter
          FindWords(row, col, results, WordDictionary.RootTreeNode.NextNodes[currChar], startPath, visitorTracker, foundWords);

          visitorTracker.Remove(GetIndex(row, col));
        }
      }

      return results;
    }
  }
}
