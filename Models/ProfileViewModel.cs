using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FansOfAsparagus.Models
{
    public class ProfileViewModel
    {
        public IEnumerable<Claim> Claims { get; set; }
        public string Name { get; set; }
    }
}
