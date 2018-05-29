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
    public class BrochureController : Controller
    {
        BrochureService _brochureService;

        public BrochureController()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LibraryDB.mdf;Integrated Security=True;" +
                "Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            _brochureService = new BrochureService(connectionString);
        }

        [HttpGet("[action]")]
        public IEnumerable<BrochureViewModel> Brochures()
        {
            var brochures = _brochureService.Get();
            return brochures;
        }

        [HttpPost("[action]")]
        public IActionResult Create(BrochureViewModel magazine)
        {
            if (ModelState.IsValid)
            {
                _brochureService.Create(magazine);

                return Ok(magazine);
            }
            return BadRequest(ModelState);
        }

        [HttpPost("[action]")]
        public IActionResult Post([FromBody]BrochureViewModel magazine)
        {
            if (ModelState.IsValid)
            {
                _brochureService.Create(magazine);

                return Ok(magazine);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]BrochureViewModel magazine)
        {
            if (ModelState.IsValid)
            {
                _brochureService.Update(magazine);
                return Ok(magazine);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            BrochureViewModel magazine = _brochureService.Get(id);
            if (magazine != null)
            {
                _brochureService.Remove(id);
            }
            return Ok(magazine);
        }
    }
}
