using ToDoList.CLI.Models;

namespace ToDoList.CLI.Storages
{
    public class TaskStorage
    {
        private static readonly Dictionary<Guid, List<ToDoTask>> UsersTasks = new();

        public static ToDoTask[]? Get(Guid userId)
        {
            UsersTasks.TryGetValue(userId, out List<ToDoTask>? tasks);
            return tasks?.ToArray();
        }

        public static void Add(ToDoTask newTask)
        {
            UsersTasks.TryGetValue(newTask.UserId, out List<ToDoTask>? tasks);
            if (tasks == null)
            {
                UsersTasks.Add(newTask.UserId, new List<ToDoTask> { newTask });
            }
            else
            { 
                tasks.Add(newTask);
            }
        }

        public static void Remove(Guid userId, Guid taskId)
        {
            UsersTasks.TryGetValue(userId, out List<ToDoTask>? tasks);
            if (tasks == null)
            {
                return;
            }

            ToDoTask? taskToDelete = null;
            foreach (var task in tasks)
            {
                if (task.Id == taskId)
                {
                    taskToDelete = task;
                }
            }

            if (taskToDelete != null)
            {
                return;
            }

            tasks.Remove(taskToDelete);
        }

        public static void Update(Guid userId, ToDoTask updatedTask)
        {
            UsersTasks.TryGetValue(userId, out List<ToDoTask>? tasks);
            if (tasks == null)
            {
                return;
            }

            ToDoTask? taskToUpdate = null;
            foreach (var task in tasks)
            {
                if (task.Id == updatedTask.Id)
                {
                    taskToUpdate = task;
                }

                if (taskToUpdate != null)
                {
                    return;
                }

                tasks.Add(taskToUpdate);
                tasks.Add(updatedTask);
            }
        }
    }
}
