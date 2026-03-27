using CalendarManagementDataL;
using CalendarManagementModels;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CalendarManagementDataLayer
{
    public class CalendarDatabase : InterfaceEventData
    {
        private string _cs = @"Data Source=LAPTOP-O72KAUC7\SQLEXPRESS; Initial Catalog=Calendar_db; Integrated Security=True; TrustServerCertificate=True;";
        private SqlConnection _conn;

        public CalendarDatabase()
        {
            _conn = new SqlConnection(_cs);
        }

        public void AddEvent(CalendarEvent e)
        {
            var sql = "INSERT INTO events (EventDate, EventName) VALUES (@d, @n)";
            using var cmd = new SqlCommand(sql, _conn);
            cmd.Parameters.AddWithValue("@d", e.EventDate.Date);
            cmd.Parameters.AddWithValue("@n", e.EventName);

            _conn.Open();
            cmd.ExecuteNonQuery();
            _conn.Close();
        }

        public List<CalendarEvent> GetAllEvents()
        {
            var sql = "SELECT EventDate, EventName FROM events";
            var list = new List<CalendarEvent>();
            using var cmd = new SqlCommand(sql, _conn);

            _conn.Open();
            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                list.Add(new CalendarEvent
                {
                    EventDate = Convert.ToDateTime(r["EventDate"]),
                    EventName = r["EventName"].ToString()
                });
            }
            _conn.Close();
            return list;
        }

        public void UpdateEvent(DateTime old, CalendarEvent e)
        {
            var sql = "UPDATE events SET EventName=@n, EventDate=@d WHERE EventDate=@o";
            using var cmd = new SqlCommand(sql, _conn);
            cmd.Parameters.AddWithValue("@n", e.EventName);
            cmd.Parameters.AddWithValue("@d", e.EventDate.Date);
            cmd.Parameters.AddWithValue("@o", old.Date);

            _conn.Open();
            cmd.ExecuteNonQuery();
            _conn.Close();
        }

        public bool DeleteByDate(DateTime dt)
        {
            var sql = "DELETE FROM events WHERE EventDate = @d";
            using var cmd = new SqlCommand(sql, _conn);
            cmd.Parameters.AddWithValue("@d", dt.Date);

            _conn.Open();
            int res = cmd.ExecuteNonQuery();
            _conn.Close();
            return res > 0;
        }

        public CalendarEvent? GetByDate(DateTime dt)
        {
            return GetAllEvents().FirstOrDefault(x => x.EventDate.Date == dt.Date);
        }
    }
}