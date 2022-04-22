using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmassarGateApi.Domain.Models.Common
{
    public class PushNotification
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string DeviceToken { get; set; }


        public long? UserId { get; set; }
        public List<long> UsersIds { get; set; }
        public string Type { get; set; }
        public object Data { get; set; }
        public string Role { get; set; }
        public int DeviceType { get; set; }
    }
}
