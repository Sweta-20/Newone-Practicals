using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        //public int DepartmentId { get; set; }
        public string EmailId { get; set; }
        
        public DateTime JoiningDate { get; set; }
        public bool Status { get; set; }

        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
    }
}
