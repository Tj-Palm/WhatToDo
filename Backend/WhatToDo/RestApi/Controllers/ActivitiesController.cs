using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestApi.Models;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly InMemoryDbContext _context;

        public ActivitiesController(InMemoryDbContext context)
        {
            _context = context;
            AddActivities();

        }

        private async void AddActivities()
        {
            if (_context.ActivityItems.Count() == 0)
            {
                _context.ActivityItems.Add(new Activity("Lawn moving", 40, "Work", "Outdoor"));
                await _context.SaveChangesAsync();
                _context.ActivityItems.Add(new Activity("Read a book", 60, "SpareTime", "Indoor"));
                await _context.SaveChangesAsync();
                _context.ActivityItems.Add(new Activity("Enjoy the sun", 40, "SpareTime", "Outdoor"));
                await _context.SaveChangesAsync();
                _context.ActivityItems.Add(new Activity("Put clothes in closet", 20, "Work", "Indoor"));
                await _context.SaveChangesAsync();
                _context.ActivityItems.Add(new Activity("Dry dust", 20, "Work", "Indoor"));
                await _context.SaveChangesAsync();
                _context.ActivityItems.Add(new Activity("Watering flowers", 10, "SpareTime", "Outdoor"));
                await _context.SaveChangesAsync();
                _context.ActivityItems.Add(new Activity("Watch TV", 40, "SpareTime", "Indoor"));
                await _context.SaveChangesAsync();
                _context.ActivityItems.Add(new Activity("Washing clothes", 60, "Work", "Indoor"));
                await _context.SaveChangesAsync();
                
            }

        }

        // GET: api/Activities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Activity>>> GetActivityItems()
        {
            return await _context.ActivityItems.ToListAsync();
        }

        // GET: api/Activities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(int id)
        {
            var activity = await _context.ActivityItems.FindAsync(id);

            if (activity == null)
            {
                return NotFound();
            }

            return activity;
        }

        // GET: api/Activities/random
        [HttpGet]
        [Route("random")]
        public async Task<ActionResult<Activity>> GetRandomActivityAsync(
            [FromQuery] ActivityParameter activityParameter)
        {
            var activities = await GetActivityItems();
            List<Activity> activitesFromParameter = new List<Activity>();

            if (activityParameter != null)
            {
                foreach (var activity in activities.Value)
                {

                    bool addActivity = true;


                    if (activityParameter.ActivityLevel != activity.ActivityLevel)
                    {
                        addActivity = false;
                    }

                    if (activityParameter.Environment != activity.Environment ) 
                    {
                        addActivity = false;
                    }
                    
                    if (activityParameter.TimeInterval < activity.TimeInterval)
                    {
                        addActivity = false;
                    }
                    if (addActivity)
                    {
                        activitesFromParameter.Add(activity);
                        
                    }
                }
            }

            if (activitesFromParameter.Count == 0)
            {
                return NotFound();
            }

            var r = new Random();
            var inx = r.Next(0, activitesFromParameter.Count - 1);
            return activitesFromParameter[inx];
        }

        // PUT: api/Activities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivity(int id, Activity activity)
        {
            if (id != activity.id)
            {
                return BadRequest();
            }

            _context.Entry(activity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityExists(id))
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

        // POST: api/Activities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Activity>> PostActivity(Activity activity)
        {
            _context.ActivityItems.Add(activity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActivity", new {id = activity.id}, activity);
        }

        // DELETE: api/Activities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Activity>> DeleteActivity(int id)
        {
            var activity = await _context.ActivityItems.FindAsync(id);
            if (activity == null)
            {
                return NotFound();
            }

            _context.ActivityItems.Remove(activity);
            await _context.SaveChangesAsync();

            return activity;
        }

        private bool ActivityExists(int id)
        {
            return _context.ActivityItems.Any(e => e.id == id);
        }
    }
}
