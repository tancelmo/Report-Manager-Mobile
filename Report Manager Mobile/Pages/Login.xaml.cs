
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
        LabelHomeAppVer.Text = "Ver. " + AppInfo.Current.VersionString + "." + AppInfo.Current.BuildString;
    }
    private async void OnCounterClicked(object sender, EventArgs e)
    {
        if (SaveCredentialsCheckbx.IsChecked && UserEntry.Text != null)
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
        EmailCaption.Text = UserEntry.Text;
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
        await UserBox.TranslateTo(0, 0, 300);
        UserBox.IsVisible = true;
        LoginBox.IsVisible = false;
        await LoginBox.TranslateTo(500, 0, 300);
        EmailCaption.Text = AppResource.User;
        ActiveIndicatorLogin.IsRunning = false;

    }
    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        SaveCredentialsCheckbx.IsChecked = !SaveCredentialsCheckbx.IsChecked;

    }

    private async void ContentPage_Loaded(object sender, EventArgs e)
    {

        string saveCredential = await SecureStorage.Default.GetAsync("save_credentials");
        string serverAdress = await SecureStorage.Default.GetAsync("serverAdress");
        if (serverAdress == null)
        {
            await SecureStorage.Default.SetAsync("serverAdress", "localhost");
        }
        serverAdress = await SecureStorage.Default.GetAsync("serverAdress");
        Globals.serverAdress = serverAdress;
        Globals.connectionString = @"Server=" + Globals.serverAdress + ";Database=report_manager;Uid=newuser;Pwd=New@Mic15;SSL Mode=None;AllowPublicKeyRetrieval=true";

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