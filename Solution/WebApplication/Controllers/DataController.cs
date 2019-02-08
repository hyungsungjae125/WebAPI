using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using WebApplication.Modules;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication.Controllers
{
    
    public class DataController : Controller
    {
        private ArrayList list;
        [Route("api/select")]
        [HttpGet]
        public ArrayList Select()
        {
            list = new ArrayList();
            DataBase db = new DataBase(); 
            try
            {
                MySqlDataReader sdr = db.GetReader("select * from Notice;");
                
                while (sdr.Read())
                {
                    Hashtable ht = new Hashtable();
                    for(int i = 0; i < sdr.FieldCount; i++)
                    {
                        ht.Add(sdr.GetName(i), sdr.GetValue(i));
                    }
                    list.Add(ht);
                }
                sdr.Close();
                return list;
            }
            catch
            {
                Console.WriteLine("Connection fail...");
                return null;
            }
        }
    }
}
