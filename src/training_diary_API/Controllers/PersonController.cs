using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using trainingDiaryBackend.Dto;
using trainingDiaryBackend.Models;
using Microsoft.AspNetCore.Authorization;

namespace trainingDiaryBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PersonController : ControllerBase
    {
        private tddbContext _context;

        // Typed lambda expression for Select() method. 
        private static readonly Expression<Func<Person, PersonDto>> AsPersonDto =
            x => new PersonDto
            {
                IdPerson = x.IdPerson,
                UserName = x.UserName,
                Email = x.Email,
            };

        public PersonController(tddbContext context)
        {
            _context = context;
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<PersonDto>> Get(string email)
        {
            PersonDto personDto;

            try
            {
                personDto = await _context.Person
                    .Where(person => person.Email == email)
                    .Select(AsPersonDto)
                    .FirstOrDefaultAsync()
                    .ConfigureAwait(true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            if(personDto == null)
            {
                return NotFound();
            }

            return Ok(personDto);
        }

        [HttpPost]
        public async void Post([FromBody] Person personData)
        {
            try
            {
                _context.Person.Add(personData);
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
            Person person = new Person();
            person.IdPerson = id;

            try
            {
                _context.Person.Remove(person);
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
