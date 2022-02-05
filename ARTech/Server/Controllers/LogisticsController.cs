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
    public class LogisticsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public LogisticsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Logistics
        [HttpGet]
        public async Task<IActionResult> GetLogistics()
        {
            var logistics = await _unitOfWork.Logistics.GetAll();
            return Ok(logistics);
        }

        // GET: api/Logistics/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLogistic(int id)
        {
            var logistic = await _unitOfWork.Logistics.Get(q => q.LogisticId == id);

            if (logistic == null)
            {
                return NotFound();
            }

            return Ok(logistic);
        }

        // PUT: api/Logistics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogistic(int id, Logistic logistic)
        {
            if (id != logistic.LogisticId)
            {
                return BadRequest();
            }

            _unitOfWork.Logistics.Update(logistic);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await LogisticExists(id))
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

        // POST: api/Logistics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Logistic>> PostLogistic(Logistic logistic)
        {
            await _unitOfWork.Logistics.Insert(logistic);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetLogistic", new { id = logistic.LogisticId }, logistic);
        }

        // DELETE: api/Logistics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogistic(int id)
        {
            var logistic = await _unitOfWork.Logistics.Get(q => q.LogisticId == id);
            if (logistic == null)
            {
                return NotFound();
            }

            await _unitOfWork.Logistics.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> LogisticExists(int id)
        {
            var logistic = await _unitOfWork.Logistics.Get(q => q.LogisticId == id);
            return logistic != null;
        }
    }
}