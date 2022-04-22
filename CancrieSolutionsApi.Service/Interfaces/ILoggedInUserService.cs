using System.Collections.Generic;

namespace Service.Interfaces
{
    public interface ILoggedInUserService
    {
        int GetUserId();
        List<string> GetUserRoles();
        string GetUserName();
        bool IsLoggedInUser();
    }
}
