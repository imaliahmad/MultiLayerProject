using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BOL_BusinessObjectLayer_
{
    public class AppUsers: IdentityUser
    {        
        
        public string Password { get; set; }
        public string Address { get; set; }
    }
}
