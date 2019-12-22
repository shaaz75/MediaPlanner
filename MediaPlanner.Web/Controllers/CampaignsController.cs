using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlanner.Model;
using MediaPlanner.Service;
using MediaPlanner.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MediaPlanner.Web.Controllers
{
    public class CampaignsController : Controller
    {
        private readonly ICampaignService campaignService;
        public CampaignsController(ICampaignService campaignService)
        {
            this.campaignService = campaignService;
        }
        public async Task<IActionResult> Index(string searchString, int? page)
        {
            var demoContext = await this.campaignService.GetCampaigns();
            var pieData = demoContext;
            if (!String.IsNullOrEmpty(searchString))
            {
                demoContext = demoContext.Where(s => s.CampaignName.Contains(searchString)).ToList();
                pieData = pieData.Where(s => s.CampaignName.Contains(searchString)).ToList();
            }

            ViewBag.PieData = JsonConvert.SerializeObject(pieData);

            int pageSize = 1;
            int pageNumber = (page ?? 1);
            return View(await PaginatedList<Campaign>.CreateAsync(demoContext.AsQueryable(), pageNumber == 0 ? 1 : pageNumber, pageSize));
        }
    }
}