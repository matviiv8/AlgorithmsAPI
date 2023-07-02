namespace AlgorithmsAPI.Models
{
    public class CipherResult : ApiResult
    {
        public CipherMode SelectedMode { get; set; }
        public string Key { get; set; }
        public string TextToTransform { get; set; }
        public string ResultText { get; set; }
    }
}
