using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Report_Manager_Mobile.Data
{
    public static class UserLocalSettings
    {
        public static bool ARACheck1_1 { get; set; }
        public static bool ARACheck1_2 { get; set; }
        public static bool ARACheck1_3 { get; set; }
        public static bool ARACheck1_4 { get; set; }
        public static bool ARACheck1_5 { get; set; }
        public static string ARAEditor1 { get; set; } = string.Empty;

        public static bool ARACheck2_1 { get; set; }
        public static bool ARACheck2_2 { get; set; }
        public static bool ARACheck2_3 { get; set; }
        public static string ARAEditor2 { get; set; } = string.Empty;

        public static bool ARACheck3_1 { get; set; }
        public static bool ARACheck3_2 { get; set; }
        public static bool ARACheck3_3 { get; set; }
        public static string ARAEditor3 { get; set; } = string.Empty;

        public static bool ARACheck4_1 { get; set; }
        public static bool ARACheck4_2 { get; set; }
        public static bool ARACheck4_3 { get; set; }
        public static bool ARACheck4_4 { get; set; }
        public static bool ARACheck4_5 { get; set; }
        public static string ARAEditor4 { get; set; } = string.Empty;

        public static bool ARACheck5_1 { get; set; }
        public static bool ARACheck5_2 { get; set; }
        public static bool ARACheck5_3 { get; set; }
        public static bool ARACheck5_4 { get; set; }
        public static bool ARACheck5_5 { get; set; }
        public static bool ARACheck5_6 { get; set; }
        public static string ARAEditor5 { get; set; } = string.Empty;

        public static bool ARACheck6_1 { get; set; }
        public static bool ARACheck6_2 { get; set; }
        public static bool ARACheck6_3 { get; set; }
        public static bool ARACheck6_4 { get; set; }
        public static bool ARACheck6_5 { get; set; }
        public static bool ARACheck6_6 { get; set; }
        public static bool ARACheck6_7 { get; set; }
        public static bool ARACheck6_8 { get; set; }
        public static bool ARACheck6_9 { get; set; }
        public static string ARAEditor6 { get; set; } = string.Empty;

        public static bool ARACheck7_1 { get; set; }
        public static bool ARACheck7_2 { get; set; }
        public static bool ARACheck7_3 { get; set; }
        public static bool ARACheck7_4 { get; set; }
        public static bool ARACheck7_5 { get; set; }
        public static bool ARACheck7_6 { get; set; }
        public static bool ARACheck7_7 { get; set; }
        public static bool ARACheck7_8 { get; set; }
        public static string ARAEditor7 { get; set; } = string.Empty;

        public static bool LastSettings { get; set; }

        public static bool RememberMe { get; set; }

        public static string MailList { get; set; } = string.Empty;

        public static string CcMailList { get; set; } = string.Empty;


        public static void GetUserSettings(bool option)
        {
            if (option)
            {
                ARACheck1_1 = Preferences.Default.Get("ARAcheck1_1", false);
                ARACheck1_2 = Preferences.Default.Get("ARAcheck1_2", false);
                ARACheck1_3 = Preferences.Default.Get("ARAcheck1_3", false);
                ARACheck1_4 = Preferences.Default.Get("ARAcheck1_4", false);
                ARACheck1_5 = Preferences.Default.Get("ARAcheck1_5", false);
                ARAEditor1 = Preferences.Default.Get("ARAEditor1", "");

                ARACheck2_1 = Preferences.Default.Get("ARAcheck2_1", false);
                ARACheck2_2 = Preferences.Default.Get("ARAcheck2_2", false);
                ARACheck2_3 = Preferences.Default.Get("ARAcheck2_3", false);
                ARAEditor2 = Preferences.Default.Get("ARAEditor2", "");

                ARACheck3_1 = Preferences.Default.Get("ARAcheck3_1", false);
                ARACheck3_2 = Preferences.Default.Get("ARAcheck3_2", false);
                ARACheck3_3 = Preferences.Default.Get("ARAcheck3_3", false);
                ARAEditor3 = Preferences.Default.Get("ARAEditor3", "");

                ARACheck4_1 = Preferences.Default.Get("ARAcheck4_1", false);
                ARACheck4_2 = Preferences.Default.Get("ARAcheck4_2", false);
                ARACheck4_3 = Preferences.Default.Get("ARAcheck4_3", false);
                ARACheck4_4 = Preferences.Default.Get("ARAcheck4_4", false);
                ARACheck4_5 = Preferences.Default.Get("ARAcheck4_5", false);
                ARAEditor3 = Preferences.Default.Get("ARAEditor3", "");

                ARACheck5_1 = Preferences.Default.Get("ARAcheck5_1", false);
                ARACheck5_2 = Preferences.Default.Get("ARAcheck5_2", false);
                ARACheck5_3 = Preferences.Default.Get("ARAcheck5_3", false);
                ARACheck5_4 = Preferences.Default.Get("ARAcheck5_4", false);
                ARACheck5_5 = Preferences.Default.Get("ARAcheck5_5", false);
                ARACheck5_6 = Preferences.Default.Get("ARAcheck5_6", false);
                ARAEditor5 = Preferences.Default.Get("ARAEditor5", "");

                ARACheck6_1 = Preferences.Default.Get("ARAcheck6_1", false);
                ARACheck6_2 = Preferences.Default.Get("ARAcheck6_2", false);
                ARACheck6_3 = Preferences.Default.Get("ARAcheck6_3", false);
                ARACheck6_4 = Preferences.Default.Get("ARAcheck6_4", false);
                ARACheck6_5 = Preferences.Default.Get("ARAcheck6_5", false);
                ARACheck6_6 = Preferences.Default.Get("ARAcheck6_6", false);
                ARACheck6_7 = Preferences.Default.Get("ARAcheck6_7", false);
                ARACheck6_8 = Preferences.Default.Get("ARAcheck6_8", false);
                ARACheck6_9 = Preferences.Default.Get("ARAcheck6_9", false);
                ARAEditor6 = Preferences.Default.Get("ARAEditor6", "");

                ARACheck7_1 = Preferences.Default.Get("ARAcheck7_1", false);
                ARACheck7_2 = Preferences.Default.Get("ARAcheck7_2", false);
                ARACheck7_3 = Preferences.Default.Get("ARAcheck7_3", false);
                ARACheck7_4 = Preferences.Default.Get("ARAcheck7_4", false);
                ARACheck7_5 = Preferences.Default.Get("ARAcheck7_5", false);
                ARACheck7_6 = Preferences.Default.Get("ARAcheck7_6", false);
                ARACheck7_7 = Preferences.Default.Get("ARAcheck7_7", false);
                ARACheck7_8 = Preferences.Default.Get("ARAcheck7_8", false);
                ARAEditor7 = Preferences.Default.Get("ARAEditor7", "");

            }
            else
            {
                
                ARACheck1_1 = false;
                ARACheck1_2 = false;
                ARACheck1_3 = false;
                ARACheck1_4 = false;
                ARACheck1_5 = false;
                ARAEditor1 = string.Empty;

                ARACheck2_1 = false;
                ARACheck2_2 = false;
                ARACheck2_3 = false;
                ARAEditor2 = string.Empty;

                ARACheck3_1 = false;
                ARACheck3_2 = false;
                ARACheck3_3 = false;
                ARAEditor3 = string.Empty;

                ARACheck4_1 = false;
                ARACheck4_2 = false;
                ARACheck4_3 = false;
                ARACheck4_4 = false;
                ARACheck4_5 = false;
                ARAEditor3 = string.Empty;

                ARACheck5_1 = false;
                ARACheck5_2 = false;         
                ARACheck5_3 = false;
                ARACheck5_4 = false;
                ARACheck5_5 = false;
                ARACheck5_6 = false;             
                ARAEditor5 = string.Empty;

                ARACheck6_1 = false;
                ARACheck6_2 = false;
                ARACheck6_3 = false;
                ARACheck6_4 = false;
                ARACheck6_5 = false;
                ARACheck6_6 = false;
                ARACheck6_7 = false;
                ARACheck6_8 = false;
                ARACheck6_9 = false;
                ARAEditor6 = string.Empty;

                ARACheck7_1 = false;
                ARACheck7_2 = false;
                ARACheck7_3 = false;
                ARACheck7_4 = false;
                ARACheck7_5 = false;
                ARACheck7_6 = false;
                ARACheck7_7 = false;
                ARACheck7_8 = false;
                ARAEditor7 = string.Empty;
            }
        }
    }
}
