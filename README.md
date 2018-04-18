# Programming Practice

This project was created to help practice for technical interviews. The sample code is written in C#.

The project generally follows "Introduction to Algorithms", Third Edition (Cormen, Leiserson, Rivest, & Stein), and throws in a few
other programming challenges that have been thrown at me during technical interviews.

## Workflow for Mastering a Technical Interview
* Think out loud so the interviewer can learn your thought process
* Resist the temptation to jump directly into coding
* Ask clarifying questions
  * Input ranges
  * Input sizes
  * Type of values in input (integer, floating point, etc.)
  * Expected size
  * Can the input contain zeroes?
  * Can the input contain duplicates?
  * Etc.
* Layout some sample data
  * Verify how the solution should behave on some sample data
  * Showcase an obvious corer cases with a separate set of sample data
* First approaches (which are almost always not the best solution)
  * Think of the most naive, brute force method of solving the problem
  * It will usually involving comparing every possible permutation of the input data to find a solution
  * This will typically be very inefficient - usually O(n^2) or worse
  * It's good to get the naive solution on the table, but be sure the interviewer recognizes that you realize its an inefficient solution
* Finding a more efficient solution
  * Think of progression in efficiency: O(2^n) -> O(n^2) -> O(n log[n]) -> O(n) -> O(log [n]) -> O(1)
  * Try to identify, intuitively, what is most likely the fastest possible solution
    * Example: I can see I'm going to need to examine every input, so I know the fastest solution is at least O(n)
  * How can it be faster? In other words, how can you avoid examining every possible permutation of input data?
    * Can you sort or reorganize the input data to make searching faster?
    * This could at least get you to O(n log[n]) fairly easily, but that still might not be the best solution
    * Can you use information about the input data to avoid looking at all permutations
    * Can you use a creative search direction (left-to-right only, right-to-left only, move in from each edge, spiral out from the middle, etc)
    * Can you use lookup tables somehow?
    * Can you pre-compute the answer, then subtract off input values to reach the final solution?


    


