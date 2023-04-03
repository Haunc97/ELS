using ELS.Core.Entities;
using ELS.UseCase.PluginInterfaces.Common;

namespace ELS.UseCase.Queries.Vocabularies.SearchVocabularies
{
    public record SearchVocabulariesQuery(string Term = "", string Definition = "", WordClassType? Classification = null, VocabularyLevel? Level = null) : IQuery<List<Vocabulary>>;
}