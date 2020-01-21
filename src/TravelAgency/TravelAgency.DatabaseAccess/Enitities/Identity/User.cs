using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace TravelAgency.DatabaseAccess.Enitities.Identity
{
    internal class User : IdentityUser<int>
    {
        [ForeignKey("IdentityRole<int>")]
        public int RoleId { get; set; }
    }
}
