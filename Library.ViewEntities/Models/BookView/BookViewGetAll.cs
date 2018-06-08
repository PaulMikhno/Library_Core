using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;


namespace Library.ViewEntities.Models.BookView
{
   public class BookViewGetAll
    {
        public List<BookView> bookList;

        public BookViewGetAll()
        {
            bookList = new List<BookView>();
        }
    }
}
