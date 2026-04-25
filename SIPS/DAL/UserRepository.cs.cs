using Npgsql;
using SIPS.Security;
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
        //public string AuthenticateUser(string email, string password)
        //{
        //    // DEBUG: Let's see what password we are trying to check
        //    string hashedAttempt = HashPassword(password);
        //   // System.Windows.Forms.MessageBox.Show("DEBUG: Hashed Login Attempt: " + hashedAttempt);

        //    try
        //    {
        //        using (NpgsqlConnection conn = dbManager.GetConnection())
        //        {
        //            conn.Open();
        //            // The LOWER(email) part tells the database to ignore capital letters!
        //            string query = "SELECT role FROM users WHERE LOWER(email) = @email AND password = @pass";

        //            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
        //            {
        //                cmd.Parameters.AddWithValue("@email", email.Trim().ToLower());
        //                cmd.Parameters.AddWithValue("@pass", hashedAttempt);

        //                object result = cmd.ExecuteScalar();
        //                return result != null ? result.ToString() : null;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show("DB ERROR: " + ex.Message);


        //        return null;
        //    }
        //}

        public DataTable AuthenticateUser(string email, string password)
        {
            try
            {
                // 1. Hash the password the user just typed
                string hashedInput = SecurityHelper.HashPassword(password);

                using (NpgsqlConnection conn = dbManager.GetConnection())
                {
                    conn.Open();
                    // 2. Look for the email AND the hashed password
                    // Make sure column names match your pgAdmin (email, password, role, userid)
                    string query = "SELECT userid, role FROM users WHERE email = @e AND password = @p";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@e", email);
                        cmd.Parameters.AddWithValue("@p", hashedInput);

                        NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt; // Returns the row if found, empty if not
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Auth Error: " + ex.Message);
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
                    //string query = "SELECT name AS Name, email AS Email, role AS Role, signature AS Signature FROM users ORDER BY name ASC";
                    // Make sure "address AS Address" is included!
                    string query = "SELECT name AS Name, email AS Email, role AS Role, address AS Address, signature AS Signature FROM users ORDER BY name ASC";

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
        //public bool AddUser(string name, string email, string password, string role, string signature)
        //{
        //    try
        //    {
        //        using (NpgsqlConnection conn = dbManager.GetConnection())
        //        {
        //            conn.Open();
        //            // Layer 2: Parameterized (Security)
        //            string query = "INSERT INTO users (username, email, password, role, signature) VALUES (@n, @e, @p, @r, @s)";
        //            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
        //            {
        //                cmd.Parameters.AddWithValue("@n", name.Trim());
        //                cmd.Parameters.AddWithValue("@e", email.Trim());
        //                cmd.Parameters.AddWithValue("@p", password); // Should be hashed in Layer 3
        //                cmd.Parameters.AddWithValue("@r", role);
        //                cmd.Parameters.AddWithValue("@s", signature);
        //                cmd.ExecuteNonQuery();
        //                return true;
        //            }
        //        }
        //    }
        //    catch { return false; }
        //}

        //public bool AddUser(string name, string email, string password, string role, string signature, string address)
        //{
        //    try
        //    {
        //        using (NpgsqlConnection conn = dbManager.GetConnection())
        //        {
        //            conn.Open();
        //            // Note: Use the column names exactly as they appear in your pgAdmin screenshot
        //            string query = "INSERT INTO users (name, email, password, role, signature, address) " +
        //                           "VALUES (@n, @e, @p, @r, @s, @a)";

        //            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
        //            {
        //                cmd.Parameters.AddWithValue("@n", name);
        //                cmd.Parameters.AddWithValue("@e", email);
        //                cmd.Parameters.AddWithValue("@p", password); // In a real app, this should be hashed!
        //                cmd.Parameters.AddWithValue("@r", role);
        //                cmd.Parameters.AddWithValue("@s", signature);
        //                cmd.Parameters.AddWithValue("@a", address);

        //                cmd.ExecuteNonQuery();
        //                return true;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // This helps you see the actual SQL error if it fails
        //        System.Windows.Forms.MessageBox.Show("Database Error: " + ex.Message);
        //        return false;
        //    }
        //}
        public bool AddUser(string name, string email, string password, string role, string signature, string address)
        {
            try
            {
                // 1. SECURITY UPGRADE: Scramble the password before it leaves this method
                // This ensures plain-text passwords are never stored in your database.
                string hashedPassword = SecurityHelper.HashPassword(password);

                using (NpgsqlConnection conn = dbManager.GetConnection())
                {
                    conn.Open();

                    // Using the exact lowercase column names from your pgAdmin
                    string query = "INSERT INTO users (name, email, password, role, signature, address) " +
                                   "VALUES (@n, @e, @p, @r, @s, @a)";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@n", name);
                        cmd.Parameters.AddWithValue("@e", email);

                        // 2. USE THE HASH: We save 'hashedPassword' instead of the raw 'password'
                        cmd.Parameters.AddWithValue("@p", hashedPassword);

                        cmd.Parameters.AddWithValue("@r", role);
                        cmd.Parameters.AddWithValue("@s", signature);
                        cmd.Parameters.AddWithValue("@a", address);

                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Database Error: " + ex.Message);
                return false;
            }
        }

        // 2. UPDATE USER
        //public bool UpdateUser(string originalEmail, string newName, string newRole)
        //{
        //    try
        //    {
        //        using (NpgsqlConnection conn = dbManager.GetConnection())
        //        {
        //            conn.Open();
        //            string query = "UPDATE users SET username=@n, role=@r WHERE email=@e";
        //            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
        //            {
        //                cmd.Parameters.AddWithValue("@n", newName.Trim());
        //                cmd.Parameters.AddWithValue("@r", newRole);
        //                cmd.Parameters.AddWithValue("@e", originalEmail);
        //                cmd.ExecuteNonQuery();
        //                return true;
        //            }
        //        }
        //    }
        //    catch { return false; }
        //}

        public bool UpdateUser(string email, string name, string role, string address)
        {
            try
            {
                using (NpgsqlConnection conn = dbManager.GetConnection())
                {
                    conn.Open();
                    // We update name, role, and address where the email matches
                    string query = "UPDATE users SET name = @n, role = @r, address = @a WHERE email = @e";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@n", name);
                        cmd.Parameters.AddWithValue("@r", role);
                        cmd.Parameters.AddWithValue("@a", address);
                        cmd.Parameters.AddWithValue("@e", email); // The unique key

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Update Error: " + ex.Message);
                return false;
            }
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

        public DataTable ValidateLogin(string username, string password)
        {
            try
            {
                // 1. SCRAMBLE the entered password first
                string hashedInput = SecurityHelper.HashPassword(password);

                using (NpgsqlConnection conn = dbManager.GetConnection())
                {
                    conn.Open();
                    // 2. We check the database for the username AND the HASHED password
                    string query = "SELECT userid, role FROM users WHERE name = @u AND password = @p";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@u", username);
                        cmd.Parameters.AddWithValue("@p", hashedInput); // Using the hash here!

                        NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Login Error: " + ex.Message);
                return null;
            }
        }
    }
}