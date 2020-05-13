using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using RestApi.Models;

namespace RestApi.Persistency
{
    //public class PersistencyService
    //{
    //    private const string Get_All = "select * From Activites";
    //    private const string ConnectionString = "http://api.openweathermap.org/data/2.5/weather?q=Roskilde,dk&APPID=622f66a99c7a179b5c667c2d504ac522";
    //    public IEnumerable<Activity> Get()
    //    {
    //        List<Activity> activites = new List<Activity>();
    //        using (SqlConnection conn = new SqlConnection(ConnectionString))
    //        {
    //            conn.Open();
    //            if (conn.State == ConnectionState.Open)
    //            {
    //                using (SqlCommand cmd = conn.CreateCommand())
    //                {
    //                    cmd.CommandText = Get_All;
    //                    using (SqlDataReader reader = cmd.ExecuteReader())
    //                    {
    //                        while (reader.Read())
    //                        {
    //                            Activity activity = new Activity();
    //                            activity.id = reader.GetInt32(0);
    //                            activity.Name = reader.GetString(1);
    //                            activity.ActivityLevel = reader.GetString(2);
    //                            activity.Environment = reader.GetString(3);
    //                            activity.TimeInterval = reader.GetInt32(4);
    //                            activites.Add(activity);
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //        return activites;
    //    }

    //    public Activity Get(int Id)
    //    {
    //        Activity activity = new Activity();
    //        using (SqlConnection conn = new SqlConnection(ConnectionString))
    //        {
    //            conn.Open();
    //            if (conn.State == ConnectionState.Open)
    //            {
    //                using (SqlCommand cmd = conn.CreateCommand())
    //                {
    //                    cmd.CommandText = "select * from Activites where Id = @Param";
    //                    cmd.Parameters.AddWithValue("@param", Id);
    //                    //cmd.ExecuteNonQuery();
    //                    using (SqlDataReader reader = cmd.ExecuteReader())
    //                    {
    //                        if (reader.Read())
    //                        {

    //                            activity.id = reader.GetInt32(0);
    //                            activity.Name = reader.GetString(1);
    //                            activity.ActivityLevel = reader.GetString(2);
    //                            activity.Environment = reader.GetString(3);
    //                            activity.TimeInterval = reader.GetInt32(4);

    //                        }
    //                    }
    //                }
    //            }
    //        }

    //        return activity;

    //    }
    //}
}