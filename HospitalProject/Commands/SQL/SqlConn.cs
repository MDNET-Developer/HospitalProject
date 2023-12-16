using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProject.Commands.SQL
{
    public class SqlConn
    {
       

        public SqlConnection baglanti()
        { 
            string connectionString = "Server=DESKTOP-A7OBGD5;Database=HospitalReservationSystem;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            return conn;
        }
    }
}
