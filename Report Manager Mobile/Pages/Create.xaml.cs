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

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new ARA());

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

        List<string> mailTo = UserLocalSettings.MailList.Split(';').ToList();
        List<string> ccTo = UserLocalSettings.CcMailList.Split(';').ToList();
        //mailTo = "tadasilv@accellsolutions.com;morspi@accellsolutions.com;hmello@accellsolutions.com;jou@accellsolutions.com;rriboli@accellsolutions.com".Split(';').ToList();
        

        try
        {
            var message = new EmailMessage
            {
                Subject = Globals.Costumer + " INST " + Globals.Facility + " NS" + Globals.ServiceNote,
                Body = Globals.Costumer + "\n" + " INST " + Globals.Facility + "\n" + " NS" + Globals.ServiceNote,
                To = mailTo,
                Cc = ccTo,
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

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        List<string> workList = new();
        workList.Add(AppResource.Work1);
        workList.Add(AppResource.Work2);
        workList.Add(AppResource.Work3);
        workList.Add(AppResource.Work4);
        WorkPicker.ItemsSource = workList;
        WorkPicker.SelectedIndex = 0;
        Globals.Work = WorkPicker.SelectedItem.ToString();
    }

    private void WorkPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        Globals.Work = WorkPicker.SelectedItem.ToString();
    }
}
