using System;
using PROIECT.Models;

namespace PROIECT
{
    public partial class PlayerPage : ContentPage
    {
        public PlayerPage()
        {
            InitializeComponent();
        }

        // Constructor care primește un obiect de tip Player
        public PlayerPage(Player player)
        {
            InitializeComponent();
            BindingContext = player;
        }

        // Butonul Save - Salvează sau actualizează un jucător
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var player = (Player)BindingContext;

            if (string.IsNullOrWhiteSpace(player.FirstName) || string.IsNullOrWhiteSpace(player.LastName))
            {
                await DisplayAlert("Error", "First Name and Last Name are required.", "OK");
                return;
            }

            await App.Database.SavePlayerAsync(player);
            await DisplayAlert("Success", "Player saved successfully.", "OK");
            await Navigation.PopAsync();
        }

        // Butonul Delete - Șterge un jucător
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var player = (Player)BindingContext;

            if (player != null && player.PlayerId != 0)
            {
                bool confirm = await DisplayAlert("Confirm Delete", "Are you sure you want to delete this player?", "Yes", "No");

                if (confirm)
                {
                    await App.Database.DeletePlayerAsync(player);
                    await DisplayAlert("Success", "Player deleted successfully.", "OK");
                    await Navigation.PopAsync();
                }
            }
            else
            {
                await DisplayAlert("Error", "Cannot delete player. No valid ID.", "OK");
            }
        }
    }
}
