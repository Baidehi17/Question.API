using Dapper;
using Question.Concerns.DataContext;
using Question.Concerns.Entities;
using Question.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question.Service
{
    public class SubQuestionService : ISubQuestionService
    {
        public readonly QuestionContext context;
        public SubQuestionService(QuestionContext _context)
        {
            this.context = _context;
        }
        public async Task<IEnumerable<SubQuestions>> GetAll()
        {
            string query = "select * from subQuestions";
            using (var connection = this.context.CreateConnection())
            {
                var quelist = await connection.QueryAsync<SubQuestions>(query);
                return quelist;
            }
        }

        public async Task<IEnumerable<SubQuestions>> GetSubQuesById(int id)
        {
            string query = "SELECT * FROM subQuestions WHERE questionDetails_id = @id;";

            using (var connection = this.context.CreateConnection())
            {
                IEnumerable<SubQuestions> subQuestionsList = await connection.QueryAsync<SubQuestions>(query, new { id });
                return subQuestionsList;
            }
        }

        public void updateSubQues(SubQuestions subQuest)
        {
            string query = "UPDATE subQuestions SET subQuestionName = @subQuestionName,numberOfQuestion = @numberOfQuestion, timeLimit = @timeLimit,questionDetails_id = @questionDetails_id WHERE id = @Id;";

            using (var connection = this.context.CreateConnection())
            {
                connection.Execute(query, subQuest);
            }
        }

        public void AddSubquestions(SubQuestions data)
        {
            string query = "INSERT INTO subQuestions (subQuestionName, numberOfQuestion, timeLimit, questionDetails_id) VALUES (@subQuestionName, @numberOfQuestion, @timeLimit, @questionDetails_id);";

            using (var connection = this.context.CreateConnection())
            {
                 connection.Execute(query, data);
            }
        }

        public void DeleteById(int id)
        {
            string query = "Delete From subQuestions where(id=@id)";
            using (var connectin = this.context.CreateConnection())
            {
                connectin.Execute(query, new { id });
            }
        }

        public async Task DeleteQuestionDetailsById(int id)
        {
            string query = "Delete From subQuestions where(questionDetails_id=@id)";
            using (var connectin = this.context.CreateConnection())
            {
               await connectin.ExecuteAsync(query, new { id });
            }
        }
    }
}
