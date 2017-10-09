using Dapper;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace Business
{
    public class ConnectionStrings
    {
        private static readonly Lazy<string> _defaultDb = new Lazy<string>(() => "retsgsdhah");

        public static string DefaultDB => _defaultDb.Value;

        //public ConnectionStrings(IConfigurationRoot configuration)
        //{
        //    DefaultDB = configuration["ConnectionStrings:DefaultConnection"];
        //}
    }
}
