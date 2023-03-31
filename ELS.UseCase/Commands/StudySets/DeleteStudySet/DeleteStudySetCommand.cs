using ELS.UseCase.PluginInterfaces.Common;

namespace ELS.UseCase.Commands.StudySets.DeleteStudySet
{
    public record DeleteStudySetCommand(long StudySetId, string DeletedBy) : ICommand;
}