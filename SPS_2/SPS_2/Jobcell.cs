using SQLite;
using System;
using System.IO;

namespace SPS_2
{
    public class Jobcell
    {
       
        public Jobcell()
        {                
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string zone { get; set; }
        public string Jobs{ get; set; }
        public bool Done { get; set; }
    }
}