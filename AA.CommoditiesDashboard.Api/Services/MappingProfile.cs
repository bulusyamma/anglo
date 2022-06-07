using Application.Interfaces;
using AutoMapper;
using Domain.Common;

namespace Services
{
    public class MappingProfile : Profile, IMappingProfile
    {
        public IMappingProfile Instance => new MappingProfile();

        public IMapper ModelCommodityMapper()
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<Domain.Entities.ModelCommodity, ModelCommodity>()
            );

            return new Mapper(config);
        }
        
        public IMapper ChartDataMapper()
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<Domain.Entities.DailyMetrics, ChartPoint>()
                    .ForMember(dest => dest.Date, act => act.MapFrom(src => src.Date))
                    .ForMember(dest => dest.Pnl, act => act.MapFrom(src => src.PnlDaily))
            );

            return new Mapper(config);
        }

        public IMapper TradeActionMapper()
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<Domain.Entities.DailyMetrics, TradeAction>()
                    .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
                    .ForMember(dest => dest.ModelName, act => act.MapFrom(src => src.ModelCommodity.Model.Name))
                    .ForMember(dest => dest.CommodityName, act => act.MapFrom(src => src.ModelCommodity.Commodity.Name))
                    .ForMember(dest => dest.NewTradeAction, act => act.MapFrom(src => src.NewTradeAction))
            );

            return new Mapper(config);
        }
    }
}
