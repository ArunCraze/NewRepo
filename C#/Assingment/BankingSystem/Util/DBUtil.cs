﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace BankingSystem.Util
{
    public class DBUtil
    {
        private static string connectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=HMbank;Integrated Security=True;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}