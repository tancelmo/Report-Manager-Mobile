using Report_Manager_Mobile.Data;
using Report_Manager_Mobile.Resources.Languages;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.Diagnostics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Drawing;
using System.Reflection;
using System.Xml.Linq;
using Color = Syncfusion.Drawing.Color;
using PointF = Syncfusion.Drawing.PointF;
using SizeF = Syncfusion.Drawing.SizeF;
using Report_Manager_Mobile.Services;

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

    }

    private async void Button_Clicked(object sender, EventArgs e)
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
        //Create a new PDF document.
        PdfDocument document = new PdfDocument();

        //Add a page to the document.
        PdfPage page = document.Pages.Add();

        //Create PDF graphics for the page.
        PdfGraphics graphics = page.Graphics;

        //Set font. 
        PdfStandardFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

        //Draw string. 
        graphics.DrawString(Globals.Costumer + "\n" + Globals.Equipment, font, PdfBrushes.Olive, new Syncfusion.Drawing.PointF(10, 10));

        //Saves the PDF to the memory stream.
        using MemoryStream ms = new();
        document.Save(ms);

        //Close the PDF document
        document.Close(true);
        //ms.Position = 0;

        //Saves the memory stream as file.
        SaveService saveService = new();
        saveService.SaveAndView(Globals.Costumer + ".pdf", "application/pdf", ms);

        

        
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        string root = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
        Debug.WriteLine(FileSystem.Current.AppDataDirectory);
        Debug.WriteLine(root + "/RPMANAGER");

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
        }catch(Exception ex)
        {
            await DisplayAlert(AppResource.WarnignCaption, ex.Message, AppResource.OkButton);
        }
        
    }
}
