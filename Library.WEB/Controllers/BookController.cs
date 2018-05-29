using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.BLL.Servises;
using Microsoft.AspNetCore.Mvc;
using ViewEntities.Models;

namespace Library.WEB.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        BookServise _bookServise;
        public BookController()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LibraryDB.mdf;Integrated Security=True;" +
                "Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            _bookServise = new BookServise(connectionString);
        }

        [HttpGet("[action]")]
        public IEnumerable<BookViewModel> Books()
        {
            var books = _bookServise.Get();
            return books;
        }
    }
}