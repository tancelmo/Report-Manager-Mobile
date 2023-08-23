using Report_Manager_Mobile.Data;
using Report_Manager_Mobile.Resources.Languages;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Report_Manager_Mobile.Services;
using Syncfusion.Pdf.Grid;
using Syncfusion.Drawing;
using PointF = Syncfusion.Drawing.PointF;
using SizeF = Syncfusion.Drawing.SizeF;
using Color = Syncfusion.Drawing.Color;
using System.Reflection;
using System.Net;

#if ANDROID
using Android.Content;
using Android.OS;
using Java.IO;
#endif

namespace Report_Manager_Mobile.Pages;

public partial class Create : ContentPage
{

    public Create()
    {
        InitializeComponent();

        FacilityEntry.Text = Globals.Facility;
        SNEntry.Text = Globals.ServiceNote;
        CostumerEntry.Text = Globals.Costumer;
        EquipmentEntry.Text = Globals.Equipment;
        MeterSNEntry.Text = Globals.EquipmentSN;
        AdressEntry.Text = Globals.Adress;
        TypePicker.SelectedItem = Globals.EquipmentType;
        UserLocalSettings.GetUserSettings(Preferences.Default.Get("LastSettings", false));
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        //var contacts = new List<string>();
        //contacts.Add("tadasilv@accellsolutions.com");

        //try
        //{
        //    var message = new EmailMessage
        //    {
        //        Subject = Globals.Costumer + " INST " + Globals.Facility + " NS" + Globals.ServiceNote,
        //        Body = EditorMail.Text,
        //        To = contacts,
        //        Cc = contacts,
        //        //Bcc = contacts
        //    };
        //    var fn = "Attachment.txt";
        //    var file = Path.Combine(FileSystem.CacheDirectory, fn);
        //    File.WriteAllText(file, "File inside" + EditorMail.Text);

        //    message.Attachments.Add(new EmailAttachment(file));

        //    await Email.ComposeAsync(message);

        //}
        //catch (FeatureNotSupportedException fbsEx)
        //{
        //    // Email is not supported on this device
        //    await DisplayAlert(AppResource.WarnignCaption, fbsEx.Message, AppResource.OkButton);
        //    Debug.WriteLine(fbsEx);
        //}
        //catch (Exception ex)
        //{
        //    await DisplayAlert(AppResource.WarnignCaption, ex.Message + "UE", AppResource.OkButton);
        //    // Some other exception occurred
        //}
        CreatePDF_Click();

    }
    private async void CreatePDF_Click()
    {
        
        await Navigation.PushModalAsync(new ARA());
        //Report.Create();
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
        var contacts = new List<string>();
        contacts.Add("tadasilv@accellsolutions.com");


        try
        {
            var message = new EmailMessage
            {
                Subject = Globals.Costumer + " INST " + Globals.Facility + " NS" + Globals.ServiceNote,
                Body = Globals.Costumer + "\n" + " INST " + Globals.Facility + "\n" + " NS" + Globals.ServiceNote,
                To = contacts,
                Cc = contacts,
                //Bcc = contacts
            };
            var fn = ("INST" + Globals.Facility + "_NS" + Globals.ServiceNote + "_" + Globals.Costumer + ".pdf").Replace(" ","_");
            var file = Path.Combine(root + "/Reports/", "ARA_" + fn);
            var file2 = Path.Combine(root + "/Reports/", "CTC_" + fn);
            var file3 = Path.Combine(root + "/Reports/", "RT_" + fn);


            message.Attachments.Add(new EmailAttachment(file));
            message.Attachments.Add(new EmailAttachment(file2));
            message.Attachments.Add(new EmailAttachment(file3));

            await Email.ComposeAsync(message);
        }
        catch (Exception ex)
        {
            await DisplayAlert(AppResource.WarnignCaption, ex.Message, AppResource.OkButton);
        }

    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        //SaveCredentialsCheckbx.IsChecked = !SaveCredentialsCheckbx.IsChecked;
        

    }
}
