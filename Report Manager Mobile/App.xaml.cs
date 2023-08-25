using Report_Manager_Mobile.Data;
using Report_Manager_Mobile.Pages;
using System.Diagnostics;

namespace Report_Manager_Mobile;

public partial class App : Application
{
	public App()
	{
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjYzMTc3OEAzMjMyMmUzMDJlMzBhcXFMc051cUY2Y1VVOHowOW1KRG9IdlZ0RWN5bWlKdUtNYjhkVDZ6aWpVPQ==");
        InitializeComponent();
        UserLocalSettings.LastSettings = Preferences.Default.Get("LastSettings", false);
        StartUp.GetMailList();
        MainPage = new Login();
	}

	
}
