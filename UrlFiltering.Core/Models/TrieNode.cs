namespace UrlFiltering.Core.Models;

public class TrieNode
{
    public Dictionary<string, TrieNode> Children { get; } = new();
    public bool IsEndOfBlockedUrl { get; set; }
}