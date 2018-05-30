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
    public class MagazineController : Controller
    {
        MagazineService _magazineService;

        public MagazineController()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LibraryDB.mdf;Integrated " +
               "Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            _magazineService = new MagazineService(connectionString);
        }

        [HttpGet("[action]")]
        public IEnumerable<MagazineViewModel> Magazines()
        {
            var magazines = _magazineService.Get();
            return magazines;
        }

        [HttpPost("[action]")]
        [Route("CreateMagazine")]
        public IActionResult CreateMagazine([FromBody]MagazineViewModel magazine)
        {
            if (ModelState.IsValid)
            {
                _magazineService.Create(magazine);
               
                return Ok(magazine);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        [Route("UpdateMagazine/{id}")]
        public IActionResult UpdateMagazine(int id, [FromBody]MagazineViewModel magazine)
        {
            if (ModelState.IsValid)
            {
                _magazineService.Update(magazine);
                return Ok(magazine);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        [Route("DeleteMagazine/{id}")]
        public IActionResult DeleteMagazine(int id)
        {
            MagazineViewModel magazine = _magazineService.Get(id);
            if (magazine != null)
            {
                _magazineService.Remove(id);
            }
            return Ok(magazine);
        }
    }
}
