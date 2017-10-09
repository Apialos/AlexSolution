using Dapper;
using System.Data.SqlClient;
using System.Linq;

namespace Business
{
    public class FirstHelper
    {
        private static readonly string ConnectionString = ConnectionStrings.DefaultDB;

        public static void TestDatabase()
        {
            var sqlStatement = "SELECT * FROM [User]";

            var connection = new SqlConnection(ConnectionString);
            var result = connection.Query(sqlStatement);
        }


        public static int Add(int num1, int num2)
        {
            var sqlStatement = "SELECT * FROM [User]";

            var connection = new SqlConnection(ConnectionString);
            var result = connection.Query(sqlStatement);
           
            var parameters = new DynamicParameters();

            parameters.Add("@num1", num1);
            parameters.Add("@num2", num2);

            return num1 + num2;
        }
    }
}
