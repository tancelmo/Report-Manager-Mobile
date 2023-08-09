
using MySqlConnector;
using Report_Manager_Mobile.Data;
using Report_Manager_Mobile.Resources.Languages;
using System.Diagnostics;

namespace Report_Manager_Mobile.Pages;

public partial class Login : ContentPage
{

	public Login()
	{
		InitializeComponent();
    }
    private async void OnCounterClicked(object sender, EventArgs e)
    {
        if (SaveCredentialsCheckbx.IsChecked)
        {
            await SecureStorage.Default.SetAsync("save_credentials", UserEntry.Text);
        }
        else
        {
            await SecureStorage.Default.SetAsync("save_credentials", "");
        }
        //bypass
        ActiveIndicatorLogin.IsVisible = true;
        ActiveIndicatorLogin.IsRunning = true;
        await Task.Delay(1000);
        await UserBox.TranslateTo(-500, 0, 300);
        UserBox.IsVisible = false;
        LoginBox.IsVisible = true;
        await LoginBox.TranslateTo(0, 0, 300);
        
        ActiveIndicatorLogin.IsRunning = false;
        //--------------------

    }


    private async void LoginBtn_Clicked(object sender, EventArgs e)
    {
        
        ActiveIndicatorLogin.IsVisible = true;
        ActiveIndicatorLogin.IsRunning = true;
        await Task.Delay(100);
        Navigation.RemovePage(this);
        await Navigation.PushModalAsync(new HomePage());
        //await Shell.Current.GoToAsync("HomePage");
        //Navigation.RemovePage(this);
        //await Shell.Current.GoToAsync("HomePage");
        ActiveIndicatorLogin.IsRunning = false;

    }
    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        SaveCredentialsCheckbx.IsChecked = !SaveCredentialsCheckbx.IsChecked;

    }

    private async void ContentPage_Loaded(object sender, EventArgs e)
    {
        string saveCredential = await SecureStorage.Default.GetAsync("save_credentials");
        
        if (saveCredential != "")
        {
            SaveCredentialsCheckbx.IsChecked = true;
            UserEntry.Text = saveCredential;
        }
        else
        {
            SaveCredentialsCheckbx.IsChecked = false;
        }
    }
}