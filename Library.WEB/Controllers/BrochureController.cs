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
        [Route("CreateBrochure")]
        public IActionResult CreateBrochure([FromBody]BrochureViewModel brochure)
        {
            if (ModelState.IsValid)
            {
                _brochureService.Create(brochure);

                return Ok(brochure);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        [Route("UpdateBrochure/{id}")]
        public IActionResult UpdateBrochure(int id, [FromBody]BrochureViewModel brochure)
        {
            if (ModelState.IsValid)
            {
                _brochureService.Update(brochure);
                return Ok(brochure);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        [Route("DeleteBrochure/{id}")]
        public IActionResult DeleteBrochure(int id)
        {
            BrochureViewModel brochure = _brochureService.Get(id);
            if (brochure != null)
            {
                _brochureService.Remove(id);
            }
            return Ok(brochure);
        }
    }
}
