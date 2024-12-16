using System;
using Models_Employee;
using Models_MyTask;

namespace Program_Report
{
    public class TaskForDateReport : ITaskReport
    {
        public Dictionary<int, MyTask> GenerateReport(in Dictionary<int, MyTask> tasks, in Dictionary<int, Employee> employees, in object parameter)
        {
            if(parameter is not Tuple<DateTimeOffset, DateTimeOffset> dateRange)
            {
                throw new ArgumentException("Invalid CreationDate for TaskForDateReport");
            }
            return tasks.Values
                .Where(task => task.CreationDate >= dateRange.Item1 && task.CreationDate <= dateRange.Item2).ToDictionary(task => task.Id, task => task);
        }
    }
}
