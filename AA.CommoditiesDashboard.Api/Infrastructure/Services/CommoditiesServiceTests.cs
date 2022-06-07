using Application.Interfaces;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CommoditiesServiceTests
    {
        private CommoditiesService service;
        private readonly Mock<ICommoditiesDbContext> context = new Mock<ICommoditiesDbContext>();
        private readonly Mock<IMappingProfile> mappingProfile = new Mock<IMappingProfile>();

        [Test]
        public async Task GetModelCommodities_ShouldReturn_ModelCommodities()
        {
            /// Arrange
            var modelCommodities = new List<Domain.Entities.ModelCommodity>
            {
                new Domain.Entities.ModelCommodity { Id = 1 },
                new Domain.Entities.ModelCommodity { Id = 2 }
            };

            // Set up the entity
            var dbSet = MockDbSetFactory.Create(modelCommodities);
            context.Setup(x => x.ModelCommodities).Returns(dbSet.Object);

            mappingProfile.Setup(p => p.ModelCommodityMapper()).Returns(new MappingProfile().ModelCommodityMapper());

            service = new CommoditiesService(context.Object, mappingProfile.Object);

            /// Act
            var result = await service.GetModelCommodities();

            /// Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
        }

        [Test]
        public async Task GetChartData_ShouldReturn_GetChartPoints()
        {
            /// Arrange
            var dailyMetrics = new List<Domain.Entities.DailyMetrics>
            {
                new Domain.Entities.DailyMetrics
                {
                    Id = 1,
                    Date = new System.DateTime(2022-06-05),
                    PnlDaily = 1000m,
                    ModelCommodity = new Domain.Entities.ModelCommodity { Id = It.IsAny<int>() }
                },
                new Domain.Entities.DailyMetrics
                {
                    Id = 2,
                    Date = new System.DateTime(2022-06-06),
                    PnlDaily = 2000m,
                    ModelCommodity = new Domain.Entities.ModelCommodity { Id = It.IsAny<int>() }
                },
            };

            // Set up the entity
            var dbSet = MockDbSetFactory.Create(dailyMetrics);
            context.Setup(x => x.DailyMetrics).Returns(dbSet.Object);

            mappingProfile.Setup(p => p.ChartDataMapper()).Returns(new MappingProfile().ChartDataMapper());

            service = new CommoditiesService(context.Object, mappingProfile.Object);

            /// Act
            var result = await service.GetChartData(It.IsAny<int>());

            /// Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
        }

        [Test]
        public async Task GetTradeActions_ShouldReturn_NewTradeActions()
        {
            /// Arrange
            var dailyMetrics = new List<Domain.Entities.DailyMetrics>
            {
                new Domain.Entities.DailyMetrics
                {
                    Id = 1,
                    NewTradeAction = 5000,
                    PnlDaily = 1,
                    ModelCommodity = new Domain.Entities.ModelCommodity
                    {
                        Model = new Domain.Entities.Model { Name = "Model 1" },
                        Commodity = new Domain.Entities.Commodity { Name = "Commodity 1" }
                    }
                },
                new Domain.Entities.DailyMetrics
                {
                    Id = 2,
                    NewTradeAction = 10000,
                    PnlDaily = 2,
                    ModelCommodity = new Domain.Entities.ModelCommodity
                    {
                        Model = new Domain.Entities.Model { Name = "Model 2" },
                        Commodity = new Domain.Entities.Commodity { Name = "Commodity 2" }
                    }
                },
            };

            // Set up the entity
            var dbSet = MockDbSetFactory.Create(dailyMetrics);
            context.Setup(x => x.DailyMetrics).Returns(dbSet.Object);

            mappingProfile.Setup(p => p.TradeActionMapper()).Returns(new MappingProfile().TradeActionMapper());

            service = new CommoditiesService(context.Object, mappingProfile.Object);

            /// Act
            var result = await service.GetTradeActions();

            /// Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
        }
    }
}
