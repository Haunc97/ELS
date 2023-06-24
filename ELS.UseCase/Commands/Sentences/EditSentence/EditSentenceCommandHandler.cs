using ELS.UseCase.PluginInterfaces.Common;
using ELS.UseCase.PluginInterfaces.Repositories;

namespace ELS.UseCase.Commands.Sentences.EditSentence
{
    public class EditSentenceCommandHandler : ICommandHandler<EditSentenceCommand, long>
    {
        private readonly ISentenceRepository sentenceRepository;

        public EditSentenceCommandHandler(ISentenceRepository sentenceRepository)
        {
            this.sentenceRepository = sentenceRepository;
        }
        public async Task<long> Handle(EditSentenceCommand request, CancellationToken cancellationToken)
        {
            var vocb = await sentenceRepository.GetAsync(x => x.Id == request.SentenceId);

            if (vocb != null)
            {
                vocb.Term = request.Term.Trim();
                vocb.Definition = request.Definition.Trim();
                vocb.Phonetics = request.Phonetics?.Trim();
                vocb.UpdatedOn = DateTime.UtcNow;
                vocb.UpdatedBy = request.UpdatedBy;

                await sentenceRepository.UpdateAsync(vocb);
            }

            return request.SentenceId;
        }
    }
}
