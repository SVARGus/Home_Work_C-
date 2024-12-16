using System;
using Models_Employee;
using Models_MyTask;

namespace Program_Report
{
    public class TaskForEmployeeReport : ITaskReport
    {
        public IEnumerable<MyTask> GenerateReport(in Dictionary<int, MyTask> tasks, in Dictionary<int, Employee> employees, in object parameter)
        {
            if(parameter is not int EmployeeId || !employees.ContainsKey(EmployeeId))
            {
                throw new ArgumentException("Invalid Employee Id for TaskForEmployeeReport");
            }
            return tasks.Values
                .Where(task => task.Assignee?.Id == EmployeeId);
        }
    }
}
