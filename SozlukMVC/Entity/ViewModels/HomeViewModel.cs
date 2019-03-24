using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ViewModels
{
    public class HomeViewModel
    {
        public int FromLang { get; set; }
        public int ToLang { get; set; }
        public string FromWord { get; set; }
        public List<string>Translations { get; set; }

        public string ToWord
        {
            get
            {
                return string.Join(Environment.NewLine, Translations);
            } 
        }
    }
}
