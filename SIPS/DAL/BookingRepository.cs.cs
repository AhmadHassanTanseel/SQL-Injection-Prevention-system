using System;
using System.Data;
using Npgsql;

namespace SIPS.DAL
{
    public class BookingRepository
    {
        private DatabaseManager dbManager = new DatabaseManager();

        // 1. FOR THE CUSTOMER: Book a magazine (Sets to Pending, lowers stock by 1)
        public bool BookMagazine(int userId, int magazineId, decimal price)
        {
            try
            {
                using (NpgsqlConnection conn = dbManager.GetConnection())
                {
                    conn.Open();
                    // Notice we run TWO commands here: Create the booking, and update the stock!
                    string query = @"
                        INSERT INTO Bookings (UserID, MagazineID, TotalAmount, Status) 
                        VALUES (@uid, @mid, @amount, 'Pending');
                        
                        UPDATE Magazines SET Stock = Stock - 1 WHERE MagazineID = @mid;";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@uid", userId);
                        cmd.Parameters.AddWithValue("@mid", magazineId);
                        cmd.Parameters.AddWithValue("@amount", price);

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

        // 2. FOR THE ADMIN: Approve a pending booking
        public bool ApproveBooking(int bookingId)
        {
            try
            {
                using (NpgsqlConnection conn = dbManager.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE Bookings SET Status = 'Approved' WHERE BookingID = @bid";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@bid", bookingId);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch { return false; }
        }

        // 3. FOR ADMIN OR CUSTOMER: Cancel a booking (Sets to Cancelled, gives stock back)
        public bool CancelBooking(int bookingId, int magazineId)
        {
            try
            {
                using (NpgsqlConnection conn = dbManager.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        UPDATE Bookings SET Status = 'Cancelled' WHERE BookingID = @bid;
                        UPDATE Magazines SET Stock = Stock + 1 WHERE MagazineID = @mid;";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@bid", bookingId);
                        cmd.Parameters.AddWithValue("@mid", magazineId);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch { return false; }
        }

        // 4. FOR THE ADMIN: Calculate exact Revenue (Only counts 'Approved' sales!)
        public decimal GetTotalRevenue()
        {
            try
            {
                using (NpgsqlConnection conn = dbManager.GetConnection())
                {
                    conn.Open();
                    // COALESCE makes sure it returns 0 instead of crashing if there are no sales yet
                    string query = "SELECT COALESCE(SUM(TotalAmount), 0) FROM Bookings WHERE Status = 'Approved'";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        return Convert.ToDecimal(cmd.ExecuteScalar());
                    }
                }
            }
            catch { return 0; }
        }

        // 5. TO SHOW DATA: Get bookings for the DataGridViews
        public DataTable GetBookings(int? userId = null)
        {
            DataTable dt = new DataTable();
            try
            {
                using (NpgsqlConnection conn = dbManager.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM Bookings";

                    // If we pass a userId, it only gets that customer's history. If not, it gets everything for the Admin.
                    if (userId.HasValue)
                    {
                        query += " WHERE UserID = @uid";
                    }

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        if (userId.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@uid", userId.Value);
                        }

                        using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch { }
            return dt;
        }
    }
}