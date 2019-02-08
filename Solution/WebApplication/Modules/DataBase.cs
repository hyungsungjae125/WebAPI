using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Modules
{
    public class DataBase
    {
        MySqlConnection conn;
        bool status;

        public DataBase()
        {
            status = GetConnection();
        }

        private bool GetConnection()
        {
            conn = new MySqlConnection();
            conn.ConnectionString = string.Format("server={0};user={1};password={2};database={3};port={4}", "gdc3.gudi.kr", "root", "1234", "gudi", "30002");
            try
            {
                conn.Open();
                return true;
            }
            catch
            {
                Console.WriteLine("Connection fail...");
                return false;
            }
        }

        public MySqlDataReader GetReader(string sql)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = sql;
            comm.Connection = conn;
            try
            {
                return comm.ExecuteReader();
            }
            catch
            {
                return null;
            }
        }
    }
}
