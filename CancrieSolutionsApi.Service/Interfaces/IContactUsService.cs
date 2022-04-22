using AlmassarGate.Domain.Models;
using Domains.DTO;
using Domains.SearchModels;
using Service.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IContactUsService : IService<ContactUs>
    {
        public BaseListResponse<ContactUs> GetList(BaseSearch baseSearch);
    }
}
