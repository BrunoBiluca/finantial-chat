using System;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace StockConsultantBot.Controllers {
    [Route("api/stock-consultant-bot")]
    [ApiController]
    public class StockConsultantBotController : ControllerBase {
        private readonly ILogger<StockConsultantBotController> logger;

        public StockConsultantBotController(ILogger<StockConsultantBotController> logger) {
            this.logger = logger;
        }

        [HttpGet("{stockName}", Name = "Get")]
        public async Task<ActionResult> Get(string stockName) {

            try {
                var stream = await requestStooqAsync(stockName);
                using var csv = new StreamReader(stream);
                var headers = csv.ReadLine();
                var content = csv.ReadLine();
                var fields = content.Split(',');

                if(fields[1] == "N/D") {
                    return NotFound($"{fields[0].ToUpper()} was not found. Did you spelled correcly the stock's name?");
                }

                var stockInfo = new StockInfo() {
                    Symbol = fields[0].ToUpper(),
                    Open = decimal.Parse(fields[3], new CultureInfo("en-US"))
                };

                return Ok($"{stockInfo.Symbol} quote is ${stockInfo.Open.ToString("0.00", CultureInfo.InvariantCulture)} per share");
            } catch(FormatException ex) {
                logger.LogError(ex.ToString());
                return StatusCode(500, "Internal server error.");
            } catch(HttpRequestException) {
                return StatusCode(502, "Could not connect to stooq.com. Please try again later.");
            }
        }

        private async Task<Stream> requestStooqAsync(string stockName) {
            var client = new HttpClient();
            var stream = await client.GetStreamAsync($"https://stooq.com/q/l/?s={stockName}&f=sd2t2ohlcv&h&e=csv");
            return stream;
        }

    }
}
