using System;
using System.Collections.Generic;

namespace MediaPlanner.Model
{
    public partial class MediaChannel
    {
        public MediaChannel()
        {
            AdSet = new HashSet<AdSet>();
            Supplier = new HashSet<Supplier>();
        }

        public int MediaChannelId { get; set; }
        public string MediaChannelName { get; set; }

        public virtual ICollection<AdSet> AdSet { get; set; }
        public virtual ICollection<Supplier> Supplier { get; set; }
    }
}
