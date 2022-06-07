using Application.Interfaces;
using Domain.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Api.Controllers
{
    public class CommoditiesController : BaseApiController
    {
        private readonly ICommoditiesService commoditiesService;

        public CommoditiesController(ICommoditiesService commoditiesService)
        {
            this.commoditiesService = commoditiesService ?? throw new ArgumentNullException(nameof(commoditiesService));
        }

        [HttpGet("")]
        public async Task<IEnumerable<ModelCommodity>> Get()
        {
            return await commoditiesService.GetModelCommodities();
        }

        [HttpGet]
        [Route("chartData/{id}")]
        public async Task<IEnumerable<ChartPoint>> GetChartDataById(int id)
        {
            return await commoditiesService.GetChartData(id);
        }
        
        [HttpGet]
        [Route("tradeActions")]
        public async Task<IEnumerable<TradeAction>> GetTradeActions()
        {
            return await commoditiesService.GetTradeActions();
        }
    }
}
