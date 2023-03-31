using ELS.Core.Entities;
using ELS.UseCase.PluginInterfaces.Common;

namespace ELS.UseCase.Queries.Vocabularies.GetVocabulariesByStudySet
{
    public record GetVocabulariesByStudySetQuery(long StudySetId) : IQuery<List<Vocabulary>>;
}
