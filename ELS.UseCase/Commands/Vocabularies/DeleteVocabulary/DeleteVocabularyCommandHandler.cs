using ELS.UseCase.PluginInterfaces.Common;
using ELS.UseCase.PluginInterfaces.Repositories;
using MediatR;

namespace ELS.UseCase.Commands.Vocabularies.DeleteVocabulary
{
    public class DeleteVocabularyCommandHandler : ICommandHandler<DeleteVocabularyCommand>
    {
        private readonly IVocabularyRepository vocabularyRepository;

        public DeleteVocabularyCommandHandler(IVocabularyRepository vocabularyRepository)
        {
            this.vocabularyRepository = vocabularyRepository;
        }
        public async Task<Unit> Handle(DeleteVocabularyCommand request, CancellationToken cancellationToken)
        {
            var vocb = await vocabularyRepository.GetAsync(x => x.Id == request.VocabularyId);

            if (vocb != null)
            {
                vocb.Status = false;
                vocb.UpdatedOn = DateTime.UtcNow;
                vocb.UpdatedBy = request.DeletedBy;

                await vocabularyRepository.UpdateAsync(vocb);
            }
            return Unit.Value;
        }
    }
}
