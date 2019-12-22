using MediaPlanner.Data.Infrastructure;
using MediaPlanner.Data.Repositories;
using MediaPlanner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlanner.Service
{
    public interface ICampaignService
    {
        Task<List<Campaign>> GetCampaigns();
        void SaveCategory();
    }

    public class CampaignService : ICampaignService
    {
        private readonly ICampaignRepository campaignRepository;
        private readonly IUnitOfWork unitOfWork;

        public CampaignService(ICampaignRepository campaignRepository, IUnitOfWork unitOfWork)
        {
            this.campaignRepository = campaignRepository;
            this.unitOfWork = unitOfWork;
        }

        #region ICategoryService Members

        public async Task<List<Campaign>> GetCampaigns()
        {
            return await this.campaignRepository.GetCampaigns();
        }

        public void SaveCategory()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}
