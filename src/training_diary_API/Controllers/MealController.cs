using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using trainingDiaryBackend.Dto;
using trainingDiaryBackend.Models;

namespace trainingDiaryBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MealController : ControllerBase
    {
        private tddbContext _context;

        // Typed lambda expression for Select() method. 
        private static readonly Expression<Func<Meal, MealDto>> AsMealDto =
            x => new MealDto
            {
                MealName = x.MealName,
                MealDescription = x.MealDescription,
                Calories = x.Calories
            };

        public MealController(tddbContext context)
        {
            _context = context;
        }

        // GET: api/Meal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<MealDto>>> Get(int id)
        {
            List<MealDto> mealDtos;

            try
            {
                mealDtos = await _context.Meal
                    .Where(m => m.IdPerson == id)
                    .Select(AsMealDto)
                    .ToListAsync()
                    .ConfigureAwait(true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            if (mealDtos.Count < 0)
            {
                return NotFound();
            }

            return Ok(mealDtos);
        }

        // POST: api/Meal
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Meal/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
