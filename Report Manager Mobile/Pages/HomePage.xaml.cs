using Report_Manager_Mobile.Data;
using Report_Manager_Mobile.Resources.Languages;

namespace Report_Manager_Mobile.Pages;

public partial class HomePage : TabbedPage
{
	
	public HomePage()
	{
		InitializeComponent();
		
	}
    protected override bool OnBackButtonPressed()
    {
		DisplayAlert(AppResource.AppDisplayName, "Deseja Sair?", "ok");
		return base.OnBackButtonPressed();
    }

}