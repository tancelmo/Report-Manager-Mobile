using MySqlConnector;
using Report_Manager_Mobile.Data;
using Report_Manager_Mobile.Helpers;
using Report_Manager_Mobile.Resources.Languages;
using System.Diagnostics;

namespace Report_Manager_Mobile.Pages;

public partial class ServicesPage : ContentPage
{
    List<ScheduleData> schedules;
    public ServicesPage()
	{
		InitializeComponent();

        

    }


    private List<ScheduleData> GetSchedules()
    {
        try
        {
            var query = "select * from schedule";

            var scheduleData = new List<ScheduleData>();

            using (var connection = new MySqlConnection(Globals.connectionString))
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
                            order.ServiceNote = "7771994543";
                            order.Costumer = reader.GetString(4);
                            order.Equipment = reader.GetString(7);
                            order.EquipmentSN = reader.GetString(5);
                            order.EquipmentType = reader.GetString(6);
                            order.Adress = reader.GetString(22).ToString() + " - " + reader.GetString(12) + " - " + reader.GetString(11);

                            scheduleData.Add(order);

                        }

                    }
                }

                connection.Close();

            }
            return scheduleData;
            


        }
        catch (Exception ex)
        {
            DisplayAlert(AppResource.WarnignCaption, "#70002 - Could not connect to server", AppResource.OkButton);
            
            Debug.WriteLine("70001############################### - " + ex.ToString());
            LogFile.Write("#70002", ex.ToString());
            //Loadinglbl.Text = "Failed to loading data.";
            //Loadinglbl.Foreground = new SolidColorBrush(Colors.Red);
            return null;

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

    private async void collectionData_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ScheduleData Data = e.CurrentSelection[0] as ScheduleData;
        Globals.Costumer = Data.Costumer;
        Globals.Adress = Data.Adress;
        Globals.Equipment = Data.Equipment;
        Globals.ServiceNote = Data.ServiceNote;
        Globals.EquipmentType = Data.EquipmentType;
        Globals.EquipmentSN = Data.EquipmentSN;
        Globals.Facility = Data.Facility;

        await Navigation.PushModalAsync(new Create());        
    }

    private void Search_TextChanged(object sender, TextChangedEventArgs e)
    {
        var filteredList = schedules.Where(a => a.Facility.Contains(e.NewTextValue));
        collectionData.ItemsSource = filteredList;
        SearchBox.Focus();
    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        try
        {
            schedules = GetSchedules();
            collectionData.ItemsSource = schedules;
        }
        catch (Exception ex)
        {
            LogFile.Write("#70002", ex.Message);
            throw;
        }
    }
}