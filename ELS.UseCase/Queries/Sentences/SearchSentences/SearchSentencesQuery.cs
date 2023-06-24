using ELS.Core.Entities;
using ELS.UseCase.PluginInterfaces.Common;

namespace ELS.UseCase.Queries.Sentences.SearchSentences
{
    public record SearchSentencesQuery(string Term = "", string Definition = "") : IQuery<List<Sentence>>;
}