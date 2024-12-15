

using MyNameEmployee;
using MyNameTask;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;

namespace MyJsonFileProcessor
{
	internal class JsonFileProcessor
	{
		public string DownloadFiles(in string filePath) // метод принимающий адрес файла формата Json и переводящий его в строку
		{
			/* сдесь можно настроить логику определения в каком формате передан файл 
			и его обрабатывать соотвествующим образом, напримет это может быть txt, 
			json или например url.
			В данном случае пока будет обрабатываться txt файл содержащий json 
			*/
			string jsonString = File.ReadAllText(filePath);
			return jsonString;
		}
		public (Dictionary<int, Employee>, Dictionary<int, MyTask>) ParseJsonToDictionary(in string employeeJsonString, in string taskJsonString)
		{
			var employees = JsonSerializer.Deserialize<List<Employee>>(employeeJsonString);
			var tasks = JsonSerializer.Deserialize<List<MyTask>>(taskJsonString);
			Dictionary<int, Employee> employeesDictionary = new Dictionary<int, Employee>();
			foreach (var employee in employees)
			{
				employeesDictionary[employee.Id] = employee;
			}
			Dictionary<int, MyTask> tasksDictionary = new Dictionary<int, MyTask>();
			foreach (var task in tasks)
			{
				tasksDictionary[task.Id] = task;
			}
			return (employeesDictionary, tasksDictionary);
		}
		public void BuildRelationships(Dictionary<int, Employee> employees, Dictionary<int, MyTask> tasks)
		{
			// настройка связей в сотрудниках
			foreach (var employee in employees)
			{
				if (employee.Value.SupervisorId != null)
				{
					employee.Value.Supervision = employees[(int)employee.Value.SupervisorId];
				}
			}
			// Настройка связей в задачах
			foreach (var task in tasks)
			{
				// настройка связи с Dictionary сотрудников
				if (task.Value.Assignee != null)
				{
					task.Value.Assignee = employees[(int)task.Value.Assignee.Id];
				}
				// Настройка связей подзадач
				if (task.Value.SubTasks != null)
				{
					task.Value.SubTasksList = new List<MyTask>();
					foreach (var subTask in task.Value.SubTasks)
					{
						task.Value.SubTasksList.Add(tasks[(int)subTask]);
					}
				}
			}
		}
		// метод для вызова всех шагов
		public (Dictionary<int, Employee>, Dictionary<int, MyTask>) ProcessFile(in string employeeFilePath, in string taskFilePath)
		{
			var employeeJsonStr = DownloadFiles(employeeFilePath);
			var taskJsonStr = DownloadFiles(taskFilePath);
			var(employeeDict, taskDict) = ParseJsonToDictionary(employeeJsonStr, taskJsonStr);
			BuildRelationships(employeeDict, taskDict);
			return(employeeDict,taskDict);
		}
		//Метод конвертации Dictionary или List в Json строку
		public string ConvertToJson<T>(T data)
		{
			return JsonSerializer.Serialize(data); // проверить работает или нет
		}
		public void SaveJsonToFile(in string jsonString, in string filePath)
		{
			// Реализация метода
		}
	}
}
