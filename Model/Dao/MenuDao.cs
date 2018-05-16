using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class MenuDao
    {
        OnlineClassContext db = null;

        public MenuDao()
        {
            db = new OnlineClassContext();
        }

        public List<Menu> ListByGroupId(int group)
        {
            return db.Menus.Where(x => x.TypeID == group).ToList();
        }
    }
}
