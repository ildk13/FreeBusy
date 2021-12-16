using System.Collections.Generic;

namespace FreeBusy.Data
{
    public class Employee
    {
        public string EmployeeId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public IList<BusyTime> BusyTimes { get; set; }
    }
}
