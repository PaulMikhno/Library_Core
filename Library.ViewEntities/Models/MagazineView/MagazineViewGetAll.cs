using System;
using System.Collections.Generic;
using System.Text;

namespace Library.ViewEntities.Models.MagazineView
{
   public class MagazineViewGetAll
    {
        public List<MagazineView> magazineList;

        public MagazineViewGetAll()
        {
            magazineList = new List<MagazineView>();
        }
    }
}
