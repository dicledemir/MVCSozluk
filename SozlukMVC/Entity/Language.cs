using Entity.Abstract;
using System.Collections.Generic;

namespace Entity
{
    public class Language : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Word> Words { get; set; }
        public virtual List<WordRequest> Requests { get; set; }
    }
}
