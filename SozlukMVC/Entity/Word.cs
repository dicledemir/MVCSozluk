using Entity.Abstract;
using System.Collections.Generic;

namespace Entity
{
    public class Word : IEntity
    {
        public int Id { get; set; }
        public string WordTxt { get; set; }
        public int Language_Id { get; set; }

        public virtual Language Language { get; set; }
        public virtual List<Word> Translations { get; set; }
    }
}
