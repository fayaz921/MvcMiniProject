using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcTemplate.Dtos
{
    public class UsersDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Cnic { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}