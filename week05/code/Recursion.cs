using System.Collections;
using System.Linq;

public static class Recursion
{
    /// <summary>
    /// Problem 1: Recursive Squares Sum
    /// Computes the sum of squares from 1^2 to n^2 using recursion.
    /// Time Complexity: O(n)
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0;
        return n * n + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// Problem 2: Permutations Choose
    /// Generates all permutations of length 'size' from a list of letters.
    /// Uses recursion to find permutations without repetition.
    /// Time Complexity: O(n!)
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (size == 0)
        {
            results.Add(word);
            return;
        }
        for (int i = 0; i < letters.Length; i++)
        {
            PermutationsChoose(results, letters.Substring(0, i) + letters.Substring(i + 1), size - 1, word + letters[i]);
        }
    }

    /// <summary>
    /// Problem 3: Climbing Stairs
    /// Uses recursion with memoization to count the number of ways to climb a staircase.
    /// Time Complexity: O(n)
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null)
            remember = new Dictionary<int, decimal>();
        
        if (s == 0)
            return 1;
        if (s < 0)
            return 0;
        
        if (remember.ContainsKey(s))
            return remember[s];
        
        decimal ways = CountWaysToClimb(s - 1, remember) + CountWaysToClimb(s - 2, remember) + CountWaysToClimb(s - 3, remember);
        remember[s] = ways;
        return ways;
    }

    /// <summary>
    /// Problem 4: Wildcard Binary Patterns
    /// Generates all possible binary strings by replacing '*' in the given pattern.
    /// Time Complexity: O(2^k) where k is the number of '*'
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int index = pattern.IndexOf('*');
        if (index == -1)
        {
            results.Add(pattern);
            return;
        }
        WildcardBinary(pattern[..index] + "0" + pattern[(index + 1)..], results);
        WildcardBinary(pattern[..index] + "1" + pattern[(index + 1)..], results);
    }

    /// <summary>
    /// Problem 5: Maze Solver
    /// Finds all paths in a maze from (0,0) to the end using recursion.
    /// Uses backtracking to explore paths.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        if (currPath == null)
            currPath = new List<ValueTuple<int, int>>();

        currPath.Add((x, y));

        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.Select(p => p.ToString()).Aggregate("<List>{", (a, b) => a + b + ", ").TrimEnd(',', ' ') + "}");
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }
        
        var moves = new List<ValueTuple<int, int>> { (0, 1), (1, 0), (0, -1), (-1, 0) };
        foreach (var (dx, dy) in moves)
        {
            int nx = x + dx, ny = y + dy;
            if (maze.IsValidMove(currPath, nx, ny))
            {
                SolveMaze(results, maze, nx, ny, currPath);
            }
        }
        
        currPath.RemoveAt(currPath.Count - 1);
    }
}
