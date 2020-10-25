namespace StockConsultantBot {
    public class StockInfo {
        public string symbol;
        public string Symbol { 
            set { symbol = value; } 
            get { return symbol.ToUpper(); } 
        }

        public decimal Open;
    }
}
