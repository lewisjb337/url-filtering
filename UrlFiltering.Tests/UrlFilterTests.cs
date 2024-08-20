using UrlFiltering.Core.Services;
using Xunit;
using Assert = Xunit.Assert;

namespace UrlFiltering.Tests;

[Trait("Console App", "Url Filter Tests")]
public class UrlFilterTests
{
    [Fact]
    public void FilterUrls_ShouldExcludeBlockedUrls()
    {
        var blockedUrls = new List<string> { "example.com", "blocked.com" };
        var urlsToCheck = new List<string> { "example.com", "allowed.com", "blocked.com/subpage" };

        var urlFilter = new UrlFilter(blockedUrls);
        var result = urlFilter.FilterUrls(urlsToCheck);

        var collection = result.ToList();
        
        Assert.Contains("allowed.com", collection);
        Assert.DoesNotContain("example.com", collection);
        Assert.DoesNotContain("blocked.com/subpage", collection);
    }
}