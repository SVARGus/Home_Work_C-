using System.Text.Json;
using Models_Employee;
using Models_MyTask;
using MyJsonFileProcessor;

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

		//foreach (var employee in employeesDictionary) // Вывод на экран временный
		//{
		//	Console.WriteLine(employee.ToString());
		//}
		
		//foreach (var task in tasksDictionary) // Вывод на экран временный
		//{
		//	Console.WriteLine(task);
		//}
	}
}