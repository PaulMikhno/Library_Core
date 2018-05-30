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

        [HttpPost("[action]")]
        [Route("CreateBook")]
        public IActionResult CreateBook([FromBody]BookViewModel book)
        {
            if (ModelState.IsValid)
            {
                _bookServise.Create(book);

                return Ok(book);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        [Route("UpdateBook/{id}")]
        public IActionResult UpdateBook(int id, [FromBody]BookViewModel book)
        {
            if (ModelState.IsValid)
            {
                _bookServise.Update(book);
                return Ok(book);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        [Route("DeleteBook/{id}")]
        public IActionResult DeleteBook(int id)
        {
            BookViewModel book = _bookServise.Get(id);
            if (book != null)
            {
                _bookServise.Remove(id);
            }
            return Ok(book);
        }
    }

}
