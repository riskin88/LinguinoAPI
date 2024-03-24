using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Config
{
    public class SubscriptionSettings
    {
        public string StripeApiKey { get; set; }
        public string WebhookSecret { get; set; }
        public string PriceId { get; set; }
        public int TrialDays { get; set; }
    }
}
