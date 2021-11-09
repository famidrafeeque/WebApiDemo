using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApiDemo.Models
{
    public class CollegeRepository
    {
        SqlConnection _sqlConnection = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=TrainingManagement;Integrated Security=True");
        public IEnumerable<College> GetColleges()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("spGetColleges", _sqlConnection);
            da.Fill(ds);
            List<College> colleges = new List<College>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                College college = new College()
                {
                    CollegeId = Int32.Parse(item["CollegeId"].ToString()),
                    CollegeName= item["CollegeName"].ToString(),
                    StateId= Int32.Parse(item["StateId"].ToString())
                };
                colleges.Add(college);
            }
            return colleges;
        }
        public void AddCollege(College college)
        {
            _sqlConnection.Open();
            SqlCommand command = new SqlCommand("spInsertcollege", _sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@pcollegeName",college.CollegeName );
            command.Parameters.AddWithValue("@pStateId", college.StateId);
            command.ExecuteNonQuery();
            command.Dispose();
            _sqlConnection.Close();
        }
        public void UpdateCollege(College college)
        {
            _sqlConnection.Open();
            SqlCommand command = new SqlCommand("spUpdateCollege",_sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@pCollegeId", college.CollegeId);
            command.Parameters.AddWithValue("@pCollegeName", college.CollegeName);
            command.Parameters.AddWithValue("@pStateId", college.StateId);
            command.ExecuteNonQuery();
            command.Dispose();
            _sqlConnection.Close();
        }
        public void DeleteCollege(int collegeId)
        {
            _sqlConnection.Open();
            SqlCommand command = new SqlCommand("spDeletecollege", _sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@pcollegeId", collegeId);
            command.ExecuteNonQuery();
            command.Dispose();
            _sqlConnection.Close();
        }
    }
}