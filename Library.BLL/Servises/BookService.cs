using System;
using System.Collections.Generic;
using System.Text;
using Library.DAL;
using Library.Entities.Models;
//using System.Data.Entity;
using Library.ViewEntities.Models.BookView;
using AutoMapper;
using Library.DAL.Repositories;

namespace Library.BLL.Servises
{
    public class BookService
    {
        //private LibraryContext _libraryContext;

        private DapperGenericRepository<Book> _bookRepository;

        //private DapperGenericRepository<PublicHouse> _publicHouseRepository;

        public BookService(string connectionString="")
        {
          //  this._libraryContext =new LibraryContext(connectionString);
            this._bookRepository = new DapperGenericRepository<Book>(connectionString);
          //  this._publicHouseRepository= new GenericRepository<PublicHouse>(_libraryContext);
            //_libraryContext.Configuration.ProxyCreationEnabled = false;

        }

       public IEnumerable<BookView> Get()
       {
            IEnumerable<Book> books = _bookRepository.Get();
            
            var bookRes = Mapper.Map<IEnumerable<Book>, List<BookView>>(books);
            return bookRes;
       }

       public BookView Get(int id)
       {
            Book book = _bookRepository.Get(id);
           
            var bookRes = Mapper.Map<Book, BookView>(book);
            return bookRes;
        }

       public void Remove(int id)
       {

            _bookRepository.Remove(id);
       }

       public void Update(BookViewToUpdate book)
       {
            var bookUpdate = Mapper.Map<BookViewToUpdate, Book>(book);

            _bookRepository.Update(bookUpdate);
       }
       public void Create(BookView book)
       {
            
            var bookUpdate = Mapper.Map<BookView, Book>(book);

            _bookRepository.Create(bookUpdate);

       }

        //public IEnumerable<PublicHouseViewModel> GetPublicHouses()
        //{
        //    IEnumerable<PublicHouse> publicHousesDB = _publicHouseRepository.Get();
          
        //    var publicHouses = Mapper.Map<IEnumerable<PublicHouse>, List<PublicHouseViewModel>>(publicHousesDB);

        //    return publicHouses;
        //}
    }

}

