using ToDoList.CLI.Models;

namespace ToDoList.CLI.Storages
{
    public class UserStorage
    {
        private static readonly Dictionary<Email, User> _users = new();

        public static User? Get(Email email)
        {
            _users.TryGetValue(email, out User? user);
            return user;
        }

        public static bool Create(User user)
        {
            return _users.TryAdd(user.Email, user);
        }
    }
}
