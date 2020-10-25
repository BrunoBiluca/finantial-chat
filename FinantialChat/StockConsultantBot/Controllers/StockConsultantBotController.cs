using System;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StockConsultantBot.RabbitMQ;

namespace StockConsultantBot.Controllers {
    [Route("api/stock-consultant-bot")]
    [ApiController]
    public class StockConsultantBotController : ControllerBase {
        private readonly ILogger<StockConsultantBotController> logger;

        public StockConsultantBotController(ILogger<StockConsultantBotController> logger) {
            this.logger = logger;
        }

        [HttpGet("/{stockName}/http", Name = "GetHttp")]
        public async Task<ActionResult> Get(string stockName) {

            try {
                var stream = await RequestStooqAsync(stockName);
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

        [HttpGet("{stockName}", Name = "Get")]
        public ActionResult GetRabbitMQ(string stockName) {
            FowardMessage(stockName);

            Console.WriteLine("Front-end answered");
            return Accepted();
        }

        private async void FowardMessage(string stockName) {
            await Task.Run(async () => {
                var message = await FormatMessage(stockName);
                Console.WriteLine("Message delivered to RabbitMQ");
                RabbitMQContext.SendMessage(message);
            });
        }

        private async Task<ChatMessage> FormatMessage(string stockName) {
            var chatMessage = new ChatMessage() {
                UserName = "Stock Bot",
                CreatedAt = DateTime.Now
            };
            try {
                var stream = await RequestStooqAsync(stockName);
                Console.WriteLine("Request Stooq Finished");

                using var csv = new StreamReader(stream);
                var headers = csv.ReadLine();
                var content = csv.ReadLine();
                var fields = content.Split(',');

                if(fields[1] == "N/D") {
                    chatMessage.Message = $"{fields[0].ToUpper()} was not found. Did you spelled correcly the stock's name?";
                    return chatMessage;
                }

                var stockInfo = new StockInfo() {
                    Symbol = fields[0].ToUpper(),
                    Open = decimal.Parse(fields[3], new CultureInfo("en-US"))
                };

                chatMessage.Message = $"{stockInfo.Symbol} quote is ${stockInfo.Open.ToString("0.00", CultureInfo.InvariantCulture)} per share";
                return chatMessage;
            } catch(FormatException ex) {
                chatMessage.Message = "Internal server error.";
                return chatMessage;
            } catch(HttpRequestException) {
                chatMessage.Message = "Could not connect to stooq.com. Please try again later.";;
                return chatMessage;
            }
        }

        private async Task<Stream> RequestStooqAsync(string stockName) {
            var client = new HttpClient();
            var stream = await client.GetStreamAsync($"https://stooq.com/q/l/?s={stockName}&f=sd2t2ohlcv&h&e=csv");
            return stream;
        }

    }
}
