using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.CLI.Operations
{
    public  class LogoutUserOperation : IAuthorizedOperation
    {
        public string Name => "Выйти из пользователя";
        public bool Execute(Guid userId)
        {
            if (UserSession.CurrentUser != null)
            {

                UserSession.CurrentUser = null;
                return true;
            }

            return false;
        }
    }
}
