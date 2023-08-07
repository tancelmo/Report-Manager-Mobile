using MySqlConnector;
using Report_Manager_Mobile.Data;
using Report_Manager_Mobile.Resources.Languages;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace Report_Manager_Mobile.Pages;

public partial class ServicesPage : ContentPage
{

    public string connectionString = @"Server=172.23.171.65;Database=report_manager;Uid=newuser;Pwd=New@Mic15;SSL Mode=None;AllowPublicKeyRetrieval=true";
   
    public ServicesPage()
	{
		InitializeComponent();

        collectionData.ItemsSource = GetSchedules();


    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushModalAsync(new Create());

        //var contacts = new List<string>();
        //contacts.Add("tadasilv@accellsolutions.com");
        
        //try
        //{
        //    var message = new EmailMessage
        //    {
        //        Subject = "NS 7770022154 INST B14447899 ACCELL SOLUCOES PARA ENERGIA E AGUA",
        //        Body = SearchBar.Text,
        //        To = contacts,
        //        Cc = contacts,
        //        //Bcc = contacts
        //    };
        //    var fn = "Attachment.txt";
        //    var file = Path.Combine(FileSystem.CacheDirectory, fn);
        //    File.WriteAllText(file, "File inside" + SearchBar.Text);

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
        //    await DisplayAlert(AppResource.WarnignCaption, "UE", AppResource.OkButton);
        //    // Some other exception occurred
        //}
    }

    private List<ScheduleData> GetSchedules()
    {

        try
        {
            var query = "select * from schedule";

            var scheduleData1 = new List<ScheduleData>();

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var order = new ScheduleData();

                            order.Facility = reader.GetString(2);
                            order.ServiceNote = "NS 77703322644";
                                order.Costumer = reader.GetString(4);
                            
                                order.Equipment = reader.GetString(7);
                            
                                order.EquipmentSN = reader.GetString(6) + " - " + reader.GetString(5);
                            
                                order.Adress = reader.GetString(12) + " - " + reader.GetString(12) + " - " + reader.GetString(11);
                            

                            scheduleData1.Add(order);

                        }

                    }
                }

                connection.Close();

            }
            Debug.WriteLine("############################### - " + scheduleData1.Count);
            return scheduleData1;
            


        }
        catch (Exception ex)
        {
            Debug.WriteLine("############################### - " + ex.ToString());
            DisplayAlert(AppResource.WarnignCaption, ex.Message, AppResource.OkButton);
            //Loadinglbl.Text = "Failed to loading data.";
            //Loadinglbl.Foreground = new SolidColorBrush(Colors.Red);
            throw;
        }
        //return new List<ScheduleData> 
        //{
        //    new ScheduleData { Costumer = "LUA NOVA IND E COM DE PROD. ALIMENTICIOS", Adress = "R PROF MOACIR SANTOS DE CAMPOS - JARDIM NOVA CALIFORNIA - CAMPINAS - CEP: 13051-094", Equipment = "MED TURBINA G250 400M3/H 4\" FL 150#", EquipmentSN = "CT400 - 3057061", Facility = "637855", ServiceNote = "7771989508"},
        //    new ScheduleData { Costumer = "LUA NOVA IND E COM DE PROD. ALIMENTICIOS", Adress = "R PROF MOACIR SANTOS DE CAMPOS - JARDIM NOVA CALIFORNIA - CAMPINAS - CEP: 13051-094", Equipment = "MED TURBINA G250 400M3/H 4\" FL 150#", EquipmentSN = "CT400 - 3057061", Facility = "637855", ServiceNote = "7771989508"},
        //    new ScheduleData { Costumer = "LUA NOVA IND E COM DE PROD. ALIMENTICIOS", Adress = "R PROF MOACIR SANTOS DE CAMPOS - JARDIM NOVA CALIFORNIA - CAMPINAS - CEP: 13051-094", Equipment = "MED TURBINA G250 400M3/H 4\" FL 150#", EquipmentSN = "CT400 - 3057061", Facility = "637855", ServiceNote = "7771989508"},
        //    new ScheduleData { Costumer = "LUA NOVA IND E COM DE PROD. ALIMENTICIOS", Adress = "R PROF MOACIR SANTOS DE CAMPOS - JARDIM NOVA CALIFORNIA - CAMPINAS - CEP: 13051-094", Equipment = "MED TURBINA G250 400M3/H 4\" FL 150#", EquipmentSN = "CT400 - 3057061", Facility = "637855", ServiceNote = "7771989508"},
        //    new ScheduleData { Costumer = "LUA NOVA IND E COM DE PROD. ALIMENTICIOS", Adress = "R PROF MOACIR SANTOS DE CAMPOS - JARDIM NOVA CALIFORNIA - CAMPINAS - CEP: 13051-094", Equipment = "MED TURBINA G250 400M3/H 4\" FL 150#", EquipmentSN = "CT400 - 3057061", Facility = "637855", ServiceNote = "7771989508"},
        //    new ScheduleData { Costumer = "LUA NOVA IND E COM DE PROD. ALIMENTICIOS", Adress = "R PROF MOACIR SANTOS DE CAMPOS - JARDIM NOVA CALIFORNIA - CAMPINAS - CEP: 13051-094", Equipment = "MED TURBINA G250 400M3/H 4\" FL 150#", EquipmentSN = "CT400 - 3057061", Facility = "637855", ServiceNote = "7771989508"},
        //    new ScheduleData { Costumer = "LUA NOVA IND E COM DE PROD. ALIMENTICIOS", Adress = "R PROF MOACIR SANTOS DE CAMPOS - JARDIM NOVA CALIFORNIA - CAMPINAS - CEP: 13051-094", Equipment = "MED TURBINA G250 400M3/H 4\" FL 150#", EquipmentSN = "CT400 - 3057061", Facility = "637855", ServiceNote = "7771989508"},
        //    new ScheduleData { Costumer = "LUA NOVA IND E COM DE PROD. ALIMENTICIOS", Adress = "R PROF MOACIR SANTOS DE CAMPOS - JARDIM NOVA CALIFORNIA - CAMPINAS - CEP: 13051-094", Equipment = "MED TURBINA G250 400M3/H 4\" FL 150#", EquipmentSN = "CT400 - 3057061", Facility = "637855", ServiceNote = "7771989508"},
        //    new ScheduleData { Costumer = "LUA NOVA IND E COM DE PROD. ALIMENTICIOS", Adress = "R PROF MOACIR SANTOS DE CAMPOS - JARDIM NOVA CALIFORNIA - CAMPINAS - CEP: 13051-094", Equipment = "MED TURBINA G250 400M3/H 4\" FL 150#", EquipmentSN = "CT400 - 3057061", Facility = "637855", ServiceNote = "7771989508"},
        //    new ScheduleData { Costumer = "LUA NOVA IND E COM DE PROD. ALIMENTICIOS", Adress = "R PROF MOACIR SANTOS DE CAMPOS - JARDIM NOVA CALIFORNIA - CAMPINAS - CEP: 13051-094", Equipment = "MED TURBINA G250 400M3/H 4\" FL 150#", EquipmentSN = "CT400 - 3057061", Facility = "637855", ServiceNote = "7771989508"},
        //    new ScheduleData { Costumer = "LUA NOVA IND E COM DE PROD. ALIMENTICIOS", Adress = "R PROF MOACIR SANTOS DE CAMPOS - JARDIM NOVA CALIFORNIA - CAMPINAS - CEP: 13051-094", Equipment = "MED TURBINA G250 400M3/H 4\" FL 150#", EquipmentSN = "CT400 - 3057061", Facility = "637855", ServiceNote = "7771989508"},
        //    new ScheduleData { Costumer = "LUA NOVA IND E COM DE PROD. ALIMENTICIOS", Adress = "R PROF MOACIR SANTOS DE CAMPOS - JARDIM NOVA CALIFORNIA - CAMPINAS - CEP: 13051-094", Equipment = "MED TURBINA G250 400M3/H 4\" FL 150#", EquipmentSN = "CT400 - 3057061", Facility = "637855", ServiceNote = "7771989508"},
        //    new ScheduleData { Costumer = "LUA NOVA IND E COM DE PROD. ALIMENTICIOS", Adress = "R PROF MOACIR SANTOS DE CAMPOS - JARDIM NOVA CALIFORNIA - CAMPINAS - CEP: 13051-094", Equipment = "MED TURBINA G250 400M3/H 4\" FL 150#", EquipmentSN = "CT400 - 3057061", Facility = "637855", ServiceNote = "7771989508"},
        //    new ScheduleData { Costumer = "LUA NOVA IND E COM DE PROD. ALIMENTICIOS", Adress = "R PROF MOACIR SANTOS DE CAMPOS - JARDIM NOVA CALIFORNIA - CAMPINAS - CEP: 13051-094", Equipment = "MED TURBINA G250 400M3/H 4\" FL 150#", EquipmentSN = "CT400 - 3057061", Facility = "637855", ServiceNote = "7771989508"},
        //    new ScheduleData { Costumer = "LUA NOVA IND E COM DE PROD. ALIMENTICIOS", Adress = "R PROF MOACIR SANTOS DE CAMPOS - JARDIM NOVA CALIFORNIA - CAMPINAS - CEP: 13051-094", Equipment = "MED TURBINA G250 400M3/H 4\" FL 150#", EquipmentSN = "CT400 - 3057061", Facility = "637855", ServiceNote = "7771989508"},
        //    new ScheduleData { Costumer = "LUA NOVA IND E COM DE PROD. ALIMENTICIOS", Adress = "R PROF MOACIR SANTOS DE CAMPOS - JARDIM NOVA CALIFORNIA - CAMPINAS - CEP: 13051-094", Equipment = "MED TURBINA G250 400M3/H 4\" FL 150#", EquipmentSN = "CT400 - 3057061", Facility = "637855", ServiceNote = "7771989508"},
        //    new ScheduleData { Costumer = "LUA NOVA IND E COM DE PROD. ALIMENTICIOS", Adress = "R PROF MOACIR SANTOS DE CAMPOS - JARDIM NOVA CALIFORNIA - CAMPINAS - CEP: 13051-094", Equipment = "MED TURBINA G250 400M3/H 4\" FL 150#", EquipmentSN = "CT400 - 3057061", Facility = "637855", ServiceNote = "7771989508"},
        //    new ScheduleData { Costumer = "LUA NOVA IND E COM DE PROD. ALIMENTICIOS", Adress = "R PROF MOACIR SANTOS DE CAMPOS - JARDIM NOVA CALIFORNIA - CAMPINAS - CEP: 13051-094", Equipment = "MED TURBINA G250 400M3/H 4\" FL 150#", EquipmentSN = "CT400 - 3057061", Facility = "637855", ServiceNote = "7771989508"},
        //    new ScheduleData { Costumer = "LUA NOVA IND E COM DE PROD. ALIMENTICIOS", Adress = "R PROF MOACIR SANTOS DE CAMPOS - JARDIM NOVA CALIFORNIA - CAMPINAS - CEP: 13051-094", Equipment = "MED TURBINA G250 400M3/H 4\" FL 150#", EquipmentSN = "CT400 - 3057061", Facility = "637855", ServiceNote = "7771989508"},
        //    new ScheduleData { Costumer = "LUA NOVA IND E COM DE PROD. ALIMENTICIOS", Adress = "R PROF MOACIR SANTOS DE CAMPOS - JARDIM NOVA CALIFORNIA - CAMPINAS - CEP: 13051-094", Equipment = "MED TURBINA G250 400M3/H 4\" FL 150#", EquipmentSN = "CT400 - 3057061", Facility = "637855", ServiceNote = "7771989508"},
        //    new ScheduleData { Costumer = "LUA NOVA IND E COM DE PROD. ALIMENTICIOS", Adress = "R PROF MOACIR SANTOS DE CAMPOS - JARDIM NOVA CALIFORNIA - CAMPINAS - CEP: 13051-094", Equipment = "MED TURBINA G250 400M3/H 4\" FL 150#", EquipmentSN = "CT400 - 3057061", Facility = "637855", ServiceNote = "7771989508"},
        //    new ScheduleData { Costumer = "LUA NOVA IND E COM DE PROD. ALIMENTICIOS", Adress = "R PROF MOACIR SANTOS DE CAMPOS - JARDIM NOVA CALIFORNIA - CAMPINAS - CEP: 13051-094", Equipment = "MED TURBINA G250 400M3/H 4\" FL 150#", EquipmentSN = "CT400 - 3057061", Facility = "637855", ServiceNote = "7771989508"},
        //    new ScheduleData { Costumer = "LUA NOVA IND E COM DE PROD. ALIMENTICIOS", Adress = "R PROF MOACIR SANTOS DE CAMPOS - JARDIM NOVA CALIFORNIA - CAMPINAS - CEP: 13051-094", Equipment = "MED TURBINA G250 400M3/H 4\" FL 150#", EquipmentSN = "CT400 - 3057061", Facility = "637855", ServiceNote = "7771989508"},
        //    new ScheduleData { Costumer = "LUA NOVA IND E COM DE PROD. ALIMENTICIOS", Adress = "R PROF MOACIR SANTOS DE CAMPOS - JARDIM NOVA CALIFORNIA - CAMPINAS - CEP: 13051-094", Equipment = "MED TURBINA G250 400M3/H 4\" FL 150#", EquipmentSN = "CT400 - 3057061", Facility = "637855", ServiceNote = "7771989508"},
        //    new ScheduleData { Costumer = "LUA NOVA IND E COM DE PROD. ALIMENTICIOS", Adress = "R PROF MOACIR SANTOS DE CAMPOS - JARDIM NOVA CALIFORNIA - CAMPINAS - CEP: 13051-094", Equipment = "MED TURBINA G250 400M3/H 4\" FL 150#", EquipmentSN = "CT400 - 3057061", Facility = "637855", ServiceNote = "7771989508"},
        //    new ScheduleData { Costumer = "LUA NOVA IND E COM DE PROD. ALIMENTICIOS", Adress = "R PROF MOACIR SANTOS DE CAMPOS - JARDIM NOVA CALIFORNIA - CAMPINAS - CEP: 13051-094", Equipment = "MED TURBINA G250 400M3/H 4\" FL 150#", EquipmentSN = "CT400 - 3057061", Facility = "637855", ServiceNote = "7771989508"},
        //    new ScheduleData { Costumer = "LUA NOVA IND E COM DE PROD. ALIMENTICIOS", Adress = "R PROF MOACIR SANTOS DE CAMPOS - JARDIM NOVA CALIFORNIA - CAMPINAS - CEP: 13051-094", Equipment = "MED TURBINA G250 400M3/H 4\" FL 150#", EquipmentSN = "CT400 - 3057061", Facility = "637855", ServiceNote = "7771989508"},
        //    new ScheduleData { Costumer = "LUA NOVA IND E COM DE PROD. ALIMENTICIOS", Adress = "R PROF MOACIR SANTOS DE CAMPOS - JARDIM NOVA CALIFORNIA - CAMPINAS - CEP: 13051-094", Equipment = "MED TURBINA G250 400M3/H 4\" FL 150#", EquipmentSN = "CT400 - 3057061", Facility = "637855", ServiceNote = "7771989508"},
        //    new ScheduleData { Costumer = "LUA NOVA IND E COM DE PROD. ALIMENTICIOS", Adress = "R PROF MOACIR SANTOS DE CAMPOS - JARDIM NOVA CALIFORNIA - CAMPINAS - CEP: 13051-094", Equipment = "MED TURBINA G250 400M3/H 4\" FL 150#", EquipmentSN = "CT400 - 3057061", Facility = "637855", ServiceNote = "7771989508"},
        //    new ScheduleData { Costumer = "LUA NOVA IND E COM DE PROD. ALIMENTICIOS", Adress = "R PROF MOACIR SANTOS DE CAMPOS - JARDIM NOVA CALIFORNIA - CAMPINAS - CEP: 13051-094", Equipment = "MED TURBINA G250 400M3/H 4\" FL 150#", EquipmentSN = "CT400 - 3057061", Facility = "637855", ServiceNote = "7771989508"},
        //    new ScheduleData { Costumer = "LUA NOVA IND E COM DE PROD. ALIMENTICIOS", Adress = "R PROF MOACIR SANTOS DE CAMPOS - JARDIM NOVA CALIFORNIA - CAMPINAS - CEP: 13051-094", Equipment = "MED TURBINA G250 400M3/H 4\" FL 150#", EquipmentSN = "CT400 - 3057061", Facility = "637855", ServiceNote = "7771989508"},
        //    new ScheduleData { Costumer = "LUA NOVA IND E COM DE PROD. ALIMENTICIOS", Adress = "R PROF MOACIR SANTOS DE CAMPOS - JARDIM NOVA CALIFORNIA - CAMPINAS - CEP: 13051-094", Equipment = "MED TURBINA G250 400M3/H 4\" FL 150#", EquipmentSN = "CT400 - 3057061", Facility = "637855", ServiceNote = "7771989508"},
        //    new ScheduleData { Costumer = "LUA NOVA IND E COM DE PROD. ALIMENTICIOS", Adress = "R PROF MOACIR SANTOS DE CAMPOS - JARDIM NOVA CALIFORNIA - CAMPINAS - CEP: 13051-094", Equipment = "MED TURBINA G250 400M3/H 4\" FL 150#", EquipmentSN = "CT400 - 3057061", Facility = "637855", ServiceNote = "7771989508"},
        //    new ScheduleData { Costumer = "LUA NOVA IND E COM DE PROD. ALIMENTICIOS", Adress = "R PROF MOACIR SANTOS DE CAMPOS - JARDIM NOVA CALIFORNIA - CAMPINAS - CEP: 13051-094", Equipment = "MED TURBINA G250 400M3/H 4\" FL 150#", EquipmentSN = "CT400 - 3057061", Facility = "637855", ServiceNote = "7771989508"},
        //    new ScheduleData { Costumer = "LUA NOVA IND E COM DE PROD. ALIMENTICIOS", Adress = "R PROF MOACIR SANTOS DE CAMPOS - JARDIM NOVA CALIFORNIA - CAMPINAS - CEP: 13051-094", Equipment = "MED TURBINA G250 400M3/H 4\" FL 150#", EquipmentSN = "CT400 - 3057061", Facility = "637855", ServiceNote = "7771989508"},
        //    new ScheduleData { Costumer = "LUA NOVA IND E COM DE PROD. ALIMENTICIOS", Adress = "R PROF MOACIR SANTOS DE CAMPOS - JARDIM NOVA CALIFORNIA - CAMPINAS - CEP: 13051-094", Equipment = "MED TURBINA G250 400M3/H 4\" FL 150#", EquipmentSN = "CT400 - 3057061", Facility = "637855", ServiceNote = "7771989508"},
        //    new ScheduleData { Costumer = "LUA NOVA IND E COM DE PROD. ALIMENTICIOS", Adress = "R PROF MOACIR SANTOS DE CAMPOS - JARDIM NOVA CALIFORNIA - CAMPINAS - CEP: 13051-094", Equipment = "MED TURBINA G250 400M3/H 4\" FL 150#", EquipmentSN = "CT400 - 3057061", Facility = "637855", ServiceNote = "7771989508"},
        //    new ScheduleData { Costumer = "LUA NOVA IND E COM DE PROD. ALIMENTICIOS", Adress = "R PROF MOACIR SANTOS DE CAMPOS - JARDIM NOVA CALIFORNIA - CAMPINAS - CEP: 13051-094", Equipment = "MED TURBINA G250 400M3/H 4\" FL 150#", EquipmentSN = "CT400 - 3057061", Facility = "637855", ServiceNote = "7771989508"},
        //    new ScheduleData { Costumer = "LUA NOVA IND E COM DE PROD. ALIMENTICIOS", Adress = "R PROF MOACIR SANTOS DE CAMPOS - JARDIM NOVA CALIFORNIA - CAMPINAS - CEP: 13051-094", Equipment = "MED TURBINA G250 400M3/H 4\" FL 150#", EquipmentSN = "CT400 - 3057061", Facility = "637855", ServiceNote = "7771989508"},
        //    new ScheduleData { Costumer = "LUA NOVA IND E COM DE PROD. ALIMENTICIOS", Adress = "R PROF MOACIR SANTOS DE CAMPOS - JARDIM NOVA CALIFORNIA - CAMPINAS - CEP: 13051-094", Equipment = "MED TURBINA G250 400M3/H 4\" FL 150#", EquipmentSN = "CT400 - 3057061", Facility = "637855", ServiceNote = "7771989508"},
        //    new ScheduleData { Costumer = "LUA NOVA IND E COM DE PROD. ALIMENTICIOS", Adress = "R PROF MOACIR SANTOS DE CAMPOS - JARDIM NOVA CALIFORNIA - CAMPINAS - CEP: 13051-094", Equipment = "MED TURBINA G250 400M3/H 4\" FL 150#", EquipmentSN = "CT400 - 3057061", Facility = "637855", ServiceNote = "7771989508"},
        //};

    }

    private void collectionData_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ScheduleData Data = e.CurrentSelection[0] as ScheduleData;
        Debug.WriteLine(Data.Costumer);
        
    }
}