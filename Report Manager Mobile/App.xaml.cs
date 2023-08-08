using Report_Manager_Mobile.Pages;
using System.Diagnostics;

namespace Report_Manager_Mobile;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		StartUp.CreateFilesIfNotExist();
		
        MainPage = new Login();
	}
}
