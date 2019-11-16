using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vy.Faq.Models;

namespace Vy.Faq.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaqsController : ControllerBase
    {
        private readonly VyContext _vyContext;

        public FaqsController(VyContext vyContext)
        {
            _vyContext = vyContext;
        }

        // GET: api/Faqs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Faq>>> GetFaqItems()
        {
            return await _vyContext.Faqs.ToListAsync();
        }

        // GET: api/Faqs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Faq>> GetFaq(int id)
        {
            var faq = await _vyContext.Faqs.FindAsync(id);

            if (faq == null)
            {
                return NotFound();
            }

            return faq;
        }

        // PUT: api/Faqs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFaq(int id, Models.Faq faq)
        {
            if (id != faq.Id)
            {
                return BadRequest();
            }

            _vyContext.Entry(faq).State = EntityState.Modified;

            try
            {
                await _vyContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FaqExists(id))
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

        // POST: api/Faqs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Models.Faq>> PostFaq(Models.Faq faq)
        {
            _vyContext.Faqs.Add(faq);
            await _vyContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFaq), new { id = faq.Id }, faq);
        }

        private bool FaqExists(int id)
        {
            return _vyContext.Faqs.Any(e => e.Id == id);
        }
    }
}
