using ELS.Core.Entities;
using ELS.UseCase.PluginInterfaces.Common;
using ELS.UseCase.PluginInterfaces.Repositories;

namespace ELS.UseCase.Queries.Vocabularies.SearchPagingVocabularies
{
    public class SearchPagingVocabulariesQueryHandler : IQueryHandler<SearchPagingVocabulariesQuery, ListPaging<Vocabulary>>
    {
        private readonly IVocabularyRepository vocabularyRepository;

        public SearchPagingVocabulariesQueryHandler(IVocabularyRepository vocabularyRepository)
        {
            this.vocabularyRepository = vocabularyRepository;
        }
        public async Task<ListPaging<Vocabulary>> Handle(SearchPagingVocabulariesQuery request, CancellationToken cancellationToken)
        {
            var result = await vocabularyRepository.GetListPagingAsync(request.PageNumber, request.PageSize, x => x.Status &&
                                             (string.IsNullOrWhiteSpace(request.Term) || x.Term.ToLower().IndexOf(request.Term.ToLower()) >= 0) &&
                                             (string.IsNullOrWhiteSpace(request.Definition) || x.Definition.ToLower().IndexOf(request.Definition.ToLower()) >= 0) &&
                                             (!request.Level.HasValue || x.Level == request.Level) &&
                                             (!request.Classification.HasValue || x.Classification == request.Classification),
                                             orderBy: y => y.OrderBy(x => x.Term));
            return result;
        }
    }
}