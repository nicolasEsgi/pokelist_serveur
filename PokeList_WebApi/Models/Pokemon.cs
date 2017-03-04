using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokeList_WebApi.Models
{
    /// <summary>
    /// Pokemon's Data
    /// </summary>
    public class Pokemon
    {
        /// <summary>
        /// Id (or number) of the Pokemon
        /// </summary>
        public string number { get; set; }
        /// <summary>
        /// Name of the Pokemon
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Description of the Pokemon
        /// </summary>
        public string classification { get; set; }
        /// <summary>
        /// Types of the Pokemon
        /// </summary>
        public List<string> types { get; set; }
        /// <summary>
        /// Resistant of the Pokemon
        /// </summary>
        public List<string> resistant { get; set; }
        /// <summary>
        /// Weaknesses of the Pokemon
        /// </summary>
        public List<string> weaknesses { get; set; }
        /// <summary>
        /// List of FastAttacks of the Pokemon
        /// </summary>
        public List<FastAttack> fastAttacks { get; set; }
        /// <summary>
        /// List of SpecialAttacks of the Pokemon
        /// </summary>
        public List<SpecialAttack> specialAttacks { get; set; }
        /// <summary>
        /// Weight of the Pokemon
        /// </summary>
        public Weight weight { get; set; }
        /// <summary>
        /// Height of the Pokemon
        /// </summary>
        public Height height { get; set; }
        /// <summary>
        /// Flee Rate of the Pokemon
        /// </summary>
        public double fleeRate { get; set; }
        /// <summary>
        /// Next Evolution Requirements
        /// </summary>
        public NextEvolutionRequirements nextEvolutionRequirements { get; set; }
        /// <summary>
        /// List of Next Evolution of the Pokemon
        /// </summary>
        public List<NextEvolution> nextEvolutions { get; set; }
        /// <summary>
        /// List of Previous Evolution of the Pokemon
        /// </summary>
        public List<PreviousEvolution> previousEvolutions { get; set; }
        /// <summary>
        /// Max CP of the Pokemon
        /// </summary>
        public int maxCP { get; set; }
        /// <summary>
        /// Max HP of the Pokemon
        /// </summary>
        public int maxHP { get; set; }
    }
}