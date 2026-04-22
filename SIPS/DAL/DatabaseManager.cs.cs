using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace SIPS.DAL
{
        public class DatabaseManager
        {
            // 1. Your secret connection string lives ONLY here
            private readonly string connString = "Host=localhost;Port=5432;Username=postgres;Password=1234;Database=sips";

            // 2. This method hands out a secure connection whenever the app asks for it
            public NpgsqlConnection GetConnection()
            {
                return new NpgsqlConnection(connString);
            }
        }
}
