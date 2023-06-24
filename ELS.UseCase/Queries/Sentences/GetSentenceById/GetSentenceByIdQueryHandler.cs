using ELS.Core.Entities;
using ELS.UseCase.PluginInterfaces.Repositories;
using MediatR;

namespace ELS.UseCase.Queries.Sentences.GetSentenceById
{
    public class GetSentenceByIdQueryHandler : IRequestHandler<GetSentenceByIdQuery, Sentence?>
    {
        private readonly ISentenceRepository sentenceRepository;

        public GetSentenceByIdQueryHandler(ISentenceRepository sentenceRepository)
        {
            this.sentenceRepository = sentenceRepository;
        }
        public async Task<Sentence?> Handle(GetSentenceByIdQuery request, CancellationToken cancellationToken)
        {
            var vocb = await sentenceRepository.GetAsync(x => x.Id == request.SentenceId && x.Status == true);

            return vocb;
        }
    }
}