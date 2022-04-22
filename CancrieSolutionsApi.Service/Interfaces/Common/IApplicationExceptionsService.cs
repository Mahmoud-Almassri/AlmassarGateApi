using Domains.Models;
using System;

namespace Service.Interfaces.Common
{
    public interface IApplicationExceptionsService
    {
        ApplicationExceptions WriteException(Exception ex);
    }
}
