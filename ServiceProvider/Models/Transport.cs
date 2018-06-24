﻿using ServiceProvider.Data;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace ServiceProvider.Models
{
    public class Transport:Services
    {
        public override int Id { get; set; }
        public override string ServiceName { get; set; }
        public override string ServiceType { get;  set; }
        public override string City { get; set; }
        public override string Country { get; set; }

   public Transport()
        {
            this.ServiceType = "Transport";
        }

    /*public static void Add(Services services)
    {
        SQLiteConnection conn = Connection.getInstance();
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = "INSERT INTO Services(ServiceName, ServiceType,City,Country VALUES(@ServiceName , @ServiceType, @City, @Country))";
        cmd.Parameters.AddWithValue("@ServiceName", services.ServiceName);
        cmd.Parameters.AddWithValue("@ServiceType", services.ServiceType);
        cmd.Parameters.AddWithValue("@City", services.City);
        cmd.Parameters.AddWithValue("@Country", services.Country);
        cmd.ExecuteNonQuery();
    }
        public static void Edit(int id , Services services)
        {
            SQLiteConnection conn = Connection.getInstance();
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Update Services set ServiceName ,ServiceType, City, Country where Id =id";
            cmd.Parameters.AddWithValue("@id", services.Id);
            cmd.Parameters.AddWithValue("@ServiceName", services.ServiceName);
            cmd.Parameters.AddWithValue("@ServiceType", services.ServiceType);
            cmd.Parameters.AddWithValue("@City", services.City);
            cmd.Parameters.AddWithValue("@Country", services.Country);
            cmd.ExecuteNonQuery();
        }

        public static  void Delete(int id)
        {
            SQLiteConnection conn = Connection.getInstance();
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Delete FROM Services  WHERE id =@id";
            cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
        }*/

        public static List<Transport> GetTransportList()
        {
            List<Transport> TransportList = new List<Transport>();
            SQLiteConnection conn = Connection.getInstance();
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM  Services  WHERE ServiceType='Transport'";
            cmd.CommandType = System.Data.CommandType.Text;
            SQLiteDataReader DataReader = cmd.ExecuteReader();
            while (DataReader.Read())
            {
                Transport DataStore = new Transport();
                DataStore.Id = Convert.ToInt32( DataReader["Id"]);
                DataStore.ServiceName = DataReader["ServiceName"].ToString();
                DataStore.ServiceType = DataReader["ServiceType"].ToString();
                DataStore.City = DataReader["City"].ToString();
                DataStore.Country = DataReader["Country"].ToString();
                TransportList.Add(DataStore);
            }
            return TransportList;
        }

        public static Transport FindId(int id)
        {
            Transport FindData = new Transport();
            SQLiteConnection conn = Connection.getInstance();
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Services WHERE Id=@id";
            cmd.Parameters.AddWithValue("@id", id);
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