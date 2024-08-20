using UrlFiltering.Core.Models;

namespace UrlFiltering.Core.Services;

public class Trie
{
    private readonly TrieNode _root = new();
    private static readonly char[] Separator = ['/'];

    /// <summary>
    /// Inserts a URL into the Trie data structure.
    /// </summary>
    /// <param name="url">The URL to be inserted into the Trie.</param>
    public void Insert(string url)
    {
        var parts = url.Split(Separator, StringSplitOptions.RemoveEmptyEntries);
        var node = _root;

        foreach (var part in parts)
        {
            if (!node.Children.TryGetValue(part, out var value))
            {
                value = new TrieNode();
                node.Children[part] = value;
            }
            
            node = value;
        }

        node.IsEndOfBlockedUrl = true;
    }

    /// <summary>
    /// Checks if a given URL is blocked by verifying if it exists in the Trie.
    /// </summary>
    /// <param name="url">The URL to be checked.</param>
    /// <returns><c>true</c> if the URL is blocked; otherwise, <c>false</c>.</returns>
    public bool IsBlocked(string url)
    {
        var parts = url.Split(Separator, StringSplitOptions.RemoveEmptyEntries);
        var node = _root;

        foreach (var part in parts)
        {
            if (node.IsEndOfBlockedUrl)
            {
                return true;
            }
                
            if (!node.Children.TryGetValue(part, out var value))
            {
                return false;
            }
                
            node = value;
        }

        return node.IsEndOfBlockedUrl;
    }
}