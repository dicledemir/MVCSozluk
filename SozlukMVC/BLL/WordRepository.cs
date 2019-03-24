using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class WordRepository : BaseRepository<Word, int>
    {
        SozlukContext _db;

        public WordRepository(SozlukContext db)
            : base(db)
        {
            _db = db;
        }

        public override bool Delete(int id)
        {
            Word w = GetOne(id);
            if (w.Translations != null)
            {
                w.Translations.Clear();
                _db.Entry(w).State = EntityState.Modified;
                _db.SaveChanges();
            }
            return base.Delete(id);
        }
    }
}
