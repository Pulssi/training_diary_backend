using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using training_diary_API.Models;

namespace training_diary_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WeightController : ControllerBase
    {
        private training_diary_dbContext _context;

        public WeightController(training_diary_dbContext context)
        {
            _context = context;
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<IEnumerable<Weight>>> Get(string email)
        {
            IEnumerable<Weight> weights;

            try
            {
                weights = await _context.Weight
                    .Where(weight => weight.IdPersonNavigation.Email == email)
                    .ToListAsync()
                    .ConfigureAwait(true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return Ok(weights);
        }

        [HttpPost]
        public async void Post([FromBody] Weight weight)
        {
            try
            {
                _context.Add(weight);
                await _context.SaveChangesAsync().ConfigureAwait(true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            Weight weight = new Weight();
            weight.IdWeight = id;

            try
            {
                _context.Weight.Remove(weight);
                await _context.SaveChangesAsync().ConfigureAwait(true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
