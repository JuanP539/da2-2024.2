using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        public int Id { get; set; }
        public Guid Token { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
