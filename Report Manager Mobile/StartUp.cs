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
        public static void CreateFilesIfNotExist()
        {
            if (!Directory.Exists(Globals.ConfigPath))
            {
                Directory.CreateDirectory(Globals.ConfigPath);


            }

            if (!File.Exists(Globals.ConfigFilePath))
            {

                CreateConfigFile();
            }
        }

        internal static void CreateConfigFile()
        {
            using (StreamWriter writer = new StreamWriter(Globals.ConfigFilePath, append: true))
            {
                writer.Write(
    @"[General]
AccentColor=#FF0078D4
MarkUP=##
ReportExtension=.xls

[Connection]
ServerAdress=

[Login]
SaveCredentials=0
Credentials=

[FilterDates]
FilterDateSN=2021-01-01
FilterDateUT=2000-01-01
FilterDateUM=2000-01-01

[Database]
DbUT=D:\0 - Development\ReportManager\bin\x86\Debug\Results.mdb
DbUM=D:\0 - Development\ReportManager\bin\x86\Debug\UM.mdb
DbSN=D:\0 - Development\ReportManager\bin\x86\Debug\Sonical\Results.mdb

[DirectoryTemplates]
TemplateFolder1=D:\0 - Development\ReportManager\bin\x86\Debug\ReportTemplates\UT
TemplateFolder2=D:\0 - Development\ReportManager\bin\x86\Debug\ReportTemplates\UM
TemplateFolder3=D:\0 - Development\ReportManager\bin\x86\Debug\ReportTemplates\SN

[TemporaryFolderFiles]
TempFolder1=D:\0 - Development\ReportManager\bin\x86\Debug\ReportTemplates\UT\Temp
TempFolder2=D:\0 - Development\ReportManager\bin\x86\Debug\ReportTemplates\UM\Temp
TempFolder3=D:\0 - Development\ReportManager\bin\x86\Debug\ReportTemplates\SN\Temp

[ScheduleGrid]
RowPsition=0
FronzenColumns0=0
FronzenColumns1=0
FronzenColumns2=0
FronzenColumns3=0
FronzenColumns4=0
Status_000=
Status_001=
Status_002=
Status_003=
Status_004=
Status_005=
Status_006=
Status_007=
Status_008=
Status_009=
Status_010=

[StyleGrid]
Status_000Foreground=
Status_000Background=
Status_001Foreground=
Status_001Background=
Status_002Foreground=
Status_002Background=
Status_003Foreground=
Status_003Background=
Status_004Foreground=
Status_004Background=
Status_005Foreground=
Status_005Background=
Status_006Foreground=
Status_006Background=
Status_007Foreground=
Status_007Background=
Status_008Foreground=
Status_008Background=
Status_009Foreground=
Status_009Background=
Status_010Foreground=
Status_010Background=");

            }
        }
    }
}
