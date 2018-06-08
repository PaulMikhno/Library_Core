using AutoMapper;
using Library.Entities.Models;
using Library.ViewEntities.Models.BookView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ViewEntities.Models;

namespace Library.BLL.MapperProfiles
{
   public class BookProfile:Profile 
    {
        public BookProfile()
        {
            CreateMap<Book, BookView>();
            CreateMap<BookView, Book>();
            CreateMap<Book, BookViewToUpdate>();
            CreateMap<BookViewToUpdate, Book>();
        }

    }
}
