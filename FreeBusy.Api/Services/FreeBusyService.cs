using System;
using System.Collections.Generic;
using System.Linq;
using FreeBusy.Data;

namespace FreeBusy.Api.Services
{
    public class FreeBusyService : IFreeBusyService
    {
        private readonly IDBCore dbCore;

        public FreeBusyService(IDBCore dbCore)
        {
            this.dbCore = dbCore ?? throw new ArgumentNullException(nameof(dbCore));
        }

        public IList<Employee> GetEmployees()
        {
            return  dbCore.Employees;
        }

        public IList<Employee> GetAvailableEmployees(DateTime time, int duration)
        {
            return dbCore.AvilablEmployees(time, duration);
        }

        public IList<BusyTime> GetBusyTimesForEmployee(string employeeId)
        {
            return dbCore.GetBusyTimesForEmployee(employeeId);
        }
    }
}
