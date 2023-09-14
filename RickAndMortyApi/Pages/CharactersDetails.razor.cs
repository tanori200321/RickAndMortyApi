using Microsoft.AspNetCore.Components;
using RickAndMortyApi.Models;


namespace RickAndMortyApi.Pages
{
    public partial class CharactersDetails
    {
        private Character character;

        [Parameter]
        public int CharacterId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadCharacterAsync();
        }

        private async Task LoadCharacterAsync()
        {
            var response = await Http.GetAsync($"https://rickandmortyapi.com/api/character/{CharacterId}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                character = Newtonsoft.Json.JsonConvert.DeserializeObject<Character>(json);
            }
            else
            {
                character = null;
            }
        }

    }
}
