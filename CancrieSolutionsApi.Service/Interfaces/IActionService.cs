using Domains.DTO;
using Domains.SearchModels;
using Service.Interfaces.Common;
using System.Collections.Generic;
using Action = Domains.Models.Action;

namespace AlmassarGateApi.Service.Interfaces
{
    public interface IActionService : IService<Action, BaseSearch>
    {
        List<ActionDTO> GetActionsByProjectId(int projectId);
    }
}
