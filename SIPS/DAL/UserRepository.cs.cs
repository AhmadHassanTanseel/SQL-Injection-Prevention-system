using Npgsql;
using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace SIPS.DAL
{
    public class UserRepository
    {
        // Bring in the Database Manager we just built
        private DatabaseManager dbManager = new DatabaseManager();

        // 1. THE HASH MACHINE (Hidden safely in the backend)
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // 2. THE REGISTRATION METHOD
        public bool RegisterUser(string name, string email, string password, string address, string signature)
        {
            try
            {
                using (NpgsqlConnection conn = dbManager.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO users (Name, Email, Password, Address, Signature, Role) " +
                                   "VALUES (@name, @email, @pass, @address, @signature, 'Customer')";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@pass", HashPassword(password)); // Scrambles before saving!
                        cmd.Parameters.AddWithValue("@address", address);
                        cmd.Parameters.AddWithValue("@signature", signature);

                        cmd.ExecuteNonQuery();
                        return true; // Success!
                    }
                }
            }
            //catch
            //{
            //    return false; // Failed (e.g., email already exists)
            //}
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("REAL DB ERROR: " + ex.Message);
                return false;
            }
        }

        // 3. THE LOGIN METHOD
        public string AuthenticateUser(string email, string password)
        {
            // DEBUG: Let's see what password we are trying to check
            string hashedAttempt = HashPassword(password);
           // System.Windows.Forms.MessageBox.Show("DEBUG: Hashed Login Attempt: " + hashedAttempt);

            try
            {
                using (NpgsqlConnection conn = dbManager.GetConnection())
                {
                    conn.Open();
                    // The LOWER(email) part tells the database to ignore capital letters!
                    string query = "SELECT role FROM users WHERE LOWER(email) = @email AND password = @pass";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@email", email.Trim().ToLower());
                        cmd.Parameters.AddWithValue("@pass", hashedAttempt);

                        object result = cmd.ExecuteScalar();
                        return result != null ? result.ToString() : null;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("DB ERROR: " + ex.Message);


                return null;
            }
        }

        public DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();
            try
            {
                using (NpgsqlConnection conn = dbManager.GetConnection())
                {
                    conn.Open();
                    // FIX: Changed 'username' to 'name' to match your pgAdmin screenshot
                    string query = "SELECT name AS Name, email AS Email, role AS Role, signature AS Signature FROM users ORDER BY name ASC";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // For debugging purposes
                Console.WriteLine("User Load Error: " + ex.Message);
            }
            return dt;
        }

        // 1. ADD USER
        public bool AddUser(string name, string email, string password, string role, string signature)
        {
            try
            {
                using (NpgsqlConnection conn = dbManager.GetConnection())
                {
                    conn.Open();
                    // Layer 2: Parameterized (Security)
                    string query = "INSERT INTO users (username, email, password, role, signature) VALUES (@n, @e, @p, @r, @s)";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@n", name.Trim());
                        cmd.Parameters.AddWithValue("@e", email.Trim());
                        cmd.Parameters.AddWithValue("@p", password); // Should be hashed in Layer 3
                        cmd.Parameters.AddWithValue("@r", role);
                        cmd.Parameters.AddWithValue("@s", signature);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch { return false; }
        }

        // 2. UPDATE USER
        public bool UpdateUser(string originalEmail, string newName, string newRole)
        {
            try
            {
                using (NpgsqlConnection conn = dbManager.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE users SET username=@n, role=@r WHERE email=@e";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@n", newName.Trim());
                        cmd.Parameters.AddWithValue("@r", newRole);
                        cmd.Parameters.AddWithValue("@e", originalEmail);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch { return false; }
        }

        // 3. DELETE USER
        public bool DeleteUser(string email)
        {
            try
            {
                using (NpgsqlConnection conn = dbManager.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM users WHERE email=@e";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@e", email);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch { return false; }
        }
    }
}