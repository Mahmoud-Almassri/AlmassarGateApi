using AlmassarGate.Domain.Models.Common;
using Domains.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmassarGateApi.Domain.DTO
{
    public class ProjectFilesDTO
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
    }
}
