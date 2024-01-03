using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Question.Concerns.DataContext
{
    public class QuestionContext
    {
        private readonly IConfiguration configuration;
        private readonly string connStr;
        public QuestionContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            connStr = this.configuration.GetConnectionString("DbConnection");
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(connStr);
    }
}
