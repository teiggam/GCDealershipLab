using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GC_Car_Dealership.Models;

namespace GC_Car_Dealership.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CarsDBContext _context;

        public CarsController(CarsDBContext context)
        {
            _context = context;
        }

        // GET: api/Cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            return await _context.Cars.ToListAsync();
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCarID(int id)
        {
            var car = await _context.Cars.FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

        [HttpGet("Search/{searchType}={input}")]
        public async Task<ActionResult<IEnumerable<Car>>> SearchFor(string searchType, string input)
        {
            if (searchType.ToLower() == "make")
            {
                int results = _context.Cars.Count(x => x.Make.ToLower().Contains(input));
                if (results < 1)
                {
                    return NotFound();
                }
                return await _context.Cars.Where(x => x.Make.ToLower().Contains(input.ToLower())).ToListAsync();
            }

            else if (searchType.ToLower() == "model")
            {
                int results = _context.Cars.Count(x => x.Model.ToLower().Contains(input));
                if (results < 1)
                {
                    return NotFound();
                }
                return await _context.Cars.Where(x => x.Model.ToLower().Contains(input.ToLower())).ToListAsync();
            
            }
            else if (searchType.ToLower() == "year")
            {
                int year = int.Parse(input);
                int results = _context.Cars.Count(x => x.Year == year);
                if (results < 1)
                {
                    return NotFound();
                }
                return await _context.Cars.Where(x => x.Year == year).ToListAsync();
                
            }
            else if (searchType.ToLower() == "color")
            {
                int results = _context.Cars.Count(x => x.Color.ToLower().Contains(input));
                if (results < 1)
                {
                    return NotFound();
                }

                return await _context.Cars.Where(x => x.Color.ToLower().Contains(input.ToLower())).ToListAsync();
              
            }
            else if (searchType.ToLower() == "transmission")
            {
                int results = _context.Cars.Count(x => x.Transmission.ToLower().Contains(input));
                if (results < 1)
                {
                    return NotFound();
                }
                return await _context.Cars.Where(x => x.Transmission.ToLower().Contains(input.ToLower())).ToListAsync();
                
            }
            else
            {
                List<Car> noCarList = new List<Car>();
                Car noCar = new Car();
                noCar.Make = "No car found.";
                noCarList.Add(noCar);

                return noCarList;
            }
        }

        // PUT: api/Cars/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, Car car)
        {
            if (id != car.Id)
            {
                return BadRequest();
            }

            _context.Entry(car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(id))
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

        // POST: api/Cars
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Car>> PostCar(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCar", new { id = car.Id }, car);
        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Car>> DeleteCar(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();

            return car;
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.Id == id);
        }


    }
}
