using Report_Manager_Mobile.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report_Manager_Mobile
{
    internal class StartUp
    {
        
        public static void GetMailList()
        {
            UserLocalSettings.MailList = Preferences.Default.Get("MailList", string.Empty);
            UserLocalSettings.CcMailList = Preferences.Default.Get("CcMailList", string.Empty);
        }

            
        
    }
}
