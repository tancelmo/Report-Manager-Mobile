using Microsoft.Maui.Controls;
using Report_Manager_Mobile.Data;
using System.Diagnostics;

namespace Report_Manager_Mobile.Pages;

public partial class ARA : ContentPage
{
    
	public ARA()
	{
		InitializeComponent();

        
        Debug.Write("No momento check1 esta como: " +  UserLocalSettings.ARACheck1_1);
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        Report.CreateARA();

        //Report.CreateCTC();
        //Report.CreateRT();
        await Navigation.PushModalAsync(new CTC());
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        checkPreview.IsChecked = !checkPreview.IsChecked;
    }

    private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if(e.Value)
        {
            Preferences.Default.Set("ARAcheck1_1", true);
            UserLocalSettings.ARACheck1_1 = true;
            
        }
        else
        {
            Preferences.Default.Set("ARAcheck1_1", false);
            UserLocalSettings.ARACheck1_1 = false;
        }

    }

    private void CheckBox_CheckedChanged_1(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            Preferences.Default.Set("ARAcheck1_2", true);
            UserLocalSettings.ARACheck1_2 = true;
        }
        else
        {
            Preferences.Default.Set("ARAcheck1_2", false);
            UserLocalSettings.ARACheck1_2 = false;
        }
    }

    private void CheckBox_CheckedChanged_2(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            Preferences.Default.Set("ARAcheck1_3", true);
            UserLocalSettings.ARACheck1_3 = true;
        }
        else
        {
            Preferences.Default.Set("ARAcheck1_3", false);
            UserLocalSettings.ARACheck1_3 = true;
        }
    }

    private void CheckBox_CheckedChanged_3(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            Preferences.Default.Set("ARAcheck1_4", true);
            UserLocalSettings.ARACheck1_4 = true;
        }
        else
        {
            Preferences.Default.Set("ARAcheck1_4", false);
            UserLocalSettings.ARACheck1_4 = false;
        }
    }

    private void CheckBox_CheckedChanged_4(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            Preferences.Default.Set("ARAcheck1_5", true);
            UserLocalSettings.ARACheck1_5 = true;
        }
        else
        {
            Preferences.Default.Set("ARAcheck1_5", false);
            UserLocalSettings.ARACheck1_5 = false;
        }
    }

    private void CheckBox_CheckedChanged_5(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            Preferences.Default.Set("ARAcheck2_1", true);
            UserLocalSettings.ARACheck2_1 = true;
        }
        else
        {
            Preferences.Default.Set("ARAcheck2_1", false);
            UserLocalSettings.ARACheck2_1 = false;
        }
    }

    private void CheckBox_CheckedChanged_6(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            Preferences.Default.Set("ARAcheck2_2", true);
            UserLocalSettings.ARACheck2_2 = true;
        }
        else
        {
            Preferences.Default.Set("ARAcheck2_2", false);
            UserLocalSettings.ARACheck2_2 = false;
        }
    }

    private void CheckBox_CheckedChanged_7(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            Preferences.Default.Set("ARAcheck2_3", true);
            UserLocalSettings.ARACheck2_3 = true;
        }
        else
        {
            Preferences.Default.Set("ARAcheck2_3", false);
            UserLocalSettings.ARACheck2_3 = false;
        }
    }

    private void CheckBox_CheckedChanged_8(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            Preferences.Default.Set("ARAcheck3_1", true);
            UserLocalSettings.ARACheck3_1 = true;
        }
        else
        {
            Preferences.Default.Set("ARAcheck3_1", false);
            UserLocalSettings.ARACheck3_1 = false;
        }
    }

    private void CheckBox_CheckedChanged_9(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            Preferences.Default.Set("ARAcheck3_2", true);
            UserLocalSettings.ARACheck3_2 = true;
        }
        else
        {
            Preferences.Default.Set("ARAcheck3_2", false);
            UserLocalSettings.ARACheck3_2 = false;
        }
    }

    private void CheckBox_CheckedChanged_10(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            Preferences.Default.Set("ARAcheck3_3", true);
            UserLocalSettings.ARACheck3_3 = true;
        }
        else
        {
            Preferences.Default.Set("ARAcheck3_3", false);
            UserLocalSettings.ARACheck3_3 = false;
        }
    }

    private void CheckBox_CheckedChanged_11(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            Preferences.Default.Set("ARAcheck4_1", true);
            UserLocalSettings.ARACheck4_1 = true;
        }
        else
        {
            Preferences.Default.Set("ARAcheck4_1", false);
            UserLocalSettings.ARACheck4_1 = false;
        }
    }

    private void CheckBox_CheckedChanged_12(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            Preferences.Default.Set("ARAcheck4_2", true);
            UserLocalSettings.ARACheck4_2 = true;
        }
        else
        {
            Preferences.Default.Set("ARAcheck4_2", false);
            UserLocalSettings.ARACheck4_2 = false;
        }
    }

    private void CheckBox_CheckedChanged_13(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            Preferences.Default.Set("ARAcheck4_3", true);
            UserLocalSettings.ARACheck4_3 = true;
        }
        else
        {
            Preferences.Default.Set("ARAcheck4_3", false);
            UserLocalSettings.ARACheck4_1 = false;
        }
    }

    private void CheckBox_CheckedChanged_14(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            Preferences.Default.Set("ARAcheck4_4", true);
            UserLocalSettings.ARACheck4_4 = true;
        }
        else
        {
            Preferences.Default.Set("ARAcheck4_4", false);
            UserLocalSettings.ARACheck4_4 = false;
        }
    }

    private void CheckBox_CheckedChanged_15(object sender, CheckedChangedEventArgs e)
    {
       
        if (e.Value)
        {
            Preferences.Default.Set("ARAcheck4_5", true);
            UserLocalSettings.ARACheck4_5 = true;
        }
        else
        {
            Preferences.Default.Set("ARAcheck4_5", false);
            UserLocalSettings.ARACheck4_5 = false;
        }
    }

    private void CheckBox_CheckedChanged_5_1(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            Preferences.Default.Set("ARAcheck5_1", true);
            UserLocalSettings.ARACheck5_1 = true;
        }
        else
        {
            Preferences.Default.Set("ARAcheck5_1", false);
            UserLocalSettings.ARACheck5_1 = false;
        }
    }

    private void CheckBox_CheckedChanged_16(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            Preferences.Default.Set("ARAcheck5_2", true);
            UserLocalSettings.ARACheck5_2 = true;
        }
        else
        {
            Preferences.Default.Set("ARAcheck5_2", false);
            UserLocalSettings.ARACheck5_2 = false;
        }
    }

    private void CheckBox_CheckedChanged_17(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            Preferences.Default.Set("ARAcheck5_3", true);
            UserLocalSettings.ARACheck5_3 = true;
        }
        else
        {
            Preferences.Default.Set("ARAcheck5_3", false);
            UserLocalSettings.ARACheck5_3 = false;
        }
    }

    private void CheckBox_CheckedChanged_18(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            Preferences.Default.Set("ARAcheck5_4", true);
            UserLocalSettings.ARACheck5_4 = true;
        }
        else
        {
            Preferences.Default.Set("ARAcheck5_4", false);
            UserLocalSettings.ARACheck5_4 = false;
        }
    }

    private void CheckBox_CheckedChanged_19(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            Preferences.Default.Set("ARAcheck5_5", true);
            UserLocalSettings.ARACheck5_5 = true;
        }
        else
        {
            Preferences.Default.Set("ARAcheck5_5", false);
            UserLocalSettings.ARACheck5_5 = false;
        }
    }

    private void CheckBox_CheckedChanged_20(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            Preferences.Default.Set("ARAcheck5_6", true);
            UserLocalSettings.ARACheck5_6 = true;
        }
        else
        {
            Preferences.Default.Set("ARAcheck5_6", false);
            UserLocalSettings.ARACheck5_6 = false;
        }
    }

    private void CheckBox_CheckedChanged_21(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            Preferences.Default.Set("ARAcheck6_1", true);
            UserLocalSettings.ARACheck6_1 = true;
        }
        else
        {
            Preferences.Default.Set("ARAcheck6_1", false);
            UserLocalSettings.ARACheck6_1 = false;
        }
    }

    private void CheckBox_CheckedChanged_22(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            Preferences.Default.Set("ARAcheck6_2", true);
            UserLocalSettings.ARACheck6_2 = true;
        }
        else
        {
            Preferences.Default.Set("ARAcheck6_2", false);
            UserLocalSettings.ARACheck6_2 = false;
        }
    }

    private void CheckBox_CheckedChanged_23(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            Preferences.Default.Set("ARAcheck6_3", true);
            UserLocalSettings.ARACheck6_3 = true;
        }
        else
        {
            Preferences.Default.Set("ARAcheck6_3", false);
            UserLocalSettings.ARACheck6_3 = false;
        }
    }

    private void CheckBox_CheckedChanged_24(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            Preferences.Default.Set("ARAcheck6_4", true);
            UserLocalSettings.ARACheck6_4 = true;
        }
        else
        {
            Preferences.Default.Set("ARAcheck6_4", false);
            UserLocalSettings.ARACheck6_4 = false;
        }
    }

    private void CheckBox_CheckedChanged_25(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            Preferences.Default.Set("ARAcheck6_5", true);
            UserLocalSettings.ARACheck6_5 = true;
        }
        else
        {
            Preferences.Default.Set("ARAcheck6_5", false);
            UserLocalSettings.ARACheck6_5 = false;
        }
    }

    private void CheckBox_CheckedChanged_26(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            Preferences.Default.Set("ARAcheck6_6", true);
            UserLocalSettings.ARACheck6_6 = true;
        }
        else
        {
            Preferences.Default.Set("ARAcheck6_6", false);
            UserLocalSettings.ARACheck6_6 = false;
        }
    }

    private void CheckBox_CheckedChanged_27(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            Preferences.Default.Set("ARAcheck6_7", true);
            UserLocalSettings.ARACheck6_7 = true;
        }
        else
        {
            Preferences.Default.Set("ARAcheck6_7", false);
            UserLocalSettings.ARACheck6_7 = false;
        }
    }

    private void CheckBox_CheckedChanged_28(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            Preferences.Default.Set("ARAcheck6_8", true);
            UserLocalSettings.ARACheck6_8 = true;
        }
        else
        {
            Preferences.Default.Set("ARAcheck6_8", false);
            UserLocalSettings.ARACheck6_8 = false;
        }
    }

    private void CheckBox_CheckedChanged_29(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            Preferences.Default.Set("ARAcheck6_9", true);
            UserLocalSettings.ARACheck6_9 = true;
        }
        else
        {
            Preferences.Default.Set("ARAcheck6_9", false);
            UserLocalSettings.ARACheck6_9 = false;
        }
    }

    private void CheckBox_CheckedChanged_30(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            Preferences.Default.Set("ARAcheck7_1", true);
            UserLocalSettings.ARACheck7_1 = true;
        }
        else
        {
            Preferences.Default.Set("ARAcheck7_1", false);
            UserLocalSettings.ARACheck7_1 = false;
        }
    }

    private void CheckBox_CheckedChanged_31(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            Preferences.Default.Set("ARAcheck7_2", true);
            UserLocalSettings.ARACheck7_2 = true;
        }
        else
        {
            Preferences.Default.Set("ARAcheck7_2", false);
            UserLocalSettings.ARACheck7_2 = false;
        }
    }

    private void CheckBox_CheckedChanged_32(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            Preferences.Default.Set("ARAcheck7_3", true);
            UserLocalSettings.ARACheck7_3 = true;
        }
        else
        {
            Preferences.Default.Set("ARAcheck7_3", false);
            UserLocalSettings.ARACheck7_3 = false;
        }
    }

    private void CheckBox_CheckedChanged_33(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            Preferences.Default.Set("ARAcheck7_4", true);
            UserLocalSettings.ARACheck7_4 = true;
        }
        else
        {
            Preferences.Default.Set("ARAcheck7_4", false);
            UserLocalSettings.ARACheck7_4 = false;
        }
    }

    private void CheckBox_CheckedChanged_34(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            Preferences.Default.Set("ARAcheck7_5", true);
            UserLocalSettings.ARACheck7_5 = true;
        }
        else
        {
            Preferences.Default.Set("ARAcheck7_5", false);
            UserLocalSettings.ARACheck7_5 = false;
        }
    }

    private void CheckBox_CheckedChanged_35(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            Preferences.Default.Set("ARAcheck7_6", true);
            UserLocalSettings.ARACheck7_6 = true;
        }
        else
        {
            Preferences.Default.Set("ARAcheck7_6", false);
            UserLocalSettings.ARACheck7_6 = false;
        }
    }

    private void CheckBox_CheckedChanged_36(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            Preferences.Default.Set("ARAcheck7_7", true);
            UserLocalSettings.ARACheck7_7 = true;
        }
        else
        {
            Preferences.Default.Set("ARAcheck7_7", false);
            UserLocalSettings.ARACheck7_7 = false;
        }
    }

    private void CheckBox_CheckedChanged_37(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            Preferences.Default.Set("ARAcheck7_8", true);
            UserLocalSettings.ARACheck7_8 = true;
        }
        else
        {
            Preferences.Default.Set("ARAcheck7_8", false);
            UserLocalSettings.ARACheck7_8 = false;
        }
    }

    private void EditorARA1_TextChanged(object sender, TextChangedEventArgs e)
    {
        Preferences.Default.Set("ARAEditor1", EditorARA1.Text);
        UserLocalSettings.ARAEditor1 = EditorARA1.Text;
    }

    private void EditorARA2_TextChanged(object sender, TextChangedEventArgs e)
    {
        Preferences.Default.Set("ARAEditor2", EditorARA2.Text);
        UserLocalSettings.ARAEditor2 = EditorARA2.Text;
    }

    private void EditorARA3_TextChanged(object sender, TextChangedEventArgs e)
    {
        Preferences.Default.Set("ARAEditor3", EditorARA3.Text);
        UserLocalSettings.ARAEditor3 = EditorARA3.Text;
    }

    private void EditorARA4_TextChanged(object sender, TextChangedEventArgs e)
    {
        Preferences.Default.Set("ARAEditor4", EditorARA4.Text);
        UserLocalSettings.ARAEditor4 = EditorARA4.Text;
    }

    private void EditorARA5_TextChanged(object sender, TextChangedEventArgs e)
    {
        Preferences.Default.Set("ARAEditor5", EditorARA5.Text);
        UserLocalSettings.ARAEditor5 = EditorARA5.Text;
    }

    private void EditorARA6_TextChanged(object sender, TextChangedEventArgs e)
    {
        Preferences.Default.Set("ARAEditor6", EditorARA6.Text);
        UserLocalSettings.ARAEditor6 = EditorARA6.Text;
    }

    private void EditorARA7_TextChanged(object sender, TextChangedEventArgs e)
    {
        Preferences.Default.Set("ARAEditor7", EditorARA7.Text);
        UserLocalSettings.ARAEditor7 = EditorARA7.Text;
    }


    private void checkPreview_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (checkPreview.IsChecked)
        {
            UserLocalSettings.ARAPreview = true;
            Preferences.Default.Set("ARAPreview", true);
        }
        else
        {
            UserLocalSettings.ARAPreview = false;
            Preferences.Default.Set("ARAPreview", false);
        }
            

    }
}