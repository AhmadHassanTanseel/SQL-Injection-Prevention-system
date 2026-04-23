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
                    // Layer 2: Parameterized Query (Secure)
                    string query = "INSERT INTO Magazines (Title, Category, Price, Stock) " +
                                   "VALUES (@title, @category, @price, @stock)";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        // Layer 1: Sanitization (Added .Trim() for extra safety)
                        cmd.Parameters.AddWithValue("@title", title.Trim());
                        cmd.Parameters.AddWithValue("@category", category.Trim());
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@stock", stock);

                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch
            {
                return false;
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


    public bool DeleteMagazine(int magazineId)
        {
            try
            {
                using (NpgsqlConnection conn = dbManager.GetConnection())
                {
                    conn.Open();
                    // LAYER 2: Parameterized Query
                    string query = "DELETE FROM magazines WHERE magazineid = @id";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", magazineId);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Silently fail or log as we discussed for security
                return false;
            }
        }
    }
}