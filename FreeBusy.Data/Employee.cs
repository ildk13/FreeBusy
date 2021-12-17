using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreeBusy.Data
{
    public class Employee
    {
        public string EmployeeId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
    }
}
