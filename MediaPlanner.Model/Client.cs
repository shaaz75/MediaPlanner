using System;
using System.Collections.Generic;

namespace MediaPlanner.Model
{
    public partial class Client
    {
        public Client()
        {
            Campaign = new HashSet<Campaign>();
        }

        public int ClientId { get; set; }
        public string ClientName { get; set; }

        public virtual ICollection<Campaign> Campaign { get; set; }
    }
}
