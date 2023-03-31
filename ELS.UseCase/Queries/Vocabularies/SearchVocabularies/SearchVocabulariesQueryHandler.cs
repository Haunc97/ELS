using ELS.Core.Entities;
using ELS.UseCase.PluginInterfaces.Common;
using ELS.UseCase.PluginInterfaces.Repositories;

namespace ELS.UseCase.Queries.Vocabularies.SearchVocabularies
{
    public class SearchVocabulariesQueryHandler : IQueryHandler<SearchVocabulariesQuery, List<Vocabulary>>
    {
        private readonly IVocabularyRepository vocabularyRepository;

        public SearchVocabulariesQueryHandler(IVocabularyRepository vocabularyRepository)
        {
            this.vocabularyRepository = vocabularyRepository;
        }

        public async Task<List<Vocabulary>> Handle(SearchVocabulariesQuery request, CancellationToken cancellationToken)
        {
            return await vocabularyRepository.GetListAsync(x => x.Status &&
                                            (string.IsNullOrWhiteSpace(request.Term) || x.Term.ToLower().IndexOf(request.Term.ToLower()) >= 0) &&
                                            (string.IsNullOrWhiteSpace(request.Definition) || x.Definition.ToLower().IndexOf(request.Definition.ToLower()) >= 0) &&
                                            (!request.Level.HasValue || x.Level == request.Level) &&
                                            (!request.Classification.HasValue || x.Classification == request.Classification),
                                            orderBy: y => y.OrderBy(x => x.Term));
        }
    }
}