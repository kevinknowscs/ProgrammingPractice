
##Original Question:
The original question was purposely rather vague: Write a function that records a move on a tic-tac-toe board and 
returns true if the player has won, otherwise false. The exact structure and parameters of the function are not
specified - it's up to you to design it.

##Clarifying Questions:
Upon inquiry, it was determined that the solution should work for any arbitrarily-sized Tic-Tac-Toe board.

Other potential clarify questions: Is the Tic-Tac-Toe board empty to begin with, or are we jumping into the middle
of a game. For the solutions presented here, I assume we start at the beginning of the game with an empty board.

##Method Signature
bool MakeMoveAndCheckForWin(int row, int col, int playerId);

row - a 0-based index indicating the row of the move
col - a 0-based index indicating the column of the move
playerId - 1 = X, 2 = 0, 0 is reserved to indicate an empty cell

##Design Decisions
* I represented the board as a two-dimensional array. This gives fast access for storing the entire state of the
  game, but requires O(n^2) of pre-allocated space, where n is the number of rows or columns. Another option would
  be to use a hash table or dictionary to avoid pre-allocated space, but as the moves are made and the board starts
  to fill up, it will degrade into O(n^2) space storage anyway, so I think its just as well to pre-allocate the space
  in an array.
* How do we check for a win?
  * Slow method - O(N^2) : Rescan the entire board on each move
  * Better method - O(N) : Rescan only the row, column, and diagonals (if any) of the current move
  * Fast method - O(1)   : Maintain counters for each row, column, and diagonal instead of rescanning.
* Other considerations
  * If we implement the fast method, we may not need to store the entire state of the game.
    The only reason to store the entire state of the game would be to check for invalid moves.
  * If we knew that N were no larger than a certain value (8, 16, 32, 64) we could design a more efficient
    space storage using bit masks. But since the problem stated an arbitrarily-sized board, I do not consider
    using bit masks for storage.
  * I use standard C# for loops to iterate and scan cells. If one wanted to write more elegant code, you could
    use built-in framework functionality such as LINQ.
