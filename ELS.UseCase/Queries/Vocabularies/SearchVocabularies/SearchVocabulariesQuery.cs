using ELS.Core.Entities;
using ELS.UseCase.PluginInterfaces.Common;

namespace ELS.UseCase.Queries.Vocabularies.SearchVocabularies
{
    public record SearchVocabulariesQuery : IQuery<List<Vocabulary>>
    {
        public SearchVocabulariesQuery(string term, string definition, WordClassType? classification, VocabularyLevel? level)
        {
            Term = term;
            Definition = definition;
            Classification = classification;
            Level = level;
        }

        public SearchVocabulariesQuery()
        {

        }

        public string Term { get; init; } = string.Empty;
        public WordClassType? Classification { get; init; }
        public string Definition { get; init; } = string.Empty;
        public VocabularyLevel? Level { get; init; }
    }
}