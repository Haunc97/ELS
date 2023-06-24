using ELS.Core.Entities;
using ELS.UseCase.PluginInterfaces.Common;
using ELS.UseCase.PluginInterfaces.Repositories;

namespace ELS.UseCase.Queries.Sentences.SearchPagingSentences
{
    public record SearchPagingSentencesQuery(int PageNumber, int PageSize, string Term = "", string Definition = "") : IQuery<ListPaging<Sentence>>;
}