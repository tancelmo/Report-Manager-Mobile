using Report_Manager_Mobile.Data;
using Report_Manager_Mobile.Pages;
using System.Diagnostics;

namespace Report_Manager_Mobile;

public partial class App : Application
{
	public App()
	{
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjY3MzkzMUAzMjMyMmUzMDJlMzBkaURSZC9CYk5SY0hET2FlaWlnNDFJUXBQYjNGeW1OdE5wTnFtanhjT3gwPQ==");
        InitializeComponent();
        UserLocalSettings.LastSettings = Preferences.Default.Get("LastSettings", false);
        StartUp.GetMailList();
        MainPage = new AppShell();
	}

	
}
