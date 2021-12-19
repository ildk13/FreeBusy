using System;
using System.Collections.Generic;
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

        public IEnumerable<Employee> GetEmployees()
        {
            return  dbCore.Employees;
        }

        public IEnumerable<Employee> GetAvailableEmployees(DateTime time, int duration)
        {
            return dbCore.AvilablEmployees(time, duration);
        }

        public IEnumerable<BusyTime> GetBusyTimesForEmployee(string employeeId)
        {
            return dbCore.GetBusyTimesForEmployee(employeeId);
        }
    }
}
