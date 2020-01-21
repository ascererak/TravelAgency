using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TravelAgency.DatabaseAccess.Enitities.Users
{
    internal class RegisteredUser
    {
        [ForeignKey("User")]
        public int UserId { get; set; }
    }
}
