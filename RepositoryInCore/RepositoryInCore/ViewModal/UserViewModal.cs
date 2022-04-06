using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryInCore.ViewModal
{
    public class UserViewModal
    {
        public string FirstName { get; set; }
        public string LName { get; set; }//hear we change the property name from LastName to LName
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
