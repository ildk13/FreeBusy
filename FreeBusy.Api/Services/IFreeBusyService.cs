using System;
using System.Collections.Generic;
using FreeBusy.Data;

namespace FreeBusy.Api.Services
{
    public interface IFreeBusyService
    {
        IEnumerable<Employee> GetEmployees();

        IEnumerable<Employee> GetAvailableEmployees(DateTime time, int duration);

        IEnumerable<BusyTime> GetBusyTimesForEmployee(string employeeId);
    }
}