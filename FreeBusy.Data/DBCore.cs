using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FreeBusy.Data
{
    public class DBCore : IDBCore
    {
        public DBCore()
        {
            MapDB();
        }

        public IList<Employee> Employees { get; private set; }

        public IList<BusyTime> BusyTimes { get; private set; }
        
        public IList<Employee> AvilablEmployees(DateTime when, int duration)
        {
            // Working hours
            if (when.Hour is < 8 or > 17)
            {
                throw new Exception("Beyond work hours");
            }

            var avilable = BusyTimes.Where(t =>
                t.From.Date == when.Date &&
                (t.From > when && t.From >= when.AddHours(duration)
                || t.To < when));

            return avilable.
                Select(time => Employees.FirstOrDefault(e => e.EmployeeId == time.EmployeeId)).
                OrderBy(e => e?.Surname).
                GroupBy(e => e?.EmployeeId).
                Select(s => s.First()).ToList();
        }

        public IList<BusyTime> GetBusyTimesForEmployee(string employeeId)
        {
            return BusyTimes.Where(b => b.EmployeeId == employeeId).OrderBy(b => b.From).ToList();
        }

        private void MapDB()
        {
            var lines = File.ReadAllLines("freebusy.txt");
            Employees = lines
                .Where(l => l.Split(";").Length is < 3 and > 1)
                .Select(e => new Employee
                {
                    EmployeeId = e.Split(";")[0],
                    Name = e.Split(";")[1].Split(' ')[0],
                    Surname = e.Split(";")[1].Split(' ').ElementAtOrDefault(1)
                }).ToList();

            BusyTimes = lines
                .Where(l => l.Split(";").Length > 3)
                .Select(f => new BusyTime
                {
                    EmployeeId = f.Split(";")[0],
                    From = DateTime.Parse(f.Split(";")[1]),
                    To = DateTime.Parse(f.Split(";")[2])
                }).ToList();
        }
    }
}
