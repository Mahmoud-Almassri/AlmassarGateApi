using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmassarGateApi.Domain.DTO
{
    public class PushNotificationDTO
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public List<long> UsersIds { get; set; }
    }
}
