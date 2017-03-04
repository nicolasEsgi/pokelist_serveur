using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.Web.Http;
using Windows.Foundation;
using Newtonsoft;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Globalization;

namespace PokeList_Model
{
    public static class PokeDataLayer
    {
        private static string language_;
        public static string language
        {
            set
            {
                language_ = value;
            }
            get
            {
                if (string.IsNullOrEmpty(language_))
                {
                    return CultureInfo.CurrentUICulture.Name.Substring(0, 2);
                }
                else
                {
                    return language_;
                }
            }
        }
        const string baseApiUrl = "http://pokelist.azurewebsites.net/api";
        const string baseImageUrl = "http://jeyaksan-rajaratnam.esy.es/webapp/pokelist/assets";
        public async static Task getAllPokemon(ObservableCollection<Pokemon> list)
        {
            List<Pokemon> tmpList;
            HttpClient client = new HttpClient();
            IAsyncOperationWithProgress<HttpResponseMessage, HttpProgress> response = client.GetAsync(new Uri(baseApiUrl + "/pokemon" + language));
            IAsyncOperationWithProgress<string, ulong> jsonResponse = (await response).Content.ReadAsStringAsync();
            tmpList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Pokemon>>(await jsonResponse);
            foreach(Pokemon pokemon in tmpList)
            {
                if(pokemon != null)
                {
                    list.Add(pokemon);
                }
            }
        }

        public async static Task getPokemonFamiliy(int id, List<Pokemon> list)
        {
            HttpClient client = new HttpClient();
            IAsyncOperationWithProgress<HttpResponseMessage, HttpProgress> response = client.GetAsync(new Uri(baseApiUrl + "/pokemonFamily" + language + "/" + id));
            IAsyncOperationWithProgress<string, ulong> jsonResponse = (await response).Content.ReadAsStringAsync();
            list.AddRange(JsonConvert.DeserializeObject<List<Pokemon>>(await jsonResponse));
        }
    }
}
