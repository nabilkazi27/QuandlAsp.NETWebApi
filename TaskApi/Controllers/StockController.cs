using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskApi.Models;
using Microsoft.EntityFrameworkCore;
using EFCore.BulkExtensions;

namespace TaskApi.Controllers
{
    [ApiController]
    [Route("/api/{[controller]}")]
    public class StockController : ControllerBase
    {
        private readonly MyDBContext _context;

        public StockController(MyDBContext db)
        {
            _context = db;
        }

        [HttpGet]
        public async Task<IEnumerable<Stock>> GetStocks()
        {
            var stocks = await _context.Stocks.ToListAsync();

            if (stocks == null)
            {
                return null;
            }

            return stocks;
        }

        [HttpGet("{stockDate}")]
        public async Task<ActionResult<Stock>> GetStock(string stockDate)
        {
            var stock = await _context.Stocks.FindAsync(stockDate);

            if (stock == null)
            {
                return NotFound();
            }

            return stock;
        }

        [HttpPost]
        public async Task<ActionResult<Stock>> CreateTodoItems([FromBody]List<Stock> stocks)
        {

            foreach(var stock in stocks)
            {
                var stockInDb = _context.Stocks
                    .SingleOrDefault(c => c.StockDate == stock.StockDate);
                if (stockInDb != null) 
                    _context.Entry(stockInDb).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                else
                   await _context.Stocks.AddAsync(stock);
            }

            await _context.SaveChangesAsync(); 

            return new JsonResult(stocks);
        }
    }
}
