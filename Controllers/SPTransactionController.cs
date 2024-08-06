using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using TodoApi.Services;
using Microsoft.AspNetCore.Cors;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SPTransactionController : ControllerBase
    {
        private readonly TodoContext _context;

        public SPTransactionController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/SPTransaction
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SPTransaction>>> GetSPTransactions()
        {
            return await _context.SPTransactions.ToListAsync();
        }

        // GET: api/SPTransaction/ParseCSV
        [HttpGet("ParseCSV")]
        public async Task<ActionResult<IEnumerable<SPTransaction>>> ParseCSVSPTransactions()
        {
            var csvparser = new CsvParserService();
            return csvparser.ExecuteService();
        }

        // GET: api/SPTransaction/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SPTransaction>> GetSPTransaction(long id)
        {
            var sPTransaction = await _context.SPTransactions.FindAsync(id);

            if (sPTransaction == null)
            {
                return NotFound();
            }

            return sPTransaction;
        }

        // PUT: api/SPTransaction/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSPTransaction(long id, SPTransaction sPTransaction)
        {
            if (id != sPTransaction.Id)
            {
                return BadRequest();
            }

            _context.Entry(sPTransaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SPTransactionExists(id))
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

        // PUT: api/SPTransaction/ParseCSV/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("ParseCSV/{id}")]
        public async Task<IActionResult> PutParseCSVSPTransaction(long id)
        {
            var csvparser = new CsvParserService();
            var spTransactions = new List<SPTransaction>();
            spTransactions = csvparser.ExecuteService();

            if (id != spTransactions[0].Id)
            {
                return BadRequest();
            }

            _context.Entry(spTransactions[0]).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SPTransactionExists(id))
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

        // POST: api/SPTransaction
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SPTransaction>> PostSPTransaction(SPTransaction sPTransaction)
        {
            _context.SPTransactions.Add(sPTransaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSPTransaction", new { id = sPTransaction.Id }, sPTransaction);
        }

        // POST: api/SPTransaction/ParseCSV
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("ParseCSV")]
        public async Task<ActionResult<List<SPTransaction>>> PostParseCSVSPTransaction()
        {
            var csvparser = new CsvParserService();
            var spTransactions = new List<SPTransaction>();
            spTransactions = csvparser.ExecuteService();
            foreach (SPTransaction sptransaction in spTransactions)
            {
                _context.SPTransactions.Add(sptransaction);
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("GetSPTransactions", new List<SPTransaction>(), spTransactions);
        }

        // DELETE: api/SPTransaction/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSPTransaction(long id)
        {
            var sPTransaction = await _context.SPTransactions.FindAsync(id);
            if (sPTransaction == null)
            {
                return NotFound();
            }

            _context.SPTransactions.Remove(sPTransaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SPTransactionExists(long id)
        {
            return _context.SPTransactions.Any(e => e.Id == id);
        }
    }
}
