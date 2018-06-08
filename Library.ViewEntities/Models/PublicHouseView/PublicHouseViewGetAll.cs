using System;
using System.Collections.Generic;
using System.Text;

namespace Library.ViewEntities.Models.PublicHouseView
{
    public class PublicHouseViewGetAll
    {
        public List<PublicHouseView> publicHouseList;

        public PublicHouseViewGetAll()
        {
            publicHouseList = new List<PublicHouseView>();
        }
    }
}
