using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ARTech.Server.Data;
using ARTech.Shared.Domain;
using ARTech.Server.IRepository;

namespace ARTech.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderSummarysController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderSummarysController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/OrderSummarys
        [HttpGet]
        public async Task<IActionResult> GetOrderSummarys()
        {
            var logistics = await _unitOfWork.OrderSummarys.GetAll(includes: q => q.Include(x => x.Customer).Include(x => x.Logistic).Include(x => x.Staff));
            return Ok(logistics);
        }

        // GET: api/OrderSummarys/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderSummary(int id)
        {
            var ordersummary = await _unitOfWork.OrderSummarys.Get(q => q.OrderSummaryId == id);

            if (ordersummary == null)
            {
                return NotFound();
            }

            return Ok(ordersummary);
        }

        // PUT: api/OrderSummarys/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderSummary(int id, OrderSummary ordersummary)
        {
            if (id != ordersummary.OrderSummaryId)
            {
                return BadRequest();
            }

            _unitOfWork.OrderSummarys.Update(ordersummary);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await OrderSummaryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/OrderSummarys
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderSummary>> PostOrderSummary(OrderSummary ordersummary)
        {
            await _unitOfWork.OrderSummarys.Insert(ordersummary);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetOrderSummary", new { id = ordersummary.OrderSummaryId }, ordersummary);
        }

        // DELETE: api/OrderSummarys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderSummary(int id)
        {
            var ordersummary = await _unitOfWork.OrderSummarys.Get(q => q.OrderSummaryId == id);
            if (ordersummary == null)
            {
                return NotFound();
            }

            await _unitOfWork.OrderSummarys.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> OrderSummaryExists(int id)
        {
            var ordersummary = await _unitOfWork.OrderSummarys.Get(q => q.OrderSummaryId == id);
            return ordersummary != null;
        }
    }
}