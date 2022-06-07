namespace Domain.Common
{
    public class ModelCommodity
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public string CommodityName { get; set; }
        public int Position { get; set; }
        public decimal Price { get; set; }
        public decimal VarAllocation { get; set; }
        public decimal PnlDaily { get; set; }
        public decimal PnlLTD { get; set; }
        public decimal DrawdownYTD { get; set; }
    }
}
