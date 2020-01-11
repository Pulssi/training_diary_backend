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
    public class PersonController : ControllerBase
    {
        private training_diary_dbContext _context;

        public PersonController(training_diary_dbContext context)
        {
            _context = context;
        }

        [HttpGet("{email}")]
        public async Task<Person> Get(string email)
        {
            Person person;

            try
            {
                person = await _context.Person
                    .Where(person => person.Email == email)
                    .FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return person;
        }

        [HttpPost]
        public async void Post([FromBody] Person personData)
        {
            try
            {
                _context.Person.Add(personData);
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
            Person person = new Person();
            person.IdPerson = id;

            try
            {
                _context.Person.Remove(person);
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
