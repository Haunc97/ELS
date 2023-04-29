namespace ELS.WebApp.Models
{
    public class QuestionModel
    {
        public int No { get; set; }
        public string Term { get; set; }
        public string Definition { get; set; }
        public string Answer { get; set; } = string.Empty;
        public bool IsCorrect { get; set; }
        public List<string> Options { get; set; }
        public QuestionType Type { get; set; }
    }
}