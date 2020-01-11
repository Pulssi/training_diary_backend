using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using training_diary_API.Models;

namespace training_diary_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeightController : ControllerBase
    {
        private training_diary_dbContext _context;
        private PersonController personController;

        public WeightController(training_diary_dbContext context)
        {
            _context = context;
            personController = new PersonController(context);
        }

        [HttpGet("{email}")]
        public async Task<IEnumerable<Weight>> Get(string email)
        {
            IEnumerable<Weight> weights;

            try
            {
                Person person = await personController.Get(email);
                weights = await _context.Weight
                    .Where(weight => weight.IdPerson == person.IdPerson)
                    .ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return weights;
        }

        [HttpPost]
        public async void Post([FromBody] Weight weight)
        {
            try
            {
                _context.Add(weight);
                await _context.SaveChangesAsync();
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
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
