using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class SetsAndMaps
{
    /// <summary>
    /// Finds pairs of words that are symmetric (e.g., "cat" and "tac") using a HashSet.
    /// Complexity: O(n)
    /// </summary>
    public static string[] FindPairs(string[] words)
    {
        var wordSet = new HashSet<string>(words);
        var seen = new HashSet<string>();
        var pairs = new List<string>();

        foreach (var word in words)
        {
            var reversedWord = new string(word.Reverse().ToArray());
            if (word != reversedWord && wordSet.Contains(reversedWord) && !seen.Contains(word))
            {
                pairs.Add($"{word} & {reversedWord}");
                seen.Add(word);
                seen.Add(reversedWord);
            }
        }
        return pairs.ToArray();
    }

    /// <summary>
    /// Reads a CSV file and counts the occurrences of each unique degree in the fourth column.
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        try
        {
            foreach (var line in File.ReadLines(filename))
            {
                var fields = line.Split(",");
                if (fields.Length > 3) // Ensure there is a fourth column
                {
                    var degree = fields[3].Trim();
                    if (degrees.ContainsKey(degree))
                        degrees[degree]++;
                    else
                        degrees[degree] = 1;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading the file: {ex.Message}");
        }

        return degrees;
    }

    /// <summary>
    /// Determines if two words are anagrams of each other.
    /// Ignores spaces and is case-insensitive.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        if (word1.Length != word2.Length) return false;

        var letterCount = new Dictionary<char, int>();

        foreach (var letter in word1)
        {
            if (letterCount.ContainsKey(letter))
                letterCount[letter]++;
            else
                letterCount[letter] = 1;
        }

        foreach (var letter in word2)
        {
            if (!letterCount.ContainsKey(letter)) return false;
            letterCount[letter]--;
            if (letterCount[letter] == 0) letterCount.Remove(letter);
        }

        return letterCount.Count == 0;
    }

    /// <summary>
    /// Fetches earthquake data from the USGS API and returns a summary of each earthquake's location and magnitude.
    /// </summary>
    public static async Task<string[]> EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        try
        {
            using var client = new HttpClient();
            var response = await client.GetStringAsync(uri);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(response, options);

            // Ensure we await the result properly and handle potential nulls
            if (featureCollection?.Features == null)
                return Array.Empty<string>();

            return featureCollection.Features
                .Select(f => $"{f.Properties.Place} - Mag {f.Properties.Mag}")
                .ToArray();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching earthquake data: {ex.Message}");
            return Array.Empty<string>();
        }
    }
}

// Supporting classes for EarthquakeDailySummary
public class FeatureCollection
{
    public string Type { get; set; }
    public List<Feature> Features { get; set; }
}

public class Feature
{
    public Geometry Geometry { get; set; }
    public Properties Properties { get; set; }
}

public class Geometry
{
    public string Type { get; set; }
    public List<double> Coordinates { get; set; }
}

public class Properties
{
    public string Place { get; set; } = "Unknown";
    public double Mag { get; set; } = 0.0;
}
