# UrlFiltering.Tests

## Overview
`UrlFiltering.Tests` contains unit tests for the `UrlFiltering.Core` project. The tests ensure that the core URL filtering logic works as expected and handles various edge cases correctly.

## Project Structure
- **TrieTests.cs**:
    - Contains tests for the `Trie` class, verifying that URLs are correctly inserted and blocked.

- **UrlFilterTests.cs**:
    - Contains tests for the `UrlFilter` class, ensuring that the filtering process correctly excludes blocked URLs.

## Running the Tests
1. Make sure that the `UrlFiltering.Core` project is built.
2. Run the tests using your preferred test runner. If using `dotnet`, you can run the tests with:

   ```bash
   dotnet test