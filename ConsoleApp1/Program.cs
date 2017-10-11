using Business;
using System;
using MyBusiness.Domain;
using MyBusiness.Helpers;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var newUser = new User
            {
                Login = "alice",
                Password = "testpass",
                FirstName = "Aliki",
                LastName = "Pialogou",
                Email = "aliki@hotmail.com",
                Mobile = "6976485968",
                Address = "Viktor Ougko 13, Chania",
                Country = "Greece"
            };
            var instertresult = UserHelper.Insert(newUser);

            var allUsers = UserHelper.ReadAll();

        }
    }
}
