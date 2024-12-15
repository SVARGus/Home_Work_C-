using System;
using Models_Employee;
using Models_MyTask;

namespace Program_Report
{
    internal class TaskReportContext // класс для переключения между стратегиями (отчетами).
    {
        private ITaskReport _strategy;
        public TaskReportContext(ITaskReport strategy)
        { _strategy = strategy; }
        public IEnumerable<MyTask> GenerateReport(in Dictionary<int, MyTask> tasks, in Dictionary<int, Employee> employees, in object parameter)
        {
            if (_strategy == null)
                throw new ArgumentNullException("Strategy Report is not set");
            return _strategy.GenerateReport(tasks, employees, parameter);
        }
    }
}
