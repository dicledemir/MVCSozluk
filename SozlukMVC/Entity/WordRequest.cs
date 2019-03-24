using Entity.Abstract;

namespace Entity
{
    public class WordRequest : IEntity
    {
        public int Id { get; set; }
        public string Word { get; set; }
        public int LanguageId { get; set; }
        public virtual Person Person { get; set; }
        public virtual Language Language { get; set; }
    }
}
