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
	}
    private async void OnCounterClicked(object sender, EventArgs e)
    {
        ActiveIndicatorLogin.IsVisible = true;
        ActiveIndicatorLogin.IsRunning = true;
        await Task.Delay(1000);
        MySqlDataReader reader;
        MySqlCommand MySqlCommand = new();
        ServerConnection ConnectionMySQL = new();
        

        MySqlCommand.CommandText = $"SELECT * from login where UserName='{UserEntry.Text}'";
        try
        {
            MySqlCommand.Connection = ConnectionMySQL.Connect();
            reader = MySqlCommand.ExecuteReader();

            if (reader.Read())
            {

                await UserBox.TranslateTo(-500, 0, 300);
                UserBox.IsVisible = false;
                LoginBox.IsVisible = true;
                await LoginBox.TranslateTo(0, 0, 300);
                data = reader["Name"].ToString();

            }
            else
            {
                await DisplayAlert(AppResource.WarnignCaption, AppResource.NoUser, AppResource.OkButton);
            }
            ActiveIndicatorLogin.IsVisible = false;
            ActiveIndicatorLogin.IsRunning = false;


        }
        catch (MySqlException ex)
        {
            // LogFile.Write("#800025 Login", ex.Me ssage);
            await DisplayAlert(AppResource.WarnignCaption, ex.Message, AppResource.OkButton);
            ActiveIndicatorLogin.IsVisible = false;
            ActiveIndicatorLogin.IsRunning = false;
        }
        ConnectionMySQL.Disconnect();


        //tests();
        //count++;

        //if (count == 1)
        //	CounterBtn.Text = $"Clicked {count} time";
        //else
        //	CounterBtn.Text = $"Clicked {data} times";

        //SemanticScreenReader.Announce(CounterBtn.Text);
        //DisplayAlert("Alerta", "Alerta2", "Cancelar");
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
        await Task.Delay(1000);
        await Navigation.PushModalAsync(new HomePage());

    }
}