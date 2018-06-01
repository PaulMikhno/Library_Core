using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewEntities.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Library.DAL.Identity;
using Library.Entities.Entities;
using Library.BLL.DTO;
using ViewEntities.Enums;
using Library.BLL.Infrastructure;

namespace Library.WEB.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly ApplicationContext _appDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public AccountController(UserManager<ApplicationUser> userManager, IMapper mapper, ApplicationContext appDbContext)
        {
            _userManager = userManager;
            _mapper = mapper;
            _appDbContext = appDbContext;
        }

        // POST api/accounts
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdentity = _mapper.Map<ApplicationUser>(model);

            var result = await _userManager.CreateAsync(userIdentity, model.Password);

          //  if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));//Helpers

            await _appDbContext.ClientProfiles.AddAsync(new ClientProfile { IdentityId = userIdentity.Id });
            await _appDbContext.SaveChangesAsync();

            return new OkObjectResult("Account created");
        }
    }
}