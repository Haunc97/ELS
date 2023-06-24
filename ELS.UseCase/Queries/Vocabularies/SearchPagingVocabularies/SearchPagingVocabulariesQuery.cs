using ELS.Core.Entities;
using ELS.UseCase.PluginInterfaces.Common;
using ELS.UseCase.PluginInterfaces.Repositories;

namespace ELS.UseCase.Queries.Vocabularies.SearchPagingVocabularies
{
    public record SearchPagingVocabulariesQuery(int PageNumber, int PageSize, string Term = "", string Definition = "", WordClassType? Classification = null, VocabularyLevel? Level = null) : IQuery<ListPaging<Vocabulary>>;
}