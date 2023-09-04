using Question.Concerns.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question.Contract
{
    public interface ISubQuestionService
    {
        Task<IEnumerable<SubQuestions>> GetAll();

        Task<IEnumerable<SubQuestions>> GetSubQuesById(int id);
        public void AddSubquestions(SubQuestions data);
        public void updateSubQues(SubQuestions subQuest);
        public Task DeleteQuestionDetailsById(int id);
        public void DeleteById(int id);
    }
}
