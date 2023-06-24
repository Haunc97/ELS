using ELS.UseCase.PluginInterfaces.Common;
using ELS.UseCase.PluginInterfaces.Repositories;
using MediatR;

namespace ELS.UseCase.Commands.Sentences.DeleteSentence
{
    public class DeleteSentenceCommandHandler : ICommandHandler<DeleteSentenceCommand>
    {
        private readonly ISentenceRepository sentenceRepository;

        public DeleteSentenceCommandHandler(ISentenceRepository sentenceRepository)
        {
            this.sentenceRepository = sentenceRepository;
        }
        public async Task<Unit> Handle(DeleteSentenceCommand request, CancellationToken cancellationToken)
        {
            var vocb = await sentenceRepository.GetAsync(x => x.Id == request.sentenceId);

            if (vocb != null)
            {
                vocb.Status = false;
                vocb.UpdatedOn = DateTime.UtcNow;
                vocb.UpdatedBy = request.DeletedBy;

                await sentenceRepository.UpdateAsync(vocb);
            }
            return Unit.Value;
        }
    }
}
