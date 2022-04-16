
namespace ToDoList.CLI.Models
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }
        public Email Email { get; set; }
    }
}
