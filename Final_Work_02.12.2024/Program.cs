using System.Text.Json;
using MyNameEmployee;
using MyNameTask;
using MyJsonFileProcessor;

public class Program
{
	public static void Main()
	{
		// Наверное лучше вынести в отдельный метод (статический класс) десириализацию
		// в константы
		string filePathEmployees = "People.txt"; // Адрес от куда будет скачиваться json база сотрудников
		string filePathTasks = "Tasks.txt"; // Адрес откуда скачиваться json база задач с назначенными сотрудниками
		string jsonString = File.ReadAllText(filePathEmployees);
		//List<>
		var employees = JsonSerializer.Deserialize<List<Employee>>(jsonString);
	
		Dictionary<int, Employee> employeesDictionary = new Dictionary<int, Employee>();
		foreach(var employee in employees)
		{
			employeesDictionary[employee.Id] = employee;
		}
		foreach (var employee in employeesDictionary)
		{
			if(employee.Value.SupervisorId != null)
			{
				employee.Value.Supervision = employeesDictionary[(int)employee.Value.SupervisorId];
			}
		}
		//foreach (var employee in employeesDictionary) // Вывод на экран временный
		//{
		//	Console.WriteLine(employee.ToString());
		//}
		// работа с Tasks.txt - позже все вывести вотдельный метод (класса?)
		jsonString = File.ReadAllText(filePathTasks);
		var tasks = JsonSerializer.Deserialize<List<MyTask>>(jsonString);
		Dictionary<int, MyTask> tasksDictionary = new Dictionary<int, MyTask>();
		foreach(var task in tasks)
		{
			task.Assignee = employeesDictionary[(int)task.Assignee.Id];
			tasksDictionary[task.Id] = task;
		}
		foreach (var task in tasksDictionary)
		{
			if(task.Value.SubTasks != null)
			{
				task.Value.SubTasksList = new List<MyTask>();
				foreach (var subTask in task.Value.SubTasks)
				{
					task.Value.SubTasksList.Add(tasksDictionary[(int)subTask]);
				}
			}
		}
		//foreach(var task in tasksDictionary) // Вывод на экран временный
		//{
		//	Console.WriteLine(task);
		//}
	}
}

public enum Risks // Риск незакрытия задачи в срок
{
	Gray,
	Green,
	Yellow,
	Red
}
