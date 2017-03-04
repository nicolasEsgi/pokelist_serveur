using Newtonsoft.Json;
using PokeList_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PokeList_WebApi.Controllers
{
    /// <summary>
    /// Pokemon Position Controller
    /// </summary>
    public class PokemonPositionController : ApiController
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PokemonPositionController()
        {
            if (PokeDB.pokemonsEn == null)
            {
                PokeDB.pokemonsEn = new List<Pokemon>();
                if (PokeDB.pokemonsEn.Count == 0)
                {
                    #region pokeJson Loading
                    PokeDB.pokemonsEn = JsonConvert.DeserializeObject<List<Pokemon>>(PokeDB.pokeJsonEn);
                    #endregion
                }
            }
        }

        // GET api/pokemon/5
        /// <summary>
        /// Get a list of position of pokemon neor the user
        /// </summary>
        /// <param name="longitude">Longitude of the position of the Pokemon</param>
        /// <param name="latitude">Latitude of the position of the Pokemon</param>
        /// <returns>PokemonPosition</returns>
        [HttpGet]
        [Route("api/pokemonPosition/{longitude}/{latitude}")]
        public List<PokemonPosition> Get(string longitude, string latitude)
        {
            longitude = longitude.Replace(',', '.');
            latitude = latitude.Replace(',', '.');
            List<PokemonPosition> positions = new List<PokemonPosition>();
            Random rand = new Random();
            int count = rand.Next(5, 25);

            for(int i = 0; i < count; i++)
            {
                int pokeId = rand.Next(0, 152);
                double lat = 0, lon = 0;
                lat = Convert.ToInt32(latitude.Substring(0, latitude.IndexOf('.'))) + (rand.NextDouble()) / 1000;
                lon = Convert.ToInt32(longitude.Substring(0, longitude.IndexOf('.'))) + rand.NextDouble() / 1000;
                positions.Add(new PokemonPosition(pokeId, lat, lon));
            }
            return positions;
        }
    }
}
