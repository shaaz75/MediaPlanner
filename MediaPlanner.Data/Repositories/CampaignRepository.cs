using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlanner.Data.Infrastructure;
using MediaPlanner.Model;
using Microsoft.EntityFrameworkCore;

namespace MediaPlanner.Data.Repositories
{
    public class CampaignRepository : RepositoryBase<Campaign>, ICampaignRepository
    {
        public CampaignRepository(DemoContext context) : base(context)
        {
            
        }

        public async Task<List<Campaign>> GetCampaigns()
        {
            return await _context.Campaign.ToListAsync();
        }
    }

    public interface ICampaignRepository
    {
         Task<List<Campaign>> GetCampaigns();
    }
}  
