namespace UrlFiltering.Core.Services;

public class UrlFilter
{
    private readonly Trie _trie = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="UrlFilter"/> class by inserting all blocked URLs into a Trie data structure.
    /// </summary>
    /// <param name="blockedUrls">A collection of URLs that should be blocked.</param>
    public UrlFilter(IEnumerable<string> blockedUrls)
    {
        foreach (var blockedUrl in blockedUrls)
        {
            _trie.Insert(blockedUrl);
        }
    }

    /// <summary>
    /// Filters a list of URLs, returning only those that are not blocked.
    /// </summary>
    /// <param name="urls">A collection of URLs to be filtered.</param>
    /// <returns>A filtered list of URLs that are not blocked.</returns>
    public IEnumerable<string> FilterUrls(IEnumerable<string> urls)
    {
        return urls.Where(url => !_trie.IsBlocked(url)).ToList();
    }
}