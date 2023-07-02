namespace AlgorithmsAPI.Contracts.Algorithms
{
    public interface IStringsService
    {
        Task<bool> IsStringPalindrom(string text);
        Task<List<string>> GetEveryUniquePermutation(string text);
        Task<List<int>> FindSubstring(string text, string substring);
        Task<string> ReverseString(string text);
        Task<string> ReplaceSubstring(string text, string substring, string replacement);
    }
}
