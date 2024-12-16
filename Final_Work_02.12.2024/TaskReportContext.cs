using System;
using Models_Employee;
using Models_MyTask;

namespace Program_Report
{
    internal class TaskReportContext // класс для переключения между стратегиями (отчетами).
    {
        private ITaskReport _strategy;
        public void SetReport(ITaskReport strategy)
        { _strategy = strategy; }
        public Dictionary<int, MyTask> GenerateReport(in Dictionary<int, MyTask> tasks, in Dictionary<int, Employee> employees, in object parameter)
        {
            if (_strategy == null)
                throw new ArgumentNullException("Strategy Report is not set");
            return _strategy.GenerateReport(tasks, employees, parameter);
        }
    }
}
