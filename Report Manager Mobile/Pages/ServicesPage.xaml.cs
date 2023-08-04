using Report_Manager_Mobile.Resources.Languages;
using System.Diagnostics;

namespace Report_Manager_Mobile.Pages;

public partial class ServicesPage : ContentPage
{
	public ServicesPage()
	{
		InitializeComponent();
	}

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {

        var contacts = new List<string>();
        contacts.Add("tadasilv@accellsolutions.com");
        
        try
        {
            var message = new EmailMessage
            {
                Subject = "NS 7770022154 INST B14447899 ACCELL SOLUCOES PARA ENERGIA E AGUA",
                Body = SearchBar.Text,
                To = contacts,
                Cc = contacts,
                //Bcc = contacts
            };
            var fn = "Attachment.txt";
            var file = Path.Combine(FileSystem.CacheDirectory, fn);
            File.WriteAllText(file, "File inside" + SearchBar.Text);

            message.Attachments.Add(new EmailAttachment(file));

            await Email.ComposeAsync(message);
            
        }
        catch (FeatureNotSupportedException fbsEx)
        {
            // Email is not supported on this device
            await DisplayAlert(AppResource.WarnignCaption, fbsEx.Message, AppResource.OkButton);
            Debug.WriteLine(fbsEx);
        }
        catch (Exception ex)
        {
            await DisplayAlert(AppResource.WarnignCaption, "UE", AppResource.OkButton);
            // Some other exception occurred
        }
    }
}