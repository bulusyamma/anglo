using AutoMapper;

namespace Application.Interfaces
{
    public interface IMappingProfile
    {
        IMapper ModelCommodityMapper();
        IMapper ChartDataMapper();
        IMapper TradeActionMapper();
    }
}
