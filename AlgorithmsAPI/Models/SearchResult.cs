namespace AlgorithmsAPI.Models
{
    public class SearchResult : ApiResult
    {
        public int SearchedVariable { get; set; }
        public string LastMatchingResult { get; set; }
        public string SearchArray { get; set; }
    }
}
