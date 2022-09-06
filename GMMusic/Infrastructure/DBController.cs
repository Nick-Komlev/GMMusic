using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMMusic.Models;

namespace GMMusic.Infrastructure
{
    public static class DBController
    {
        public static MyDBContext DBContext { get; set; }

        static DBController()
        {
            DBContext = new MyDBContext();
        }

        public static void SaveChanges()
        {
            DBContext.SaveChanges();
        }
    }
}
