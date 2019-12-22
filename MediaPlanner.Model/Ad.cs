using System;
using System.Collections.Generic;

namespace MediaPlanner.Model
{
    public partial class Ad
    {
        public int AdId { get; set; }
        public string AddName { get; set; }
        public decimal? AdBudget { get; set; }
        public int? CampaignId { get; set; }
        public DateTime? AdStartDateTime { get; set; }
        public DateTime? AdEndDateTime { get; set; }

        public virtual Campaign Campaign { get; set; }
    }
}
