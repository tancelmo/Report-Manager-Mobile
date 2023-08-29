using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Report_Manager_Mobile.Data
{
    public static class Globals
    {
        //192.168.15.33 - 172.23.171.59 - 179.111.22.76
        public static string connectionString { get; set; }

        public static string serverAdress { get; set; }

        public static string Costumer { get; set; } = string.Empty;

        public static string Facility { get; set; } = string.Empty;

        public static string ServiceNote { get; set; } = string.Empty;

        public static string Adress { get; set; } = string.Empty;

        public static string Equipment { get; set; } = string.Empty;

        public static string EquipmentType { get; set; } = string.Empty;

        public static string EquipmentSN { get; set; } = string.Empty;

        public static DateTime InvoiceDate { get; set; }

        public static string Work { get; set; }
    }
}
