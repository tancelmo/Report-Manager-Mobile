using Report_Manager_Mobile.Pages;

namespace Report_Manager_Mobile;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
