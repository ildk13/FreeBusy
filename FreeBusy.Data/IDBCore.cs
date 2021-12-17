using System;
using System.Collections.Generic;

namespace FreeBusy.Data
{
    public interface IDBCore
    {
        IList<Employee> Employees { get; }

        IList<BusyTime> BusyTimes { get; }

        IList<Employee> AvilablEmployees(DateTime when, int duration);

        IList<BusyTime> GetBusyTimesForEmployee(string employeeId);
    }
}