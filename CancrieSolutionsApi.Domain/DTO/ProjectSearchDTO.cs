using Domains.SearchModels;

namespace Domains.DTO
{

    public class ProjectSearchDTO : BaseSearch
    {
        public int? Id { get; set; }
        public string ProjectName { get; set; }
        public string ClientName { get; set; }

    }
}
