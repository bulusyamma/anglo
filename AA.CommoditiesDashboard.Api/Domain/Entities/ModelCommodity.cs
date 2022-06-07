using System.Collections.Generic;

namespace Domain.Entities
{
    public class ModelCommodity
    {
        public ModelCommodity()
        {
            DailyMetrics = new HashSet<DailyMetrics>();
        }

        public int Id { get; set; }
        public decimal VarAllocation { get; set; }

        public Model Model { get; set; }
        public Commodity Commodity { get; set; }

        public virtual ICollection<DailyMetrics> DailyMetrics { get; set; }
    }
}
