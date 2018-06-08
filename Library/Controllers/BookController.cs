using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.BLL.Servises;
using Microsoft.AspNetCore.Mvc;
using Library.ViewEntities.Models.BookView;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryAngular.Controllers
{
  [Route("api/book")]
  public class BookController : Controller
  {
    private BookService _service;

    public BookController(BookService service)
    {
      string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LibraryDB.mdf;Integrated Security=True;" +
           "Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

      _service = new BookService(connectionString);

    }

    [HttpGet]
    public IActionResult Get()
    {
      var magazines = _service.Get();
      return Ok(magazines.ToList());
    }

    [HttpPost]
    public IActionResult Post([FromBody]BookView book)
    {
      if (ModelState.IsValid)
      {
        _service.Create(book);
        return Ok(book);
      }
      return BadRequest(ModelState);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody]BookViewToUpdate book)
    {
      if (ModelState.IsValid)
      {

        _service.Update(book);
        return Ok(book);
      }
      return BadRequest(ModelState);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      if (id != 0)
      {
        _service.Remove(id);
      }
      return Ok(id);
    }

  }
}
