using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rflap_metrics.Models;

namespace rflap_metrics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestResultController : ControllerBase
    {
        private readonly TestResultContext _context;

        public TestResultController(TestResultContext context)
        {
            _context = context;
        }

        // GET: api/TestResult
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestResult>>> GetTestResult()
        {
            return await _context.TestResult.ToListAsync();
        }

        // GET: api/TestResult/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestResult>> GetTestResult(string id)
        {
            var testResult = await _context.TestResult.FindAsync(id);

            if (testResult == null)
            {
                return NotFound();
            }

            return testResult;
        }

        // PUT: api/TestResult/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestResult(string id, TestResult testResult)
        {
            if (id != testResult.dataID)
            {
                return BadRequest();
            }

            _context.Entry(testResult).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestResultExists(id))
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

        // POST: api/TestResult
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TestResult>> PostTestResult(TestResult testResult)
        {
            _context.TestResult.Add(testResult);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TestResultExists(testResult.dataID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTestResult", new { id = testResult.dataID }, testResult);
        }

        // DELETE: api/TestResult/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TestResult>> DeleteTestResult(string id)
        {
            var testResult = await _context.TestResult.FindAsync(id);
            if (testResult == null)
            {
                return NotFound();
            }

            _context.TestResult.Remove(testResult);
            await _context.SaveChangesAsync();

            return testResult;
        }

        private bool TestResultExists(string id)
        {
            return _context.TestResult.Any(e => e.dataID == id);
        }
    }
}
