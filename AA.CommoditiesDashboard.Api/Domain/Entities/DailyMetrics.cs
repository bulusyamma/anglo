﻿using System;

namespace Domain.Entities
{
    public class DailyMetrics
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string Contract { get; set; }
        public decimal Price { get; set; }
        public int Position { get; set; }
        public int? NewTradeAction { get; set; }
        public decimal? PnlDaily { get; set; }

        public ModelCommodity ModelCommodity { get; set; }
    }
}
