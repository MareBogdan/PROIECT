using System;
using PROIECT.Models;
using PROIECT.Data;

namespace PROIECT
{
    public partial class TeamPage : ContentPage
    {
        private Team Team { get; set; }

        public TeamPage() : this(new Team())
        {
        }

        public TeamPage(Team team)
        {
            InitializeComponent(); // Verifică existența fișierului generat corect
            Team = team ?? new Team();
            BindingContext = Team;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (Team != null && Team.TeamId != 0)
            {
                Team.Players = await App.Database.GetPlayersByTeamIdAsync(Team.TeamId);
                listView.ItemsSource = Team.Players; // Asigură-te că listView este definit în XAML
            }
        }

        private async void OnSaveTeamClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Team.Name))
            {
                await DisplayAlert("Error", "Team Name is required.", "OK");
                return;
            }

            await App.Database.SaveTeamAsync(Team);
            await DisplayAlert("Success", "Team saved successfully.", "OK");
            await Navigation.PopAsync();
        }

        private async void OnDeleteTeamClicked(object sender, EventArgs e)
        {
            if (Team.TeamId == 0)
            {
                await DisplayAlert("Error", "This team cannot be deleted.", "OK");
                return;
            }

            bool confirm = await DisplayAlert("Confirm", "Are you sure you want to delete this team?", "Yes", "No");
            if (confirm)
            {
                await App.Database.DeleteTeamAsync(Team);
                await DisplayAlert("Success", "Team deleted successfully.", "OK");
                await Navigation.PopAsync();
            }
        }

        private async void OnAddPlayerClicked(object sender, EventArgs e)
        {
            if (Team.TeamId == 0)
            {
                bool saveBeforeAdd = await DisplayAlert("Error", "Please save the team before adding players.", "Save Now", "Cancel");
                if (!saveBeforeAdd) return;

                await App.Database.SaveTeamAsync(Team);
                await DisplayAlert("Success", "Team saved successfully.", "OK");
            }

            var newPlayer = new Player { TeamId = Team.TeamId };
            await Navigation.PushAsync(new PlayerPage(newPlayer));
        }
    }
}
