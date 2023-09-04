using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Question.Concerns.Entities;
using Question.Contract;

namespace Question.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class subquestionController : ControllerBase
    {
        public readonly ISubQuestionService subquestion;
        public subquestionController(ISubQuestionService _question)
        {
            this.subquestion = _question;
        }
        [HttpGet]
        [ActionName("getall")]
        public async Task<IEnumerable<SubQuestions>> GetAll()
        {
            return await subquestion.GetAll();
        }
        [HttpGet("getbyid")]
        public async Task<IEnumerable<SubQuestions>> GetQuestionById(int id)
        {
            return await subquestion.GetSubQuesById(id);
        }
        [HttpPost("addsubques")]
        public void AddSubQuest(SubQuestions subQues)
        {
            subquestion.AddSubquestions(subQues);
        }
        [HttpPut("updatesubques")]
        public void UpdateAddSubquest(SubQuestions subQues)
        {
            subquestion.updateSubQues(subQues);
        }
        [HttpDelete("deletesubques")]
        public Task DeleteSubQuestionDetail(int id)
        {
            return subquestion.DeleteQuestionDetailsById(id);
        }
        [HttpDelete("DeleteById")]
        public void DeleteById(int id)
        {
            subquestion.DeleteById(id);
        }
    }
}
