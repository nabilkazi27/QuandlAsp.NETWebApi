using System;
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;

namespace TaskApi.Models {
    public class Stock
    {
        public DateTime StockDate { get; set; }

        public double StockOpen { get; set; }

        public double StockHigh { get; set; }

        public double StockLow { get; set; }

        public double StockClose { get; set; }

        public double StockWAP { get; set; }

        public int StockNoOfShares { get; set; }

        public int StockNoOfTrades { get; set; }

        public double StockTotalTurnover { get; set; }

        public int StockDeliverableQuantity { get; set; }

        public double StockDeliverableQuantityToTradedQuantityPercent { get; set; }

        public double StockSpreadHL { get; set; }

        public double StockSpreadCO { get; set; }

    }
}