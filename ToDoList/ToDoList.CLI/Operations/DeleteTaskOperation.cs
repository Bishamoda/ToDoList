using ToDoList.CLI.Models;
using ToDoList.CLI.Storages;

namespace ToDoList.CLI.Operations
{
    public class DeleteTaskOperation : IAuthorizedOperation
    {
        public string Name => "Удалить задачу";

        public bool Execute(Guid userId)
        {
            ToDoTask[]? tasks = TaskStorage.Get(userId);

            if (tasks == null || tasks.Length == 0)
            {
                Console.WriteLine("Задач нет, добавьте новые задачи через меню");
                return true;
            }

            for (var i = 0; i < tasks.Length; i++)
            {
                var task = tasks[i];
                Console.WriteLine($"#{i} - Name: {task.Name}, IsDone: {task.IsCompleted}");
            }

            Console.WriteLine();

            Console.Write("Введите номер задачи для удаления: ");
            string? userInput = Console.ReadLine();
            bool isNumber = int.TryParse(userInput, out int taskNumber);

            if (!isNumber)
            {
                Console.WriteLine("Неверный номер задачи: " + userInput);
                return false;
            }

            ToDoTask taskToDelete = tasks[taskNumber];
            TaskStorage.Remove(userId, taskToDelete.Id);
            return true;
        }
    }
}
