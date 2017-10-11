using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Business;
using Dapper;
using MyBusiness.Domain;

namespace MyBusiness.Helpers
{
    public static class UserHelper
    {
        private static readonly string ConnectionString = ConnectionStrings.DefaultDB;

        public static IEnumerable<User> ReadAll()
        {
            var sqlStatement = "SELECT * FROM [User]";

            var connection = new SqlConnection(ConnectionString);
            return connection.Query<User>(sqlStatement);
        }

        public static bool Insert(User user)
        {
            var parameters = new DynamicParameters();
            var sqlStatement = "INSERT INTO [User] VALUES (@Login, @Password, @FirstName, @LastName, @Email, @Mobile, @Address, @Country) ";

            parameters.Add("@Login", user.Login);
            parameters.Add("@Password", user.Password.Hash());
            parameters.Add("@FirstName", user.FirstName);
            parameters.Add("@LastName", user.LastName);
            parameters.Add("@Email", user.Email);
            parameters.Add("@Mobile", user.Mobile);
            parameters.Add("@Address", user.Address);
            parameters.Add("@Country", user.Country);

            var connection = new SqlConnection(ConnectionString);
            try
            {
                var result = connection.Execute(sqlStatement, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                //write error in logs with ex message
                return false;
            }
        }

        public static string Hash(this string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            var hashBytes = System.Security.Cryptography.MD5.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
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
