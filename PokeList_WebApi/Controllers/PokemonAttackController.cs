using PokeList_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PokeList_WebApi.Controllers
{
    public class PokemonAttackController : ApiController
    {
        public PokemonAttackController()
        {
            if (PokeDB.pokemonsEn == null)
            {
                PokeDB.pokemonsEn = new List<Pokemon>();
                if (PokeDB.pokemonsEn.Count == 0)
                {
                    #region pokeJson Loading
                    PokeDB.pokemonsEn = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Pokemon>>(PokeDB.pokeJsonEn);
                    #endregion
                }
            }
        }

        // GET api/pokemonAttack
        /// <summary>
        /// Return all pokemon attacks name
        /// </summary>
        /// <returns>List of attacks name</returns>
        public List<string> Get()
        {
            var attacks = new List<string>();
            var sourcesFastAttacks = PokeDB.pokemonsEn.Select(p => p.fastAttacks.Select(t => t.name)).Distinct();
            var sourcesSpecialAttacks = PokeDB.pokemonsEn.Select(p => p.specialAttacks.Select(t => t.name)).Distinct();
            var sourceAttack = sourcesFastAttacks.Union(sourcesSpecialAttacks).Distinct();
            foreach (IEnumerable<string> listOfAttacks in sourceAttack)
            {
                foreach (string attack in listOfAttacks)
                {
                    if (!String.IsNullOrEmpty(attack))
                    {
                        attacks.Add(attack);
                    }
                }
            }
            attacks.Sort();
            attacks = attacks.Distinct().ToList();
            return attacks;
        }
    }
}
