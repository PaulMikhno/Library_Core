using System;
using System.Collections.Generic;
using System.Text;

namespace Library.ViewEntities.Models.BrochureView
{
   public class BrochureViewGetAll
    {
        public List<BrochureView> brochureList;

        public BrochureViewGetAll()
        {
            brochureList = new List<BrochureView>();
        }
    }
}
