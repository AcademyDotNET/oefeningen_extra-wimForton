using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    class MySQLConnection
    {
    }


    class PasswordReminder
    {
        //private MySQLConnection DbConnection { get; set; } = new MySQLConnection();
        public PasswordReminder(MySQLConnection con)
        {
            MySQLConnection DbConnection = con;
        }
    }
}
