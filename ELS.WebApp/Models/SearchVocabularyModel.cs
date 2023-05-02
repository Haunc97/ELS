using ELS.Core.Entities;

namespace ELS.WebApp.Models
{
    public class SearchVocabularyModel
    {
        public string Term { get; set; } = null;

        public WordClassType? Classification { get; set; } = null;

        public VocabularyLevel? Level { get; set; } = null;
    }
}
