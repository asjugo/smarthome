using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UniversalServer.Model
{
    public delegate EventHandler ErrorEventHandler(string msg);
    public class DBAccess
    {

        public DBAccess()
        {
            //Hier die Verbindung zur DB herstellen. Siehe Info-Pool
            //Verbindungsdaten dürfen "hard codiert" werden.

        }

        ///Diese Methode für den Datensatz in die Datenbank ein. Siehe Info-Pool      
        public void InsertData(TempValue t, HumidValue h, PressureValue p, DateTime dt, string ipa)
        {


        }


    }
}
