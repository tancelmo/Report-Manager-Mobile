using Microsoft.Maui.ApplicationModel.Communication;
using Report_Manager_Mobile.Data;
using Report_Manager_Mobile.Resources.Languages;
using System;

namespace Report_Manager_Mobile.Pages;

public partial class Settings : ContentPage
{
	public Settings()
	{
		InitializeComponent(); 
		

    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        
        EntryServerIP.Text = Globals.serverAdress;
        LblVersion.Text = AppInfo.Current.Name + " © 2023 Ver. " + AppInfo.Current.VersionString + "." + AppInfo.Current.BuildString;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        string result = await DisplayPromptAsync("Insert new Adress", "Enter new Server Adress", AppResource.OkButton, AppResource.CancelButton, "accellsolutions.com");
        if (result != null)
        {
            await SecureStorage.Default.SetAsync("serverAdress", result);
            EntryServerIP.Text = result;
        }
        
        
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        string root = null;

#if ANDROID
        
        if (Android.OS.Environment.IsExternalStorageEmulated)
        {
            root = Android.App.Application.Context!.GetExternalFilesDir(Android.OS.Environment.DirectoryDownloads)!.AbsolutePath;
        }
        else
            root = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
        
#endif
        List<string> contacts = new ();
        contacts.Add("tadasilv@accellsolutions.com");
        var message = new EmailMessage
        {
            Subject = "LogReport_Exception_AccellReportManagerMobile Version_" + AppInfo.Current.VersionString + "." + AppInfo.Current.BuildString + "_" + DateTime.Now,
            Body = "Log",
            To = contacts,
            Cc = contacts,
            //Bcc = contacts
        };
        
        var file = Path.Combine(root + "/Log", "Log.txt");


        message.Attachments.Add(new EmailAttachment(file));

        await Email.ComposeAsync(message);
    }

    private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
       
        if (e.Value)
        {
            Preferences.Default.Set("LastSettings", true);

        }
        else
        {
            Preferences.Default.Set("LastSettings", false);
        }
        
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Presets.IsChecked = !Presets.IsChecked;
    }

    private void MailTo_TextChanged(object sender, TextChangedEventArgs e)
    {
        Preferences.Default.Set("MailList", MailTo.Text);
        UserLocalSettings.MailList = MailTo.Text;
        
    }

    private void CcMailTo_TextChanged(object sender, TextChangedEventArgs e)
    {
        Preferences.Default.Set("CcMailList", CcMailTo.Text);
        UserLocalSettings.CcMailList = CcMailTo.Text;
    }
}