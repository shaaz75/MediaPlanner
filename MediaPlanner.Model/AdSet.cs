using System;
using System.Collections.Generic;

namespace MediaPlanner.Model
{
    public partial class AdSet
    {
        public int AdSetId { get; set; }
        public int? CampaignId { get; set; }
        public int? MediaChannelId { get; set; }
        public int? SupplierId { get; set; }

        public virtual Campaign Campaign { get; set; }
        public virtual MediaChannel MediaChannel { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
