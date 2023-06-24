using ELS.Core.Entities.Base;

namespace ELS.Core.Entities
{
    public class StudySet : Entity
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public ICollection<StudySetVocabulary> StudySetVocabularies { get; set; }
        public ICollection<StudySetSentence> StudySetSentences { get; set;}
    }
}