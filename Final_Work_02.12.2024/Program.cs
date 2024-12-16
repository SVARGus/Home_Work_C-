using System.Numerics;
using System.Text.Json;
using System.Threading.Tasks;
using Models_Employee;
using Models_MyTask;
using MyJsonFileProcessor;
using Program_Report;

public class Program
{
	public static void Main()
	{
		// в константы
		const string filePathEmployees = "People.txt"; // Адрес от куда будет скачиваться json база сотрудников
        const string filePathTasks = "Tasks.txt"; // Адрес откуда скачиваться json база задач с назначенными сотрудниками
        Dictionary<int, Employee> employeesDictionary = new Dictionary<int, Employee>();
        Dictionary<int, MyTask> tasksDictionary = new Dictionary<int, MyTask>();
        var processor = new JsonFileProcessor(); // возможно стоит сделать сам класс статичским, чтоб не создавать объект
		(employeesDictionary, tasksDictionary) = processor.ProcessFile(filePathEmployees, filePathTasks);

		var testReport = new Dictionary<int, MyTask>(); // Тестовая коллекция отчетов

		var context = new TaskReportContext();
		const string filePathReport = "Report.txt";
		string jsonReport;

		//context.SetReport(new TaskForEmployeeReport()); // выбор отчетов Для определенного сотрудника
		//testReport = context.GenerateReport(tasksDictionary, employeesDictionary, 1);
		//// вывод на экран
		//Console.WriteLine("First report for Employ Id");
		//foreach (var task in testReport)
		//{
		//	Console.WriteLine(task);
		//}
		//Console.WriteLine(); // test - ok!!!

		//DateTimeOffset startDate = new DateTimeOffset(2024, 11, 28, 0, 0, 0, TimeSpan.Zero);
		//DateTimeOffset endDate = new DateTimeOffset(2024, 11, 28, 23, 59, 59, TimeSpan.Zero);
		//var dateRange = new Tuple<DateTimeOffset, DateTimeOffset>(startDate, endDate); // временной промежуток для отчета выборки по дате создания
		//context.SetReport(new TaskForDateReport()); // Созданные за определенное время
		//testReport = context.GenerateReport(tasksDictionary, employeesDictionary, dateRange);
		//// вывод на экран
		//Console.WriteLine("Secont report for Creat Datetime");
		//foreach (var task in testReport)
		//{
		//	Console.WriteLine(task);
		//}
		//Console.WriteLine(); // test - ok!!!

		//context.SetReport(new TasksWithStatusReport());
		//testReport = context.GenerateReport(tasksDictionary, employeesDictionary, Models_MyTask.TaskStatus.Planned);
		//// вывод на экран
		//Console.WriteLine("Third report for Status task");
		//foreach (var task in testReport)
		//{
		//	Console.WriteLine(task);
		//}
		//Console.WriteLine(); // test - ok!!!

		//context.SetReport(new TasksWithRiskReport());
		//testReport = context.GenerateReport(tasksDictionary, employeesDictionary, Risks.Gray);
		//// вывод на экран
		//Console.WriteLine("Fourth report for Risk task");
		//foreach (var task in testReport)
		//{
		//	Console.WriteLine(task);
		//}
		//Console.WriteLine(); // test - ok!!!

		//context.SetReport(new SubTasksForTaskIdReport());
		//testReport = context.GenerateReport(tasksDictionary, employeesDictionary, 1);
		//// вывод на экран
		//Console.WriteLine("Fifth report for Task Id");
		//foreach (var task in testReport)
		//{
		//	Console.WriteLine(task);
		//}
		//Console.WriteLine(); // test - ok!!!

		//jsonReport = processor.ConvertToJson(testReport);
		//Console.WriteLine(jsonReport);
		//processor.SaveJsonToFile(jsonReport, filePathReport);

		//foreach (var employee in employeesDictionary) // Вывод на экран временный
		//{
		//	Console.WriteLine(employee.ToString());
		//}
		foreach (var task in tasksDictionary) // Вывод на экран временный
		{
			Console.WriteLine(task.ToString());
		}
	}
}