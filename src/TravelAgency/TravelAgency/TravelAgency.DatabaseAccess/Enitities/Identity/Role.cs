﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace TravelAgency.DatabaseAccess.Enitities.Identity
{
    internal class Role : IdentityRole<int>
    {        
        public Role(string name)
            : base(name)
        {

        }
    }
}
