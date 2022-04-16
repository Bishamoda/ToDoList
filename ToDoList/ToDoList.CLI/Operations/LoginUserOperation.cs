
using ToDoList.CLI.Models;
using ToDoList.CLI.Storages;

namespace ToDoList.CLI.Operations
{
    public class LoginUserOperation : IOperation
    {
        public string Name => "Залогинься в системе";

        public bool Execute()
        {
            Console.Write("Введите ваш email:");
            string? userInput = Console.ReadLine();
            var (email, error) = Email.Create(userInput);
            if (email == null)
            {
                Console.WriteLine(error);
                return false;
            }

            User? user = UserStorage.Get(email);
            if (user == null)
            {
                Console.WriteLine("Пользователь не найден");
                return false;
            }

            UserSession.CurrentUser = user;
            return true;
        }
    }
}
