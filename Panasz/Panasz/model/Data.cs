using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panasz.model
{
    internal class Data
    {
        public Data(int id, string nev, string email, string telefon, string panaszado, string datum, string panasz)
        {
            this.id = id;
            this.nev = nev;
            this.email = email;
            this.telefon = telefon;
            this.panaszado = panaszado;
            this.datum = datum;
            this.panasz = panasz;
        }

        public int id { get; set; }
        public string nev { get; set; }
        public string email { get; set; }
        public string telefon { get; set; }
        public string panaszado { get; set; }
        public string datum { get; set; }
        public string panasz { get; set; }
        

      
    }
}
