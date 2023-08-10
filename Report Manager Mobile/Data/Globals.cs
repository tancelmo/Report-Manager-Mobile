using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report_Manager_Mobile.Data
{
    public static class Globals
    {
        //192.168.15.33 - 172.23.171.59 - 179.111.22.76
        public static string connectionString = @"Server=179.111.22.76;Database=report_manager;Uid=newuser;Pwd=New@Mic15;SSL Mode=None;AllowPublicKeyRetrieval=true";

        public static string ConfigFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Settings\\Config.ini";

        public static string ConfigPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Settings";
        public static string Costumer { get; set; }

        public static string Facility { get; set; }

        public static string ServiceNote { get; set; }

        public static string Adress { get; set; }

        public static string Equipment { get; set; }

        public static string EquipmentType { get; set; }

        public static string EquipmentSN { get; set; }
    }
}
