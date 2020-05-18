using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi.Models;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensordataController : ControllerBase
    {
        private readonly InMemoryDbContext _context;

        public SensordataController(InMemoryDbContext context)
        {
            _context = context;
            AddSensorData();
        }

        private async void AddSensorData()
        {
            if(_context.Sensordatas.Count() == 0)
            {
                _context.Sensordatas.Add(new SensorData()
                    {GrassLengt = 5, Id = 1, Time = new DateTime(2020, 1, 12, 14, 30, 57)});
                await _context.SaveChangesAsync();
            }
        }


        // GET: api/Sensordata
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SensorData>>> Get()
        {
            return await _context.Sensordatas.ToListAsync();
        }

        // GET: api/Sensordata/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SensorData>> GetSensorData(int id)
        {
            var data = await _context.Sensordatas.FindAsync(id);

            if (data == null)
            {
                return NotFound();
            }

            return data;
        }

        [HttpGet("last")]
        public async Task<ActionResult<SensorData>> GetLast()
        {
            if (_context.Sensordatas.Count() == 0)
            {
                return NotFound();
            }
            return await _context.Sensordatas.LastAsync();

        }

        // POST: api/Sensordata
        [HttpPost]
        public async Task<ActionResult<SensorData>> PostData(SensorData data)
        {
            _context.Sensordatas.Add(data);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSensorData", new { id = new SensorData().Id }, data);
        }
    }
}
