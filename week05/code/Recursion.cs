using System.Collections;
using System.Diagnostics;

public static class Recursion
{
    // Problem 1
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0) return 0;
        return n * n + SumSquaresRecursive(n - 1);
    }

    // Problem 2
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        foreach (char c in letters)
        {
            string remaining = letters.Replace(c.ToString(), "");
            PermutationsChoose(results, remaining, size, word + c);
        }
    }

    // Problem 3
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null) remember = new Dictionary<int, decimal>();

        if (s < 0) return 0;
        if (s == 0) return 1;

        if (remember.ContainsKey(s)) return remember[s];

        decimal ways = CountWaysToClimb(s - 1, remember) +
                       CountWaysToClimb(s - 2, remember) +
                       CountWaysToClimb(s - 3, remember);

        remember[s] = ways;
        return ways;
    }

    // Problem 4
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int index = pattern.IndexOf('*');
        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        WildcardBinary(pattern.Substring(0, index) + "0" + pattern.Substring(index + 1), results);
        WildcardBinary(pattern.Substring(0, index) + "1" + pattern.Substring(index + 1), results);
    }

    // Problem 5
    public static void SolveMaze(
        List<string> results,
        Maze maze,
        int x = 0,
        int y = 0,
        List<(int, int)>? currPath = null)
    {
        if (currPath == null)
            currPath = new List<(int, int)>();

        // Bounds check
        if (x < 0 || y < 0 || x >= maze.Width || y >= maze.Height)
            return;

        // Blocked cell check (0 = wall, non-zero = open)
        int startIndex = y * maze.Width + x;
        if (maze.Data[startIndex] == 0)
            return;

        currPath.Add((x, y));

        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }

        int[,] directions = { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };

        for (int i = 0; i < directions.GetLength(0); i++)
        {
            int newX = x + directions[i, 0];
            int newY = y + directions[i, 1];

            bool inBounds = newX >= 0 && newY >= 0 && newX < maze.Width && newY < maze.Height;
            if (inBounds)
            {
                int index = newY * maze.Width + newX;
                bool isOpen = maze.Data[index] != 0; // non-zero = open cell
                bool notVisited = !currPath.Contains((newX, newY));

                if (isOpen && notVisited)
                {
                    SolveMaze(results, maze, newX, newY, currPath);
                }
            }
        }

        currPath.RemoveAt(currPath.Count - 1); // backtrack
    }
}