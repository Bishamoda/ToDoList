
namespace ToDoList.CLI.Models
{
    public record ToDoTask
    {
        private ToDoTask()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; init; }
        public bool IsCompleted { get; set; }
        public Guid UserId { get; init; }

        public (ToDoTask? Task, string Error) Update(string? name, string? description)
        {
            var (isValid, error) = Validate(name, description);
            if (!isValid)
            {
                return (null, error);
            }

            ToDoTask updatedTask = this with
            {
                Name = name,
                Description = description
            };

            return (updatedTask, String.Empty);
        }

        public static (ToDoTask? Task, string Error) Create(string? name, string? description, Guid userId)
        {
            var (isValid, error) = Validate(name, description);
            if (!isValid)
            {
                return (null, error);
            }

            ToDoTask newTask = new ToDoTask()
            {
                Name = name,
                Description = description,
                UserId = userId
            };

            return (newTask, String.Empty);
        }

        private static (bool Result, string Error) Validate(string? name, string? description)
        {
            List<string> errors = new();
            if (string.IsNullOrWhiteSpace(name))
            {
                errors.Add("Неврено введено название: " + name);
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                errors.Add("Неверно введено описание: " + description);
            }

            if (errors.Any())
            {
                return (false, String.Join("\n", errors));
            }
            return (true, String.Empty);
        }
    }
}
