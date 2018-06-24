using ServiceProvider.Data;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace ServiceProvider.Models
{
    public abstract class Services
    {
        public abstract int Id { get; set; }
        public abstract string ServiceName { get; set; }
        public abstract string ServiceType { get;  set; }
        public abstract string City { get; set; }
        public abstract string Country { get; set; }
        //public string ServiceType { get; set; }



        public static void Add(Services services)
        {
            SQLiteConnection conn = Connection.getInstance();
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Services(ServiceName, ServiceType,City,Country) VALUES(@ServiceName , @ServiceType, @City, @Country)";
            cmd.Parameters.AddWithValue("@ServiceName", services.ServiceName);
            cmd.Parameters.AddWithValue("@ServiceType", services.ServiceType);
            cmd.Parameters.AddWithValue("@City", services.City);
            cmd.Parameters.AddWithValue("@Country", services.Country);
            cmd.ExecuteNonQuery();
        }

        public static  void Edit(int id ,Services services)
        {
            SQLiteConnection conn = Connection.getInstance();
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Update Services set ServiceName = @ServiceName , City = @City, Country = @Country where id =@id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@ServiceName", services.ServiceName);
            cmd.Parameters.AddWithValue("@City", services.City);
            cmd.Parameters.AddWithValue("@Country", services.Country);
            cmd.ExecuteNonQuery();
        }

        public static void Delete(int id)
        {
            SQLiteConnection conn = Connection.getInstance();
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Delete FROM Services WHERE id =@id";
            cmd.Parameters.AddWithValue("@id", id);
          
            cmd.ExecuteNonQuery();
        }

    }


}