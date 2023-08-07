
using MySqlConnector;
using Report_Manager_Mobile.Data;
using Report_Manager_Mobile.Resources.Languages;
using System.Diagnostics;

namespace Report_Manager_Mobile.Pages;

public partial class Login : ContentPage
{
    string data = string.Empty;
	public Login()
	{
		InitializeComponent();

#if ANDROID25_0_OR_GREATER
        //LoginBG.Source = "capa.jpg";
        //DisplayAlert("Android Version", BuildVersionCodes.S.ToString(), "OK");
#endif
    }
    private async void OnCounterClicked(object sender, EventArgs e)
    {
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



        //MySqlDataReader reader;
        //MySqlCommand MySqlCommand = new();
        //ServerConnection ConnectionMySQL = new();


        //MySqlCommand.CommandText = $"SELECT * from login where UserName='{UserEntry.Text}'";
        //try
        //{
        //    MySqlCommand.Connection = ConnectionMySQL.Connect();
        //    reader = MySqlCommand.ExecuteReader();

        //    if (reader.Read())
        //    {

        //        await UserBox.TranslateTo(-500, 0, 300);
        //        UserBox.IsVisible = false;
        //        LoginBox.IsVisible = true;
        //        await LoginBox.TranslateTo(0, 0, 300);
        //        data = reader["Name"].ToString();

        //    }
        //    else
        //    {
        //        await DisplayAlert(AppResource.WarnignCaption, AppResource.NoUser, AppResource.OkButton);
        //    }
        //    ActiveIndicatorLogin.IsVisible = false;
        //    ActiveIndicatorLogin.IsRunning = false;


        //}
        //catch (MySqlException ex)
        //{
        //    // LogFile.Write("#800025 Login", ex.Me ssage);
        //    await DisplayAlert(AppResource.WarnignCaption, ex.Message, AppResource.OkButton);
        //    ActiveIndicatorLogin.IsVisible = false;
        //    ActiveIndicatorLogin.IsRunning = false;
        //}
        //ConnectionMySQL.Disconnect();

    }


    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        SaveCredentialsCheckbx.IsChecked = !SaveCredentialsCheckbx.IsChecked;

        //bypass
        await UserBox.TranslateTo(-500, 0, 300);
        UserBox.IsVisible = false;
        LoginBox.IsVisible = true;
        await LoginBox.TranslateTo(0, 0, 300);
    }

    private async void LoginBtn_Clicked(object sender, EventArgs e)
    {
        //if(UserPass.Text == "1505")
        //{
        //    Navigation.PushAsync(new HomePage());
        //}
        //else
        //{
        //    DisplayAlert(AppResource.AppDisplayName, AppResource.AccountError, AppResource.OkButton);
        //}
        ActiveIndicatorLogin.IsVisible = true;
        ActiveIndicatorLogin.IsRunning = true;
        await Task.Delay(100);
        await Navigation.PushModalAsync(new HomePage());
        Navigation.RemovePage(this);
        ActiveIndicatorLogin.IsRunning = false;

    }
}