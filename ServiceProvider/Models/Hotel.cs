using ServiceProvider.Data;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace ServiceProvider.Models
{
    public class Hotel:Services
    {
        public override int Id { get; set; }
        public override string ServiceName { get; set; }
        public override string ServiceType { get;  set; }
        public override string City { get; set; }
        public override string Country { get; set; }

      public Hotel()
        {

            this.ServiceType = "Hotel";
        }

       
        public static List<Hotel> GetHotelList()
        {
            List<Hotel> HotelList = new List<Hotel>();
            SQLiteConnection conn = Connection.getInstance();
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Services  WHERE ServiceType='Hotel'";
            cmd.CommandType = System.Data.CommandType.Text;
            SQLiteDataReader DatarReader = cmd.ExecuteReader();
            while (DatarReader.Read())
            {
                Hotel DataStore = new Hotel();
                DataStore.Id =Convert.ToInt32(DatarReader["Id"]);
                DataStore.ServiceName = DatarReader["ServiceName"].ToString();
                DataStore.ServiceType = DatarReader["ServiceType"].ToString();
                DataStore.City = DatarReader["City"].ToString();
                DataStore.Country = DatarReader["Country"].ToString();
                HotelList.Add(DataStore);
            }
            
            return HotelList;

        }

       public static Hotel FindId(int id)
        {
            Hotel FindData = new Hotel();
            SQLiteConnection conn = Connection.getInstance();
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Services WHERE Id=@id";
            cmd.Parameters.AddWithValue("@id",id);
            SQLiteDataReader DataReader = cmd.ExecuteReader();
            DataReader.Read();
            FindData.Id = Convert.ToInt32(DataReader["Id"]);
            FindData.ServiceName = DataReader["ServiceName"].ToString();
            FindData.ServiceType = DataReader["ServiceType"].ToString();
            FindData.City = DataReader["City"].ToString();
            FindData.Country = DataReader["Country"].ToString();
            
            return FindData;
        }


    }
}
