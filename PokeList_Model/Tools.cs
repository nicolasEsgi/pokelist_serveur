using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeList_Model
{
    class Tools
    {
        /// Retourne le type anglais correspondant au type
        /// passer en paramètre
        public static string getEnTypesForString(string typeStr)
        {
            if (typeStr == "Bug" || typeStr == "Insect")
            {
                return "Bug";
            }
            else if (typeStr == "Dragon")
            {
                return "Dragon";
            }
            else if (typeStr == "Electric" || typeStr == "Electr")
            {
                return "Electric";
            }
            else if (typeStr == "Fairy" || typeStr == "Fee")
            {
                return "Fairy";
            }
            else if (typeStr == "Fighting" || typeStr == "Combat")
            {
                return "Fighting";
            }
            else if (typeStr == "Fire" || typeStr == "Feu")
            {
                return "Fire";
            }
            else if (typeStr == "Fly" || typeStr == "Vol")
            {
                return "Fly";
            }
            else if (typeStr == "Ghost" || typeStr == "Spectr")
            {
                return "Ghost";
            }
            else if (typeStr == "Grass" || typeStr == "Plante")
            {
                return "Grass";
            }
            else if (typeStr == "Ground" || typeStr == "Sol")
            {
                return "Ground";
            }
            else if (typeStr == "Ice" || typeStr == "Glace")
            {
                return "Ice";
            }
            else if (typeStr == "Normal")
            {
                return "Normal";
            }
            else if (typeStr == "Poison")
            {
                return "Poison";
            }
            else if (typeStr == "Psychic" || typeStr == "Psy")
            {
                return "Psychic";
            }
            else if (typeStr == "Rock" || typeStr == "Roche")
            {
                return "Rock";
            }
            else if (typeStr == "Water" || typeStr == "Eau")
            {
                return "Water";
            }
            return "";
        }
    }
}
