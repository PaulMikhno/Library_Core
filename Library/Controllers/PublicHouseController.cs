using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.BLL.Servises;
using Microsoft.AspNetCore.Mvc;
using Library.ViewEntities.Models.PublicHouseView;


namespace LibraryAngular.Controllers
{
  
  [Route("api/publichouse")]
  public class PublicHouseController : Controller
  {
    private PublicationHouseService _service;

    public PublicHouseController(/*PublicationHouseService service*/)
    {
      string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LibraryDB.mdf;Integrated Security=True;" +
                "Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

      _service = new PublicationHouseService(connectionString);

    }
    
    [HttpGet]
    public PublicHouseViewGetAll Get()
    {
      var publicHouses = _service.Get();
      return publicHouses;
    }

    [HttpPost]
    public IActionResult Post([FromBody]PublicHouseView publicHouse)
    {
      if (ModelState.IsValid)
      {
        _service.Create(publicHouse);

        return Ok(publicHouse);
      }
      return BadRequest(ModelState);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody]PublicHouseViewToUpdate publicHouse)
    {
      if (ModelState.IsValid)
      {
        _service.Update(publicHouse);
        return Ok(publicHouse);
      }
      return BadRequest(ModelState);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      PublicHouseView publicHouse = _service.Get(id);
      if (publicHouse != null)
      {
        _service.Remove(id);
      }
      return Ok(publicHouse);
    }
  }
}
