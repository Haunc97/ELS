using ELS.Core.Entities;
using ELS.UseCase.PluginInterfaces.Common;
using ELS.UseCase.PluginInterfaces.Repositories;

namespace ELS.UseCase.Queries.Sentences.SearchSentences
{
    public class SearchSentencesQueryHandler : IQueryHandler<SearchSentencesQuery, List<Sentence>>
    {
        private readonly ISentenceRepository sentenceRepository;

        public SearchSentencesQueryHandler(ISentenceRepository sentenceRepository)
        {
            this.sentenceRepository = sentenceRepository;
        }

        public async Task<List<Sentence>> Handle(SearchSentencesQuery request, CancellationToken cancellationToken)
        {
            return await sentenceRepository.GetListAsync(x => x.Status &&
                                            (string.IsNullOrWhiteSpace(request.Term) || x.Term.ToLower().IndexOf(request.Term.ToLower()) >= 0) &&
                                            (string.IsNullOrWhiteSpace(request.Definition) || x.Definition.ToLower().IndexOf(request.Definition.ToLower()) >= 0),
                                            orderBy: y => y.OrderBy(x => x.Term));
        }
    }
}
