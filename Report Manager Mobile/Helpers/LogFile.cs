using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Report_Manager_Mobile.Helpers
{
        internal class LogFile
        {
        
        public static void Write(string codeMessage, string localExeption, bool append = true)
            {
            string root = null;

#if ANDROID
        
        if (Android.OS.Environment.IsExternalStorageEmulated)
        {
            root = Android.App.Application.Context!.GetExternalFilesDir(Android.OS.Environment.DirectoryDownloads)!.AbsolutePath;
        }
        else
            root = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
        
#endif
            if(!Directory.Exists(root + "/Log"))
            {
                Directory.CreateDirectory(root + "/Log");
            }
                using (FileStream stream = new FileStream(root + "/Log/Log.txt", append ? FileMode.Append : FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))
                using (StreamWriter sw = new StreamWriter(stream))
                {
                    sw.WriteLineAsync("[" + DateTime.Now + "] " + codeMessage + " - " + localExeption);
                }

            }
        }
}
