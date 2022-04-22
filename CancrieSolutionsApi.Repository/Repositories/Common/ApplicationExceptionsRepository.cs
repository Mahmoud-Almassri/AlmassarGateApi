using Domain;
using AlmassarGate.Domain.Models.Common;
using Repository.Interfaces.Common;
using Repository.Context;
using Domains.Models;

namespace Repository.Repositories.Common
{
    public class ApplicationExceptionsRepository : IApplicationExceptionsRepository
    {
        #region [Context]
        protected AlmassarGateContext Context;
        #endregion

        public ApplicationExceptionsRepository(AlmassarGateContext context)
        {
            Context = context;
        }

        public ApplicationExceptions WriteException(ApplicationExceptions ex)
        {
            Context.Set<ApplicationExceptions>().Add(ex);
            Context.SaveChanges();
            Context.Entry(ex).GetDatabaseValues();

            return ex;
        }
    }
}
