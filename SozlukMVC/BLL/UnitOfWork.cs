using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UnitOfWork
    {
        public SozlukContext db;

        public UnitOfWork()
        { //double lock pattern
            //thread safe olarak db'nin tek bir kez üretilmesini sağlamak
            object oylesine = "";
            if(db == null)
            {
                lock (oylesine)
                {
                    if (db == null)
                        db = new SozlukContext();
                }
            }

            Languages = new BaseRepository<Language, int>(db);
            Words = new WordRepository(db);
            WordRequests = new BaseRepository<WordRequest, int>(db);
            TranslateManager = new TranslateManager(db);
        }

        public static SozlukContext Create()
        {
            return new SozlukContext();
        }

        public bool Complete()
        {
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public BaseRepository<Language, int> Languages;
        public WordRepository Words;
        public BaseRepository<WordRequest, int> WordRequests;
        public TranslateManager TranslateManager;
    }
}
