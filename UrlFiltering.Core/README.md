# UrlFiltering.Core

## Overview
`UrlFiltering.Core` is the core library of the URL filtering application. It contains the primary logic for managing and checking URLs against a list of blocked URLs using a Trie (prefix tree) data structure. This project is independent and does not depend on any UI or external frameworks, making it reusable and testable.

## Project Structure

- **Models/TrieNode.cs**:
    - Represents a node in the Trie structure, storing children nodes and a flag to indicate if the node marks the end of a blocked URL.

- **Services/Trie.cs**:
    - Implements the Trie data structure, allowing efficient insertion of blocked URLs and checking if a given URL or its sub-paths/subdomains are blocked.

- **Services/UrlFilter.cs**:
    - Provides the `UrlFilter` class that utilizes the `Trie` to filter a list of URLs, excluding those that are blocked.

## How to Use
1. Add the `UrlFiltering.Core` project as a reference to any project where you need to filter URLs.
2. Use the `UrlFilter` class to initialize with a list of blocked URLs and call `FilterUrls` to filter any list of URLs.

## Example Usage

```csharp
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

foreach (var url in filteredUrls)
{
    Console.WriteLine(url);
}
