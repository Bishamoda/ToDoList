using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.CLI.Operations
{
    public interface IOperation
    {
        string Name { get; }
        bool Execute();
    }
}
