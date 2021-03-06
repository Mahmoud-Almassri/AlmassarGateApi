using AlmassarGate.Domain.Models.Common;
using Domains.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmassarGateApi.Domain.DTO.AddDTO
{
    public class ProjectFilesAddDTO
    {
        public int ProjectId { get; set; }
        public int? FileCategory { get; set; }
        public string Name { get; set; }
        public IFormFile File { get; set; }
    }
}
