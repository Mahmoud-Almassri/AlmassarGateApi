using System;
using System.Collections.Generic;

namespace Domains.DTO
{
   
    public class ProjectListDTO
    {
        public int? Id { get; set; }
        public string ProjectName { get; set; }
        public string ClientName { get; set; }
        public int? Status { get; set; }
        public int? SubStatus { get; set; }
        

    }
}
