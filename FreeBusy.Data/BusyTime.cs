using System;

namespace FreeBusy.Data
{
    public class BusyTime
    {
        public string EmployeeId { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public string Info { get; set; }
    }
}
