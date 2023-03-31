using ELS.UseCase.PluginInterfaces.Common;
using ELS.UseCase.PluginInterfaces.Repositories;
using MediatR;

namespace ELS.UseCase.Commands.StudySets.DeleteStudySet
{
    public class DeleteStudySetCommandHandler : ICommandHandler<DeleteStudySetCommand>
    {
        private readonly IStudySetRepository studySetRepository;

        public DeleteStudySetCommandHandler(IStudySetRepository studySetRepository)
        {
            this.studySetRepository = studySetRepository;
        }

        public async Task<Unit> Handle(DeleteStudySetCommand request, CancellationToken cancellationToken)
        {
            var stdSet = await studySetRepository.GetAsync(x => x.Id == request.StudySetId);
            if (stdSet != null)
            {
                stdSet.Status = false;
                stdSet.UpdatedOn = DateTime.Now;
                stdSet.UpdatedBy = request.DeletedBy;
                await studySetRepository.UpdateAsync(stdSet);
            }

            return Unit.Value;
        }
    }
}