using ELS.Core.Entities;
using MediatR;

namespace ELS.UseCase.Queries.StudySets.GetStudySetById
{
    public record GetStudySetByIdQuery(long Id) : IRequest<StudySet?>;
}
