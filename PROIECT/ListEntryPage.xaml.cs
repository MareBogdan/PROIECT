using System;
using PROIECT.Models;

namespace PROIECT
{
    public partial class ListEntryPage : ContentPage
    {
        public ListEntryPage()
        {
            InitializeComponent();
        }

        // Se execută când pagina apare
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            // Populează ListView cu lista de jucători din baza de date
            listView.ItemsSource = await App.Database.GetPlayersAsync();
        }

        // Adaugă un nou jucător
        async void OnPlayerAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PlayerPage
            {
                BindingContext = new Player() // Creează un obiect Player nou
            });
        }

        // Selectează un jucător pentru editare
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                // Navighează la PlayerPage pentru editarea jucătorului selectat
                await Navigation.PushAsync(new PlayerPage
                {
                    BindingContext = e.SelectedItem as Player
                });

                // Deselectează elementul după selectare
                listView.SelectedItem = null;
            }
        }
    }
}
