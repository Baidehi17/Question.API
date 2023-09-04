using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Question.Concerns.Entities;
using Question.Contract;

namespace Question.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class questionController : ControllerBase
    {
        public readonly IQuestionDetailsService question;
        public questionController(IQuestionDetailsService _question)
        {
            this.question = _question;
        }
        
        [HttpGet("getall")]
        public async Task<IEnumerable<QuestionDetails>> GetAll()
        {
            return await question.GetAll();
        }
        [HttpGet("getbyid")]
        public async Task<QuestionDetails> GetQuestionById(int id)
        {
            return await question.GetQuestionDetailsById(id);
        }
        [HttpPost("addquestion")]
        public int AddQuestion(QuestionDetails questionDetail)
        {
            return question.AddQuestionDetails(questionDetail);
        }
        [HttpPut("updatequestion")]
        public void Updatesubquestion(QuestionDetails questionDetails)
        {
            question.UpdateQuestionDetails(questionDetails);
        }
        [HttpDelete("deletebyid")]
        public void DeleteQuestion(int id)
        {
            question.DeleteById(id);
        }
    }
}
