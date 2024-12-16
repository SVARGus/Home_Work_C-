using System;
using Models_Employee;
using Models_MyTask;

namespace Program_Report
{
    public class TasksWithRiskReport : ITaskReport
    {
        public IEnumerable<MyTask> GenerateReport(in Dictionary<int, MyTask> tasks, in Dictionary<int, Employee> employees, in object parameter)
        {
            if (parameter is not Risks taskRisk)
            {
                throw new ArgumentException("Invalid Risk for TasksWithRiskReport");
            }
            return tasks.Values
                .Where(task => task.Risks == taskRisk);
        }
    }
}
