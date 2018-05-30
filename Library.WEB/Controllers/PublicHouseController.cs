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
    public class PublicHouseController : Controller
    {
        PublicationHouseService _publicatonhouseService;

        public PublicHouseController()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LibraryDB.mdf;Integrated Security=True;" +
                "Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            _publicatonhouseService = new PublicationHouseService(connectionString);
        }

        [HttpGet("PublicHouses")]
        public IEnumerable<PublicHouseViewModel> PublicHouses()
        {
            var publicHouses = _publicatonhouseService.Get();
            return publicHouses;
        }


        [HttpPost("[action]")]
        [Route("CreatePublicHouse")]
        public IActionResult CreatePublicHouse([FromBody]PublicHouseViewModel publicHouse)
        {
            if (ModelState.IsValid)
            {
                _publicatonhouseService.Create(publicHouse);

                return Ok(publicHouse);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        [Route("UpdatePublicHouse/{id}")]
        public IActionResult UpdatePublicHouse(int id, [FromBody]PublicHouseViewModel publicHouse)
        {
            if (ModelState.IsValid)
            {
                _publicatonhouseService.Update(publicHouse);
                return Ok(publicHouse);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        [Route("DeletePublicHouse/{id}")]
        public IActionResult DeletePublicHouse(int id)
        {
            PublicHouseViewModel publicHouse = _publicatonhouseService.Get(id);
            if (publicHouse != null)
            {
                _publicatonhouseService.Remove(id);
            }
            return Ok(publicHouse);
        }
    }
}