﻿using Newtonsoft.Json;
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
    /// Pokemon Family (Pokemon + Next and Previous Evolution) (Fr version)
    /// </summary>
    public class PokemonFamilyFrController : ApiController
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PokemonFamilyFrController()
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

        // GET api/pokemonAttack
        /// <summary>
        /// Return the pokemon and it's next and previous Evolution
        /// </summary>
        /// <returns>List of Pokemon</returns>
        public List<Pokemon> Get(int id)
        {
            List<Pokemon> family = new List<Pokemon>();
            Pokemon currentPokemon = PokeDB.pokemonsFr.Where(p => Convert.ToInt32(p.number) == id).First();

            if (currentPokemon.previousEvolutions != null)
            {
                Pokemon tmpPokemon = currentPokemon;
                foreach (PreviousEvolution previousEvol in currentPokemon.previousEvolutions)
                {
                    Pokemon pokemon = PokeDB.pokemonsFr.Where(p => Convert.ToInt32(p.number) == Convert.ToInt32(previousEvol.number)).First();
                    family.Add(pokemon);
                }
            }
            family.Add(currentPokemon);
            if (currentPokemon.nextEvolutions != null)
            {
                foreach (NextEvolution nextEvol in currentPokemon.nextEvolutions)
                {
                    Pokemon pokemon = PokeDB.pokemonsFr.Where(p => Convert.ToInt32(p.number) == Convert.ToInt32(nextEvol.number)).First();
                    family.Add(pokemon);
                }
            }
            return family;
        }

        /// <summary>
        /// Return the id of pokemon and it's next and previous Evolution ids
        /// </summary>
        /// <param name="id">Id of Pokemon (Exemple : 25 is the id of Pikachu</param>
        /// <returns></returns>
        [ActionName("ids")]
        [Route("api/pokemonFamilyFr/ids/{id}")]
        public List<int> GetIds(int id)
        {
            List<int> family = new List<int>();
            Pokemon currentPokemon = PokeDB.pokemonsFr.Where(p => Convert.ToInt32(p.number) == id).First();

            if (currentPokemon.previousEvolutions != null)
            {
                Pokemon tmpPokemon = currentPokemon;
                foreach (PreviousEvolution previousEvol in currentPokemon.previousEvolutions)
                {
                    Pokemon pokemon = PokeDB.pokemonsFr.Where(p => Convert.ToInt32(p.number) == Convert.ToInt32(previousEvol.number)).First();
                    family.Add(Convert.ToInt32(pokemon.number));
                }
            }
            family.Add(Convert.ToInt32(currentPokemon.number));
            if (currentPokemon.nextEvolutions != null)
            {
                foreach (NextEvolution nextEvol in currentPokemon.nextEvolutions)
                {
                    Pokemon pokemon = PokeDB.pokemonsFr.Where(p => Convert.ToInt32(p.number) == Convert.ToInt32(nextEvol.number)).First();
                    family.Add(Convert.ToInt32(pokemon.number));
                }
            }
            return family;
        }
    }
}
