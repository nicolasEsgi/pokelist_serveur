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
    /// PokemonController (French version)
    /// </summary>
    public class PokemonFrController : ApiController
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PokemonFrController()
        {
            if (PokeDB.pokemonsFr == null)
            {
                PokeDB.pokemonsFr = new List<Pokemon>();
                if (PokeDB.pokemonsFr.Count == 0)
                {
                    #region pokeJson Loading
                    PokeDB.pokemonsFr = JsonConvert.DeserializeObject<List<Pokemon>>(PokeDB.pokeJsonFr);
                    #endregion
                }
            }
        }
        // GET api/pokemon
        /// <summary>
        /// Return all pokemons
        /// </summary>
        /// <returns>List of Pokemons</returns>
        public List<Pokemon> Get()
        {
            return PokeDB.pokemonsFr;
        }

        // GET api/pokemon/5
        /// <summary>
        /// Get the pokemon for matching id
        /// </summary>
        /// <param name="id">Id of Pokemon (Exemple : 25 is the id of Pikachu)</param>
        /// <returns></returns>
        public Pokemon Get(int id)
        {
            Pokemon pokemon = null;
            pokemon = PokeDB.pokemonsFr.Where(p => Convert.ToInt32(p.number) == id).FirstOrDefault();
            return pokemon;
        }

        // GET api/pokemon/search/Bul
        /// <summary>
        /// Get the pokemon for the name starting with search pattern 
        /// </summary>
        /// <param name="name">Name of Pokemon (Exemple : Pikachu)</param>
        /// <returns></returns>
        [ActionName("search")]
        public IEnumerable<Pokemon> GetPokemonByName(string name)
        {
            int pokemonId = 0;
            IEnumerable<Pokemon> pokemons;
            if (!String.IsNullOrEmpty(name))
            {
                if (int.TryParse(name, out pokemonId))
                {
                    pokemons = PokeDB.pokemonsFr.Where(p => Convert.ToInt32(p.number) == pokemonId);
                }
                else
                {
                    pokemons = PokeDB.pokemonsFr.Where(p => p.name.ToLowerInvariant().StartsWith(name.ToLowerInvariant()));
                }
                return pokemons.OrderBy(pokemon => pokemon.name);
            }
            return null;
        }

        // GET api/pokemon/search/Bul
        /// <summary>
        /// Get the pokemon for the name starting with search pattern and types
        /// </summary>
        /// <param name="name">Name of Pokemon (Exemple : Pikachu)</param>
        /// <param name="type1">First type of the Pokemon (Exemple : Fire)</param>
        /// <param name="type2">Second type of the Pokemon (Exemple : Flying)</param>
        /// <returns>List of Pokemons</returns>
        [HttpGet]
        [ActionName("search")]
        [Route("api/pokemon/search/{name}/{type1}/{type2}")]
        public IEnumerable<Pokemon> searchPokemon(string name, string type1, string type2)
        {
            int pokemonId = 0;
            IEnumerable<Pokemon> pokemons;
            if (!String.IsNullOrEmpty(name))
            {
                if (int.TryParse(name, out pokemonId))
                {
                    pokemons = PokeDB.pokemonsFr.Where(p => Convert.ToInt32(p.number) == pokemonId && p.types.Contains(type1) && p.types.Contains(type2));
                }
                else
                {
                    pokemons = PokeDB.pokemonsFr.Where(p => p.name.ToLowerInvariant().StartsWith(name.ToLowerInvariant()) && p.types.Contains(type1) && p.types.Contains(type2));
                }
                return pokemons.OrderBy(pokemon => pokemon.name);
            }
            return null;
        }

        // GET api/pokemon/byType/Feu
        /// <summary>
        /// Get the pokemons by types
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [ActionName("byType")]
        public IEnumerable<Pokemon> GetPokemonByType(string name)
        {
            var pokemons = PokeDB.pokemonsFr.Where(p => p.types.Contains(FirstCharToUpper(name))).ToList<Pokemon>();
            return pokemons;
        }

        /// <summary>
        /// Capitalize
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("ARGH!");
            return input.First().ToString().ToUpper() + input.Substring(1);
        }
    }
}