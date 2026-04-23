using System;
using System.Data;
using Npgsql;
using System.Windows.Forms;

namespace SIPS.DAL
{
    public class BookingRepository
    {
        private DatabaseManager dbManager = new DatabaseManager();

        // 1. Get Bookings for the Admin Grid (Includes Customer Name and Magazine Title)
        public DataTable GetBookings(int? userId = null)
        {
            DataTable dt = new DataTable();
            try
            {
                using (NpgsqlConnection conn = dbManager.GetConnection())
                {
                    conn.Open();
                    // Using exact lowercase names from your pgAdmin: bookingid, userid, magazineid
                    //string query = @"SELECT b.bookingid AS ID, u.name AS Customer, m.title AS Magazine, 
                    //                 b.totalamount AS Amount, b.status AS Status 
                    //                 FROM bookings b
                    //                 JOIN users u ON b.userid = u.userid
                    //                 JOIN magazines m ON b.magazineid = m.magazineid";

                    // We add b.magazineid AS MagazineID so the grid has that data hidden in it
                    string query = @"SELECT b.bookingid AS ID, b.magazineid AS MagazineID, u.name AS Customer, 
                 m.title AS Magazine, b.totalamount AS Amount, b.status AS Status 
                 FROM bookings b
                 JOIN users u ON b.userid = u.userid
                 JOIN magazines m ON b.magazineid = m.magazineid";

                    if (userId.HasValue)
                    {
                        query += " WHERE b.userid = @uid";
                    }

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        if (userId.HasValue) cmd.Parameters.AddWithValue("@uid", userId.Value);
                        using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message);
            }
            return dt;
        }

        // 2. Approve a Booking
        public bool ApproveBooking(int bookingId)
        {
            try
            {
                using (NpgsqlConnection conn = dbManager.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE bookings SET status = 'Approved' WHERE bookingid = @bid";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@bid", bookingId);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch { return false; }
        }

        // 3. Cancel a Booking (Restores Stock)
        public bool CancelBooking(int bookingId, int magazineId)
        {
            try
            {
                using (NpgsqlConnection conn = dbManager.GetConnection())
                {
                    conn.Open();
                    // Updating status and stock using exact column names: status, stock, magazineid
                    string query = @"UPDATE bookings SET status = 'Cancelled' WHERE bookingid = @bid;
                                     UPDATE magazines SET stock = stock + 1 WHERE magazineid = @mid;";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@bid", bookingId);
                        cmd.Parameters.AddWithValue("@mid", magazineId);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch { return false; }
        }

        // 4. Calculate Revenue
        public decimal GetTotalRevenue()
        {
            try
            {
                using (NpgsqlConnection conn = dbManager.GetConnection())
                {
                    conn.Open();
                    // Using totalamount and status from your screenshots
                    string query = "SELECT COALESCE(SUM(totalamount), 0) FROM bookings WHERE status = 'Approved'";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        return Convert.ToDecimal(cmd.ExecuteScalar());
                    }
                }
            }
            catch { return 0; }
        }
    }
}