using System;
using Models_Employee;
using Models_MyTask;

namespace Program_Report
{
    public class SubTasksForTaskIdReport : ITaskReport
    {
        public IEnumerable<MyTask> GenerateReport(in Dictionary<int, MyTask> tasks, in Dictionary<int, Employee> employees, in object parameter)
        {
            if (parameter is not int idTask || !tasks.ContainsKey(idTask))
            {
                throw new ArgumentException("Invalid Task Id for SubTasksForTaskIdReport");
            }
            var task = tasks[idTask].SubTasksList.ToDictionary(tasks1 => tasks1.Id);

            return task;// гдето ошибка???
        }
    }
}
