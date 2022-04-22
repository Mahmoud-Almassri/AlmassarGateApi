using AlmassarGate.Domain.DTO.AddDTO;
using AlmassarGate.Domain.Models;
using Service.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IAppSettingsService : IService<AppSettings>
    {
        public AppSettingsAddUpdateDTO UpdateEntity(AppSettingsAddUpdateDTO entity);
        public AppSettings GetAppSettings();
    }
}
