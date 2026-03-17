using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net.Http;

public static class SetsAndMaps
{
    /// <summary>
    /// Problem 1: FindPairs
    /// Using sets, find an O(n) solution for returning all symmetric pairs of words.
    /// Example: [am, at, ma, if, fi] → ["am & ma", "if & fi"]
    /// </summary>
    public static string[] FindPairs(string[] words)
    {
        HashSet<string> seen = new HashSet<string>();
        List<string> result = new List<string>();

        foreach (string word in words)
        {
            // skip words like "aa"
            if (word[0] == word[1]) continue;

            string reversed = new string(word.Reverse().ToArray());
            if (seen.Contains(reversed))
            {
                result.Add($"{word} & {reversed}");
            }
            else
            {
                seen.Add(word);
            }
        }

        return result.ToArray();
    }

    /// <summary>
    /// Problem 2: SummarizeDegrees
    /// Read a census file and summarize the degrees earned.
    /// The degree is in the 4th column of the file.
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            if (fields.Length >= 4)
            {
                string degree = fields[3].Trim();
                if (degrees.ContainsKey(degree))
                    degrees[degree]++;
                else
                    degrees[degree] = 1;
            }
        }
        return degrees;
    }

    /// <summary>
    /// Problem 3: IsAnagram
    /// Determine if 'word1' and 'word2' are anagrams using a dictionary.
    /// Ignore spaces and case.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        word1 = new string(word1.ToLower().Where(c => c != ' ').ToArray());
        word2 = new string(word2.ToLower().Where(c => c != ' ').ToArray());

        if (word1.Length != word2.Length) return false;

        Dictionary<char, int> counts = new Dictionary<char, int>();

        foreach (char c in word1)
        {
            if (!counts.ContainsKey(c)) counts[c] = 0;
            counts[c]++;
        }

        foreach (char c in word2)
        {
            if (!counts.ContainsKey(c)) return false;
            counts[c]--;
            if (counts[c] < 0) return false;
        }

        return counts.Values.All(v => v == 0);
    }

    /// <summary>
    /// Problem 5: EarthquakeDailySummary
    /// Read JSON earthquake data from USGS and return formatted strings.
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        var json = client.GetStringAsync(uri).Result;
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        return featureCollection.Features
            .Select(f => $"{f.Properties.Place} - Mag {f.Properties.Mag}")
            .ToArray();
    }
}