using ELS.Core.Entities;
using ELS.UseCase.PluginInterfaces.Common;
using MediatR;

namespace ELS.UseCase.Queries.StudySets.SearchStudySets
{
    public record SearchStudySetsQuery(string Title = "") : IQuery<List<StudySet>>;
}
