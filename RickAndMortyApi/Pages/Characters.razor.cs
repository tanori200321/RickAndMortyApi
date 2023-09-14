using Microsoft.AspNetCore.Components;
using RickAndMortyApi.Models;

namespace RickAndMortyApi.Pages
{
    public partial class Characters
    {
        private List<Character> characters = new List<Character>();
        private bool showTable = false;
        private bool showCharacterDetails = false;
        private int selectedCharacterId;
        private string selectedGenderFilter = "All";

        [Inject] NavigationManager NavigationManager { get; set; } = null!;

        protected override async Task OnInitializedAsync()
        {
            await LoadCharactersAsync();
        }

        private async Task LoadCharactersAsync()
        {
            var response = await Http.GetAsync("https://rickandmortyapi.com/api/character");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiResponse>(json);
                characters = result?.Results;
            }
            else
            {
                characters = new List<Character>();
            }
        }

        private void ShowInformation()
        {
            showTable = true;
        }

        private void HideInformation()
        {
            showTable = false;
            HideCharacterDetails();
        }

        private void ShowCharacterDetails(int characterId)
        {
            selectedCharacterId = characterId;
            showCharacterDetails = true;
        }

        private void HideCharacterDetails()
        {
            showCharacterDetails = false;
        }

        private void SetGenderFilter(ChangeEventArgs e)
        {
            selectedGenderFilter = e.Value.ToString();
        }

        public class ApiResponse
        {
            public List<Character>? Results { get; set; }
        }
    }
}
