using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.CLI.Models;
using ToDoList.CLI.Storages;

namespace ToDoList.CLI.Operations
{
    public class UpdateTaskOperation : IAuthorizedOperation
    {
        public string Name => "Изменить задачу";

        public bool Execute(Guid userId)
        {
            ToDoTask[]? tasks = TaskStorage.Get(userId);

            if (tasks == null || tasks.Length == 0)
            {
                Console.WriteLine("Задач нет, добавьте новые через меню");
                return true;
            }

            for (var i = 0; i < tasks.Length; i++)
            {
                var task = tasks[i];
                Console.WriteLine($"#{i} - Name: {task.Name}, IsDone: {task.IsCompleted}");
            }

            Console.WriteLine();

            Console.Write("Введите номер задачи для выполнения: ");
            string? userInput = Console.ReadLine();
            bool isNumber = int.TryParse(userInput, out int taskNumber);

            if (!isNumber)
            {
                Console.WriteLine("Неверный номер задачи: " + userInput);
                return false;
            }

            ToDoTask taskToUpdate = tasks[taskNumber];

            Console.Write("Введите название задачи: ");
            string? name = Console.ReadLine();

            Console.Write("Введите описание задачи: ");
            string? description = Console.ReadLine();

            var (updatedTask, error) = taskToUpdate.Update(name, description);

            if (updatedTask == null)
            {
                Console.WriteLine(error);
                return false;
            }

            TaskStorage.Update(userId, updatedTask);
            return true;
        }
    }
}
