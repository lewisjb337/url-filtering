using UrlFiltering.Core.Services;

namespace UrlFiltering.ConsoleApp;

class Program
{
    private static void Main(string[] args)
    {
        var blockedUrls = new List<string>
        {
            "example.com",
            "test.com/page",
            "blocked.com"
        };

        var urlsToCheck = new List<string>
        {
            "example.com",
            "example.com/page",
            "test.com/page",
            "test.com/page/subpage",
            "allowed.com",
            "blocked.com/subpage"
        };

        var urlFilter = new UrlFilter(blockedUrls);
        var filteredUrls = urlFilter.FilterUrls(urlsToCheck);

        Console.WriteLine("Filtered URLs (not blocked):");
        
        foreach (var url in filteredUrls)
        {
            Console.WriteLine(url);
        }
    }
}