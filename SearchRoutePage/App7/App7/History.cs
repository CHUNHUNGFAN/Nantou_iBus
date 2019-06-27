using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App7
{
    public class History
    {
        public History()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string UserName { get; set; }
        public string SettingName { get; set; }
        public bool Done { get; set; }
    }
}
