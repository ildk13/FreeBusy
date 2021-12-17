using System;
using System.Collections.Generic;
using FreeBusy.Data;

namespace FreeBusy.Api.Services
{
    public interface IFreeBusyService
    {
        IList<Employee> GetEmployees();

        IList<Employee> GetAvailableEmployees(DateTime time, int duration);

        IList<BusyTime> GetBusyTimesForEmployee(string employeeId);
    }
}