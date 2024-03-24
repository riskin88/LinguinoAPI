using DAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Subscriptions
{
    public class GetSubscriptionDTO
    {
        public SubscriptionStatus? Status { get; set; }
        public DateTime? CurrentPeriodEnd { get; set; }
    }
}
