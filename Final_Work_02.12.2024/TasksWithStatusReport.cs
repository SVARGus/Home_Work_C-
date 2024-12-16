using System;
using Models_Employee;
using Models_MyTask;

namespace Program_Report
{
    public class TasksWithStatusReport : ITaskReport
    {
        public IEnumerable<MyTask> GenerateReport(in Dictionary<int, MyTask> tasks, in Dictionary<int, Employee> employees, in object parameter)
        {
            if (parameter is not Models_MyTask.TaskStatus taskStatus) //TaskStatus попадает в несколько енамов и создает проблемму, пришлось явно указывать
            {
                throw new ArgumentException("Invalid Status Task for TasksWithStatusReport");
            }
            return tasks.Values
                .Where(task => task.Status == taskStatus);
        }
    }
}
