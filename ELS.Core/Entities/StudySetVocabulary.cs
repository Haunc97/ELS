using ELS.Core.Entities.Base;

namespace ELS.Core.Entities
{
    public class StudySetVocabulary : Entity
    {
        public long VocabularyId { get; set; }
        public long StudySetId { get; set; }
        public Vocabulary Vocabulary { get; set; }
        public StudySet StudySet { get; set; }
    }
}