using DataLayer.DAOs;
using DataLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerDAO customerDAO = new CustomerDAO();
            var result = customerDAO.Read();


            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();

        }
    }
}

