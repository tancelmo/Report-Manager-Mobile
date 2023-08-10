using Report_Manager_Mobile.Data;
using Report_Manager_Mobile.Resources.Languages;
using System.Diagnostics;

namespace Report_Manager_Mobile.Pages;

public partial class HomePage : TabbedPage
{
	
	public HomePage()
	{
		InitializeComponent();
		
	}
    protected override bool OnBackButtonPressed()
    {
        Dispatcher.Dispatch(async () =>
        {
            var leave = await DisplayAlert(AppResource.WarnignCaption, AppResource.Quit, AppResource.Yes, AppResource.No);

            if (leave)
            {
                Application.Current.Quit();
            }
            
        });

        return true;
    }

}