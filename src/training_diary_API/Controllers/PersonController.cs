﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using training_diary_API.DTOs;
using training_diary_API.Models;

namespace training_diary_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private training_diary_dbContext _context;

        // Typed lambda expression for Select() method. 
        private static readonly Expression<Func<Person, PersonDto>> AsPersonDto =
            x => new PersonDto
            {
                IdPerson = x.IdPerson,
                UserName = x.UserName,
                Email = x.Email,
            };

        public PersonController(training_diary_dbContext context)
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
