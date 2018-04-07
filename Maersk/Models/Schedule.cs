using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Maersk.Models
{
    public class Schedule
    {
        [Key]
        public int ScheduleID { get; set; }

        [Required]
        public string Origin { get; set; }

        [Required]
        public string Destination { get; set; }

        [Required]
        [Display(Name = "Departure Date Time")]
        public DateTime DepartureDateTime { get; set; }

        [Required]
        [Display(Name = "Arrival Date Time")]
        public DateTime ArrivalDateTime { get; set; }

        public void DeleteStudentInfo(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Connect"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeleteStudentInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ExecuteID = new SqlParameter();
                ExecuteID.ParameterName = "@Id";
                ExecuteID.Value = id;
                cmd.Parameters.Add(ExecuteID);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}