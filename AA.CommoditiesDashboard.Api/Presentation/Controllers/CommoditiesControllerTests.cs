using AA.CommoditiesDashboard.Api.Controllers;
using Application.Interfaces;
using Domain.Common;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class CommoditiesControllerTests
    {
        private CommoditiesController controller;
        private readonly Mock<ICommoditiesService> service = new Mock<ICommoditiesService>();

        [Test]
        public async Task Get_ShouldReturn_ModelCommodities()
        {
            /// Arrange
            var modelCommodities = new List<ModelCommodity>
            {
                new ModelCommodity { Id = 1 },
                new ModelCommodity { Id = 2 }
            };

            service.Setup(_ => _.GetModelCommodities()).ReturnsAsync(modelCommodities);
            controller = new CommoditiesController(service.Object);

            /// Act
            var result = await controller.Get();

            /// Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
        }

        [Test]
        public async Task GetTradeActions_ShouldReturn_TradeActions()
        {
            /// Arrange
            var tradeActions = new List<TradeAction>
            {
                new TradeAction { Id = 1 },
                new TradeAction { Id = 2 }
            };

            service.Setup(_ => _.GetTradeActions()).ReturnsAsync(tradeActions);
            controller = new CommoditiesController(service.Object);

            /// Act
            var result = await controller.GetTradeActions();

            /// Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
        }

        [Test]
        public async Task GetChartDataById_ShouldReturn_ChartData()
        {
            /// Arrange
            var chartPoints = new List<ChartPoint>
            {
                new ChartPoint { Date = new System.DateTime(2022-06-05), Pnl = 1234.55m },
                new ChartPoint { Date = new System.DateTime(2022-06-04), Pnl = 4567.88m }
            };

            service.Setup(_ => _.GetChartData(It.IsAny<int>())).ReturnsAsync(chartPoints);
            controller = new CommoditiesController(service.Object);

            /// Act
            var result = await controller.GetChartDataById(It.IsAny<int>());

            /// Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
        }
    }
}
