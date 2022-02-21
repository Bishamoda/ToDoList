
using ToDoList.CLI.Models;
using ToDoList.CLI.Storages;

namespace ToDoList.CLI.Operations
{
    public class LoginUserOperation : IOperation
    {
        public string Name => "Залогинься в системе";

        public void Execute()
        {
            Console.Write("Введите ваш email:");
            string? email = Console.ReadLine();
            User? user = UserStorage.Get(email);

            if (user == null)
            {
                UserSession.CurrentUser = user;
            }
        }
    }
}
