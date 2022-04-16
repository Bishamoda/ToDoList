using ToDoList.CLI;
using ToDoList.CLI.Operations;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

Menu tasksMenu = new Menu(
    operations: Array.Empty<IOperation>(),
    authorizedOperations: new IAuthorizedOperation[]
    {
        new CreateNewTaskOperation(),
        new UpdateTaskOperation(),
        new DeleteTaskOperation(),
        new CompleteTaskOperation()
    });

Menu menu = new Menu(
    operations: new IOperation[]
    {
        new LoginUserOperation(),
        new CreatNewUserOperation(),
    },
    authorizedOperations: new IAuthorizedOperation[]
    {
        new LogoutUserOperation(),
        new ReadAllTasksOperation(tasksMenu),
        new CreateNewTaskOperation()
    });

Application application = new Application(menu);
application.Run();