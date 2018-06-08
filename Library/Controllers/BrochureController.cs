using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.BLL.Servises;
using Microsoft.AspNetCore.Mvc;
using Library.ViewEntities.Models.BrochureView;

namespace LibraryAngular.Controllers
{
  [Route("api/brochure")]
  public class BrochureController : Controller
  {
    private BrochureService _service;

    public BrochureController(BrochureService service)
    {
      string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LibraryDB.mdf;Integrated Security=True;" +
           "Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

      _service = new BrochureService(connectionString);

    }

    [HttpGet]
    public IActionResult Get()
    {
      var brochures = _service.Get();
      return Ok(brochures.ToList());
    }

    [HttpPost]
    public IActionResult Post([FromBody]BrochureView brochure)
    {
      if (ModelState.IsValid)
      {
        _service.Create(brochure);
        return Ok(brochure);
      }
      return BadRequest(ModelState);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody]BrochureViewToUpdate brochure)
    {
      if (ModelState.IsValid)
      {

        _service.Update(brochure);
        return Ok(brochure);
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
