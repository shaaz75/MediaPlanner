using System;
using System.Collections.Generic;

namespace MediaPlanner.Model
{
    public partial class Campaign
    {
        public Campaign()
        {
            Ad = new HashSet<Ad>();
            AdSet = new HashSet<AdSet>();
        }

        public int CampaignId { get; set; }
        public string CampaignName { get; set; }
        public int? ClientId { get; set; }
        public int? CountryId { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public decimal? Budget { get; set; }

        public virtual Client Client { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Ad> Ad { get; set; }
        public virtual ICollection<AdSet> AdSet { get; set; }
    }
}
