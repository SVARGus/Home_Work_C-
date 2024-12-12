using System.Text.Json.Serialization;
using MyNameEmployee;

namespace MyNameTask
{
	public class MyTask
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public DateTimeOffset CreationDate { get; set; }
		public DateTimeOffset Deadline {  get; set; }
		public Employee Assignee { get; set; }
		public TaskStatus Status { get; set; }
		public Risks Risks { get; set; }
		public List<int> SubTasks { get; set; }
		[JsonIgnore]
		public List<MyTask> SubTasksList { get; set; }
		public override string ToString()
		{
			string sbTasksListStr = SubTasksList != null && SubTasksList.Count > 0 ? 
				string.Join("\n", SubTasksList.Select(t => "\tsubtask Id: " + 
				t.Id.ToString() + " Title: " + t.Title.ToString())) : "\tNO SubTasks";
			string str = $"Id task = {Id}, Title: {Title}\n" +
				$"Creation: {CreationDate}\n" +
				$"Deadline: {Deadline}\n" +
				$"Assignee employee: Id {Assignee.Id} Name {Assignee.Name}\n" +
				$"Status: {Status}\n" +
				$"Risks: {Risks}\n" +
				$"Subtasks:\n{sbTasksListStr}";
			return str;
		}
	}
	public enum TaskStatus // Статус задачи
	{
		Planned,
		InDevelopment,
		OnReview,
		Closed
	}
	public enum Risks // Риск незакрытия задачи в срок
	{
		Gray,
		Green,
		Yellow,
		Red
	}
}
