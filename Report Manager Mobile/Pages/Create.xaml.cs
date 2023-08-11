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

#if ANDROID
using Android.Content;
using Android.OS;
using Java.IO;
#endif

namespace Report_Manager_Mobile.Pages;

public partial class Create : ContentPage
{
    RectangleF TotalPriceCellBounds = RectangleF.Empty;
    RectangleF QuantityCellBounds = RectangleF.Empty;
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
    private void CreatePDF_Click()
    {
        Report.Create();
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
                Body = EditorMail.Text,
                To = contacts,
                Cc = contacts,
                //Bcc = contacts
            };
            var fn = Globals.Costumer + ".pdf";
            var file = Path.Combine(root + "/Reports", fn);


            message.Attachments.Add(new EmailAttachment(file));

            await Email.ComposeAsync(message);
        }
        catch (Exception ex)
        {
            await DisplayAlert(AppResource.WarnignCaption, ex.Message, AppResource.OkButton);
        }

    }
}
