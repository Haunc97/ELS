using ELS.Core.Entities;
using ELS.UseCase.PluginInterfaces.Common;

namespace ELS.UseCase.Commands.StudySets.EditStudySet
{
    public record EditStudySetCommand(long Id, string Title, string Description, string UpdatedBy, List<Vocabulary> Vocabularies) : ICommand<long?>;
}
