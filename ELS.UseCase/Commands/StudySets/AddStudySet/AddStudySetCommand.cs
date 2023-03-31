using ELS.Core.Entities;
using ELS.UseCase.PluginInterfaces.Common;

namespace ELS.UseCase.Commands.StudySets.AddStudySet
{
    public record AddStudySetCommand(string Title, string CreatedBy, List<Vocabulary> Vocabularies, string Description = "") : ICommand<long>;
}
