using ToDoList.CLI;
using ToDoList.CLI.Operations;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

IOperation[] operations = new IOperation[]
{
    new LoginUserOperation(),
    new CreatNewUserOperation()
};

Menu menu = new Menu(operations);
Application application = new Application(menu);
application.Run();