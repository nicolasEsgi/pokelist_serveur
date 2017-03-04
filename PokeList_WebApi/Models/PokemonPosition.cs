using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokeList_WebApi.Models
{
    /// <summary>
    /// Pokemon position data
    /// </summary>
    public class PokemonPosition
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="number">Id of Pokemon (Exemple : 25 is the id of Pikachu</param>
        /// <param name="latitude">Latitude of the position of the Pokemon</param>
        /// <param name="longitude">Longitude of the position of the Pokemon</param>
        public PokemonPosition(int number, double latitude, double longitude)
        {
            this.number = number;
            this.latitude = latitude;
            this.longitude = longitude;
        }
        /// <summary>
        /// Id (or number) of the Pokemon
        /// </summary>
        public int number { get; set; }
        /// <summary>
        /// Latitude of the position of the Pokemon
        /// </summary>
        public double latitude { get; set; }
        /// <summary>
        /// Latitude of the position of the Pokemon
        /// </summary>
        public double longitude { get; set; }
    }
}