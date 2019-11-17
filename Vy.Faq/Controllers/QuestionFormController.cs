using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vy.Faq.Models;

namespace Vy.Faq.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionFormController : ControllerBase
    {
        private readonly VyContext _vyContext;

        public QuestionFormController(VyContext vyContext)
        {
            _vyContext = vyContext;
        }
        
        // POST: api/Faqs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<QuestionForm>> PostContact(QuestionForm questionForm)
        {
            _vyContext.QuestionForms.Add(questionForm);
            await _vyContext.SaveChangesAsync();
            return Ok();
        }

    }
}
