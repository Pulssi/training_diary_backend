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
    public class GymSetController : ControllerBase
    {
        private tddbContext _context;

        // Typed lambda expression for Select() method. 
        private static readonly Expression<Func<GymSet, GymSetDto>> AsGymSetDto =
            x => new GymSetDto
            {
                IdGymMove = x.IdGymMove,
                IdGymSet = x.IdGymSet,
                IdPerson = x.IdPerson,
                Repetitions = x.Repetitions,
                SetWeight = x.SetWeight,
                Timestamp = x.Timestamp,
                GymMoveNavigation = x.IdGymMoveNavigation
            };

        public GymSetController(tddbContext context)
        {
            _context = context;
        }

        /// <summary>Returns all the gym sets found that has the specified user ID.</summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<List<GymSetDto>>> Get(int id)
        {
            List<GymSetDto> gymSetDtos;

            try
            {
                gymSetDtos = await _context.GymSet
                    .Where(g => g.IdPerson == id)
                    .Include(g => g.IdGymMoveNavigation)
                    .Select(AsGymSetDto)
                    .ToListAsync()
                    .ConfigureAwait(true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            if (gymSetDtos.Count < 0)
            {
                return NotFound();
            }

            return Ok(gymSetDtos);
        }

    }
}
