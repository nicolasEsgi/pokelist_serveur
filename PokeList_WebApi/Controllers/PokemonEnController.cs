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
    /// PokemonController (English version)
    /// </summary>
    public class PokemonEnController : ApiController
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PokemonEnController()
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
        // GET api/pokemon
        /// <summary>
        /// Return all pokemons
        /// </summary>
        /// <returns>List of Pokemons</returns>
        public List<Pokemon> Get()
        {
            return PokeDB.pokemonsEn;
        }

        // GET api/pokemon/5
        /// <summary>
        /// Get the pokemon for matching id
        /// </summary>
        /// <param name="id">Id of Pokemon (Exemple : 25 is the id of Pikachu</param>
        /// <returns>Pokemon</returns>
        public Pokemon Get(int id)
        {
            Pokemon pokemon = null;
            pokemon = PokeDB.pokemonsEn.Where(p => Convert.ToInt32(p.number) == id).FirstOrDefault();
            return pokemon;
        }

        // GET api/pokemon/search/Bul
        /// <summary>
        /// Get the pokemon for the name starting with search pattern 
        /// </summary>
        /// <param name="name"></param>
        /// <returns>List of Pokemons</returns>
        [ActionName("search")]
        public IEnumerable<Pokemon> GetPokemonByName(string name)
        {
            int pokemonId = 0;
            IEnumerable<Pokemon> pokemons;
            if (!String.IsNullOrEmpty(name))
            {
                if (int.TryParse(name, out pokemonId))
                {
                    pokemons = PokeDB.pokemonsEn.Where(p => Convert.ToInt32(p.number) == pokemonId);
                }
                else
                {
                    pokemons = PokeDB.pokemonsEn.Where(p => p.name.ToLowerInvariant().StartsWith(name.ToLowerInvariant()));
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
                    pokemons = PokeDB.pokemonsEn.Where(p => Convert.ToInt32(p.number) == pokemonId && p.types.Contains(type1) && p.types.Contains(type2));
                }
                else
                {
                    pokemons = PokeDB.pokemonsEn.Where(p => p.name.ToLowerInvariant().StartsWith(name.ToLowerInvariant()) && p.types.Contains(type1) && p.types.Contains(type2));
                }
                return pokemons.OrderBy(pokemon => pokemon.name);
            }
            return null;
        }

        // GET api/pokemon/byType/Fire
        /// <summary>
        /// Get the pokemons by types
        /// </summary>
        /// <param name="name">Name of Pokemon (Exemple : Pikachu)</param>
        /// <returns>List of Pokemons</returns>
        [ActionName("byType")]
        public IEnumerable<Pokemon> GetPokemonByType(string name)
        {
            var pokemons = PokeDB.pokemonsEn.Where(p => p.types.Contains(FirstCharToUpper(name))).ToList<Pokemon>();
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
