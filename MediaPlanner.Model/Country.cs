﻿using System;
using System.Collections.Generic;

namespace MediaPlanner.Model
{
    public partial class Country
    {
        public Country()
        {
            Campaign = new HashSet<Campaign>();
        }

        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public virtual ICollection<Campaign> Campaign { get; set; }
    }
}
