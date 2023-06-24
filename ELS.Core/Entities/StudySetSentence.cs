using ELS.Core.Entities.Base;

namespace ELS.Core.Entities
{
    public class StudySetSentence : Entity
    {
        public long SentenceId { get; set; }
        public long StudySetId { get; set; }
        public Sentence Sentence { get; set; }
        public StudySet StudySet { get; set; }
    }
}