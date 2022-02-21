using ToDoList.CLI.Models;
using ToDoList.CLI.Storages;

namespace ToDoList.CLI.Operations
{
    public class CreatNewUserOperation : IOperation
    {
		public string Name => "Создать нового пользователя";

        public void Execute()
        {
			Console.Write("Введите ваш email:");
			string? email = Console.ReadLine();

			User newUser = new User
			{
				Email = email,
			};

			bool userCreated = UserStorage.Create(newUser);
			if (!userCreated)
			{
				Console.WriteLine("Пользователь с таким email уже есть");
			}

			Console.WriteLine("Пользователь был успешно создан");
		}
    }
}
