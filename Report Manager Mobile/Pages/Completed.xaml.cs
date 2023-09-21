using Report_Manager_Mobile.Helpers;
using System.Diagnostics;

namespace Report_Manager_Mobile.Pages;

public partial class Completed : ContentPage
{
	public Completed()
	{
		InitializeComponent();
	}

    private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void collectionData_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        collectionData.ItemsSource = ServicesPage.ServicesPageCurrent.schedules;
        try
        {
            var filteredList = ServicesPage.ServicesPageCurrent.schedules.Where(a => a.MobileComplete.Equals(true));
            collectionData.ItemsSource = filteredList;
        }catch(Exception ex)
        {
            LogFile.Write("#70004", ex.Message);
            Debug.Write(ex.Message);
        }
        
    }
}