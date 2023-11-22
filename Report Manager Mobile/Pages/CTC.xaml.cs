using Report_Manager_Mobile.Resources.Languages;

namespace Report_Manager_Mobile.Pages;

public partial class CTC : ContentPage
{
	public CTC()
	{
		InitializeComponent();
	}

    private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
		if(ctc28chck.IsChecked == true){
            Dispatcher.Dispatch(async () =>
            {
                string result = await DisplayPromptAsync("Contato", "Insira o nome do contato da sala de controle", AppResource.OkButton, AppResource.CancelButton, "João das Neves");
                if (result != null && result != string.Empty)
                {
                    EmployeeRadioRoomName.Text = result;
                }
                else
                {
                    ctc28chck.IsChecked = false;
                }

            });
        }
    }
}