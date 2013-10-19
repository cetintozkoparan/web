using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Context;
using DAL.Entities;

namespace BLL.LanguageBL
{
    public class LanguageManager
    {
        public static IEnumerable<Languages> GetLanguages()
        {
            using (DeneysanContext db=new DeneysanContext())
            {
                IEnumerable<Languages> language_items = db.Languages.ToList();
                 return language_items;
            }
           
        }
    }
}
