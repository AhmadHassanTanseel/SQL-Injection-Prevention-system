using System;
using System.Data;
using Npgsql;

namespace SIPS.DAL
{
    public class MagazineRepository
    {
        // Bring in our Database Manager
        private DatabaseManager dbManager = new DatabaseManager();

        // 1. FOR THE ADMIN: Add a new magazine to inventory
        public bool AddMagazine(string title, string category, decimal price, int stock)
        {
            try
            {
                using (NpgsqlConnection conn = dbManager.GetConnection())
                {
                    conn.Open();
                    // Notice: Perfectly matches our schema columns!
                    string query = "INSERT INTO Magazines (Title, Category, Price, Stock) " +
                                   "VALUES (@title, @category, @price, @stock)";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@title", title);
                        cmd.Parameters.AddWithValue("@category", category);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@stock", stock);

                        cmd.ExecuteNonQuery();
                        return true; // Success!
                    }
                }
            }
            catch
            {
                return false; // Database error
            }
        }

        // 2. FOR EVERYONE: Get all magazines to show in the DataGridView
        public DataTable GetAllMagazines()
        {
            DataTable dt = new DataTable();
            try
            {
                using (NpgsqlConnection conn = dbManager.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM Magazines";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                        {
                            // This fills a nice, clean table format that your UI Grid can easily read
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception)
            {
                // If it fails, it returns an empty table so your app doesn't crash
            }
            return dt;
        }
    }
}