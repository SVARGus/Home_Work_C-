using System;
using Models_Employee;
using Models_MyTask;

namespace Program_Report
{
    public interface ITaskReport
    {
        public IEnumerable<MyTask> GenerateReport(in Dictionary<int, MyTask> tasks, in Dictionary<int, Employee> employees, in object parameter);
    }
}
