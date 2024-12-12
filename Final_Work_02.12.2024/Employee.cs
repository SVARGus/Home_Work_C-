using System.Text.Json.Serialization;

namespace MyNameEmployee
{
	public class Employee
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public Positions Position { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
		public int? SupervisorId { get; set; }
		[JsonIgnore]
		public Employee Supervision { get; set; }

		public override string ToString()
		{
			string supervisionStr = Supervision != null ? Supervision.ToString() : "No supervisor";
			string str = $"Id Employee = {Id}\n" +
				$"Name: {Name}\n" +
				$"Position:{Position}\n" +
				$"Login: {Login}\n" +
				$"Password: {Password}\n" +
				$"Supervision: {supervisionStr}\n";
			return str;
		}
	}
	public enum Positions // должность
	{
		Frontender,
		Backender,
		Analyst,
		TeamLider,
		Accountant,
		ScrumMaster,
		Administrator
	}
}
