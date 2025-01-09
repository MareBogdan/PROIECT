namespace PROIECT;

public partial class AboutPage : ContentPage
{
	public AboutPage()
	{
		InitializeComponent();
	}
    private async void OnDeleteDatabaseClicked(object sender, EventArgs e)
    {
        bool confirm = await DisplayAlert("Confirm Reset", "Are you sure you want to delete the database? This action cannot be undone.", "Yes", "No");
        if (confirm)
        {
            try
            {
                // Apelează metoda de ștergere
                await App.Database.DeleteDatabaseAsync();

                // Afișează un mesaj de succes
                await DisplayAlert("Success", "Database has been reset. Please restart the application.", "OK");
            }
            catch (Exception ex)
            {
                // În caz de eroare, afișează un mesaj
                await DisplayAlert("Error", $"Failed to delete database: {ex.Message}", "OK");
            }
        }
    }


}