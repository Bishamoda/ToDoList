using ToDoList.CLI.Models;

namespace ToDoList.CLI.Storages
{
    public class TaskStorage
    {
		private static readonly Dictionary<string, Models.Task> _tasks = new();

		public static Models.Task? Get(string name)
		{
			_tasks.TryGetValue(name, out Models.Task? tasks);
			return tasks;
		}

		public static bool Create(Models.Task task)
		{
			return _tasks.TryAdd(task.Name, task);
		}
	}
}
