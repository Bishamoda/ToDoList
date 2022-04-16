using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.CLI.Models
{
    public record Email
    {
        public string Value { get; init; }

        private Email(string value)
        {
            Value = value;
        }

        public static (Email? Email, string Error) Create(string? email)
        {
            if (string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
            {
                return(null, "некорректный email: " + email);
            }

            return (new Email(email), string.Empty);
        }
    }
}
