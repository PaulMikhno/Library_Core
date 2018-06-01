using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entities.Entities
{
    public class ApplicationUser :  IdentityUser
    {
        public ApplicationUser()
        {
        }

        public ApplicationUser(string userName) : base(userName)
        {
        }
        public override string UserName { get; set; }

        // Extended Properties
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public long? FacebookId { get; set; }
        public string PictureUrl { get; set; }
    }
}
