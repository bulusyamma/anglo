using Domain.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICommoditiesService
    {
        Task<IEnumerable<TradeAction>> GetTradeActions();
        Task<IEnumerable<ModelCommodity>> GetModelCommodities();
        Task<IEnumerable<ChartPoint>> GetChartData(int id);
    }
}
