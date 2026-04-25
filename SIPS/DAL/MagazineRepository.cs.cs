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
                using (var conn = new DatabaseManager().GetConnection())
                {
                    conn.Open();
                    // Use the exact lowercase name from your pgAdmin
                    string query = "SELECT magazineid, title, category, price, stock FROM magazines";
                    using (var adapter = new NpgsqlDataAdapter(query, conn))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Repo Error: " + ex.Message);
            }
            return dt;
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


        public bool UpdateMagazine(int id, string title, string category, decimal price, int stock)
        {
            try
            {
                using (NpgsqlConnection conn = dbManager.GetConnection())
                {
                    conn.Open();
                    // LAYER 2: Parameterized Query (Prevents SQL Injection during updates)
                    string query = "UPDATE magazines SET title=@t, category=@c, price=@p, stock=@s WHERE magazineid=@id";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@t", title.Trim());
                        cmd.Parameters.AddWithValue("@c", category.Trim());
                        cmd.Parameters.AddWithValue("@p", price);
                        cmd.Parameters.AddWithValue("@s", stock);
                        cmd.Parameters.AddWithValue("@id", id);

                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch { return false; }
        }
    }
}