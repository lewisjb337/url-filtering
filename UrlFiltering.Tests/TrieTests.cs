using UrlFiltering.Core.Services;
using Xunit;
using Assert = Xunit.Assert;

namespace UrlFiltering.Tests;

[Trait("Console App", "Trie Tests")]
public class TrieTests
{
    [Fact]
    public void InsertAndCheck_IsBlocked_ShouldReturnTrueForBlockedUrl()
    {
        var trie = new Trie();
        trie.Insert("example.com");

        Assert.True(trie.IsBlocked("example.com"));
        Assert.True(trie.IsBlocked("example.com/page"));
        Assert.False(trie.IsBlocked("test.com"));
    }
}