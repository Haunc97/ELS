using ELS.Core.Entities;
using ELS.UseCase.PluginInterfaces.Common;
using ELS.UseCase.PluginInterfaces.Repositories;

namespace ELS.UseCase.Queries.Sentences.SearchPagingSentences
{
    public class SearchPagingSentencesQueryHandler : IQueryHandler<SearchPagingSentencesQuery, ListPaging<Sentence>>
    {
        private readonly ISentenceRepository sentenceRepository;

        public SearchPagingSentencesQueryHandler(ISentenceRepository sentenceRepository)
        {
            this.sentenceRepository = sentenceRepository;
        }
        public async Task<ListPaging<Sentence>> Handle(SearchPagingSentencesQuery request, CancellationToken cancellationToken)
        {
            var result = await sentenceRepository.GetListPagingAsync(request.PageNumber, request.PageSize, x => x.Status &&
                                             (string.IsNullOrWhiteSpace(request.Term) || x.Term.ToLower().IndexOf(request.Term.ToLower()) >= 0) &&
                                             (string.IsNullOrWhiteSpace(request.Definition) || x.Definition.ToLower().IndexOf(request.Definition.ToLower()) >= 0),
                                             orderBy: y => y.OrderBy(x => x.Term));
            return result;
        }
    }
}
