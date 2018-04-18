# Programming Practice

This project was created to help practice for technical interviews. The sample code is written in C#.

The project generally follows "Introduction to Algorithms", Third Edition (Cormen, Leiserson, Rivest, & Stein), and throws in a few
other programming challenges that have been thrown at me during technical interviews.

## Workflow for Mastering a Technical Interview
1. Ask clarifying questions
2. Layout sample data with corner cases
3. Discuss naive/inefficient solution
4. Find more efficient solution
5. Design & walk through the solution
6. Code the solution
7. Test the solution on the original sample data
8. Optional: Discuss advanced topics

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
  * Showcase any obvious corner cases with a separate set of sample data
* First approaches (which are almost always not the best solution)
  * Think of the most naive, brute force method of solving the problem
  * It will usually involving comparing every possible permutation of the input data to find a solution
  * This will typically be very inefficient - usually O(n^2) or worse
  * It's good to get the naive solution on the table, but be sure the interviewer recognizes that you realize its an inefficient solution
* Finding a more efficient solution
  * Think of progression in efficiency: O(2^n) -> O(n^2) -> O(n log[n]) -> O(n) -> O(log [n]) -> O(1)
  * Try to identify, intuitively, what is most likely the fastest possible solution
    * Example: I can see I'm going to need to examine every input, so I know the fastest solution is at least O(n)
    * Pro Tip: Most interview questions tend to have an obvious O(n^2) solution, and a non-obvious O(n) solution. That's *why* it's an interview question!!!
    * A viable approach is to simply assume there's an O(n) solution, then try to prove or disprove that hypothesis
  * How can it be faster? In other words, how can you avoid examining every possible permutation of input data?
    * Can you sort or reorganize the input data to make searching faster?
    * Is there something about the nature of input data as it relates to the output that can be exploited to avoid looking at all permutations
    * Can you use a creative search direction (left-to-right only, right-to-left only, move in from each edge, spiral out from the middle, dovetail down from the corner, etc)
    * Can you use lookup tables somehow?
    * Can you pre-compute the answer, then subtract off input values to reach the final solution?
  * Algorithmic Methods to consider for a faster solution
    * Divide & Conquer (generally a recursive approach)
    * Dynamic Programming (divide into sub problems, store results in a table)
    * Iterative / Bottoms Up Approach - Similar to dynamic programming, but without recursion. Only track the subproblem solutions you actually need, not all of them
    * Recursive decent (a divide & conquer approach to parsing)
    * State machines
    * Keeping intermediate lookup tables
    * Think of similar problems with known algorithms (e.g., "this looks a little bit like rod cutting, so dynamic programming might work")
    * For a very advanced technique, map the problem to another known problem, solve it, then reverse the process to get the answer
      * For example, the DeRemer and Penello LALR(1) algorithm maps the problem to a Strongly Connected Components problem for a graph
      * In mathematics, Laplace and Fourier transforms are commonly used
      * "This maps to the halting problem, so I know it's unsolvable"
      * "This maps to the traveling sales person problem, so I know it's NP-complete"
  * If you're still totally stumped, ask for a hint
* Walk through the solution
  * When you think you have an efficient solution, design the solution first, walking through the input data to show how it will work
* Code the solution
  * Think about corner cases and try to handle them naturally and elegantly without special-case if statements
* Test the solution
  * Walk through the original sample data to show that the solution works
* Advanced topics
  * Discuss time/space tradeoffs
  * Is the solution thread safe? If not, how can it be extended to be thread safe?
  * Does the solution lend itself to parallelization, and if so, how?
  * Could the solution be divided and scaled out onto a server farm?
  
## Solution Examples
* Number of bits in a byte - Use a pre-computed lookup table
* Maximum Subarray - Iterative, bottoms-up approach gives an O(n) solution
* Find a pair of values that sum to a given value
  * If the values are sorted, move in from each end to find the pair(s)
  * If not sorted, sort them -> O(n log[n])
  * For a faster, but less space efficient solution - store the number's complement in a lookup table
* Rod Cutting - Text book dynamic programming example
* Longest Common Subsequence - Dynamic programming using a first past to pre-compute a table so we know which direction to search, then a second, recursive pass to find the longest commong subsequence. It's pretty tricky and wouldn't be a very fair interview question in my view.
* Detect a cycle in a graph with single links - Tortoise/Hare - One pointer jumps one segment ahead on each hop, the second "fast" pointer jumps two segments ahead. Another unfair interiew question in my opinion. Unless the interviewee has previously studied the approach, they would be unlikely to come up with it in an impromptu interview session. It's a "gotcha" question that doesn't really prove much about the skills of the candidate.
* Fibonacci - Naive recursive algorithm is O(2^n). An iterative, bottoms-up approach is simple and O(n)
* Palindrome - Pretty easy. Can be solved either with an iterative approach (move in from each edge) or a recusive solution. Both are O(n)
* Missing integer in an array - Compute the expected sum with n * (n + 1) / 2. Then iterative over the values and subtract them. The number you have left is the missing integer. Tricky but easy once you know the answer.


    


