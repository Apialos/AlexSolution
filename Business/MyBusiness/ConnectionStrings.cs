using Dapper;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace Business
{
    public class ConnectionStrings
    {
        private static readonly Lazy<string> _defaultDb = new Lazy<string>(() => "Data Source=alex-desktop\\sqlexpress; Initial Catalog=MyDatabase; User id=webappuser;Password=tester;");

        public static string DefaultDB => _defaultDb.Value;

        //public ConnectionStrings(IConfigurationRoot configuration)
        //{
        //    DefaultDB = configuration["ConnectionStrings:DefaultConnection"];
        //}
    }
}
