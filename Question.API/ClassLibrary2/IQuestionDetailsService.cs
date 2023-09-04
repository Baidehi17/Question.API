using Question.Concerns.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question.Contract
{
    public interface IQuestionDetailsService
    {
        Task<IEnumerable<QuestionDetails>> GetAll();
        Task<QuestionDetails> GetQuestionDetailsById(int id);
        public int AddQuestionDetails(QuestionDetails data);
        public void UpdateQuestionDetails(QuestionDetails user);
        public void DeleteById(int id);
    }
}
