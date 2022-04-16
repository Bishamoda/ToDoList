using ToDoList.CLI.Models;
using ToDoList.CLI.Storages;

namespace ToDoList.CLI.Operations
{
    public class CreateNewTaskOperation : IAuthorizedOperation
    {
        public string Name => "Создать новую задачу"; 

        public bool Execute(Guid userId)
        {
            Console.WriteLine("Введите название задачи: ");
            string? name = Console.ReadLine();

            Console.WriteLine("Введите описание заадчи: ");
            string? description = Console.ReadLine();

            var (newTask, error) = ToDoTask.Create(name, description, userId);

            if (newTask == null)
            {
                Console.WriteLine(error);
                return false;
            }

            TaskStorage.Add(newTask);

            return true;
        }
    }
}
