using Application.Interfaces;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class CommoditiesService : ICommoditiesService
    {
        private readonly ICommoditiesDbContext context;
        private readonly IMappingProfile mapper;

        public CommoditiesService(ICommoditiesDbContext context, IMappingProfile mapper)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ModelCommodity>> GetModelCommodities()
        {
            return await Task.FromResult(context.ModelCommodities
                .Select(m => m.Id).Distinct()
                .SelectMany(k => context.ModelCommodities
                    .Include(c => c.Model)
                    .Include(c => c.Commodity)
                    .Include(c => c.DailyMetrics)
                    .Where(c => c.Id == k))
                .Select(x => mapper.ModelCommodityMapper().Map<Domain.Entities.ModelCommodity, ModelCommodity>(x))
                .ToList());
        }

        public async Task<IEnumerable<ChartPoint>> GetChartData(int id)
            => await Task.FromResult(context.DailyMetrics
                .Where(x => x.ModelCommodity.Id == id)
                .Select(x => mapper.ChartDataMapper().Map<Domain.Entities.DailyMetrics, ChartPoint>(x)).ToList());

        public async Task<IEnumerable<TradeAction>> GetTradeActions()
        {
            var metrics = await Task.FromResult(context.DailyMetrics
                .SelectMany(key => context.DailyMetrics
                    .Where(x => x.NewTradeAction != null && x.PnlDaily != null)
                    .Include(x => x.ModelCommodity)
                        .ThenInclude(x => x.Model)
                    .Include(x => x.ModelCommodity)
                        .ThenInclude(x => x.Commodity)
                .OrderByDescending(m => m.Date)).Distinct().ToList());

            var tradeActions = metrics.Select(
                x => mapper.TradeActionMapper().Map<Domain.Entities.DailyMetrics, TradeAction>(x)).ToList();

            return tradeActions;
        }
    }
}
