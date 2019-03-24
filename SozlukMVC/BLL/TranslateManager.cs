using DAL;
using Entity;
using Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TranslateManager
    {
        SozlukContext _db;
        public TranslateManager(SozlukContext db)
        {
            _db = db;
        }

        public List<string> Translate(HomeViewModel info) 
        {
            var p1 = new SqlParameter("kelime", info.FromWord);
            var p2 = new SqlParameter("hangi_dilden", info.FromLang);
            var p3 = new SqlParameter("hangi_dile", info.ToLang);

            return _db.Database.SqlQuery<string>("exec Translate @kelime , @hangi_dilden , @hangi_dile",p1,p2,p3).ToList();
        }
    }
}
