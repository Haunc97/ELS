using ELS.Core.Entities;
using ELS.UseCase.PluginInterfaces.Common;
using ELS.UseCase.PluginInterfaces.Repositories;

namespace ELS.UseCase.Commands.Sentences.AddSentence
{
    public class AddSentenceCommandHandler : ICommandHandler<AddSentenceCommand, long>
    {
        private readonly ISentenceRepository sentenceRepository;

        public AddSentenceCommandHandler(ISentenceRepository sentenceRepository)
        {
            this.sentenceRepository = sentenceRepository;
        }
        public async Task<long> Handle(AddSentenceCommand request, CancellationToken cancellationToken)
        {
            Sentence sent = new()
            {
                Term = request.Term.Trim(),
                Definition = request.Definition.Trim(),
                Phonetics = request.Phonetics?.Trim(),
                Status = true,
                CreatedBy = request.CreatedBy,
                CreatedOn = DateTime.UtcNow
            };
            await sentenceRepository.AddAsync(sent);
            return sent.Id;
        }
    }
}
