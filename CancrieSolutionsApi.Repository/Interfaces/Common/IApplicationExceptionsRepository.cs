using Domains.Models;

namespace Repository.Interfaces.Common
{
    public interface IApplicationExceptionsRepository
    {
        public ApplicationExceptions WriteException(ApplicationExceptions ex);

    }
}
