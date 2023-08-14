using Report_Manager_Mobile.Data;

namespace Report_Manager_Mobile.Pages;

public partial class ARA : ContentPage
{
	public ARA()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		Report.CreateARA();
		Report.CreateCTC();
		Report.CreateRT();
    }
}