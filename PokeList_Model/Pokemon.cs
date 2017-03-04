using System;
using System.Collections.Generic;
using System.Linq;

namespace PokeList_Model
{
    public class Pokemon
    {
        private static string baseImgUrl
        {
            get
            {
                return "http://jeyaksan-rajaratnam.esy.es/webapp/pokelist/assets";
            }
        }
        public string number { get; set; }
        public string name { get; set; }
        public string classification { get; set; }
        public List<string> types { get; set; }
        public string typesStr
        {
            get
            {
                string typesStr_ = "";
                if (types.Count > 0)
                {
                    return this.type1 + ", " + this.type2;
                }
                else
                {
                    return "---";
                }
            }
        }
        public string type1
        {
            get
            {
                if (types != null && types.Count > 0)
                {
                    return types[0];
                }
                else
                {
                    return "---";
                }
            }
        }
        public string type2
        {
            get
            {
                if (types.Count > 1)
                {
                    return types[1];
                }
                else
                {
                    return "---";
                }
            }
        }
        public List<string> resistant { get; set; }
        public List<string> weaknesses { get; set; }
        public List<FastAttack> fastAttacks { get; set; }
        public List<SpecialAttack> specialAttacks { get; set; }
        public Weight weight { get; set; }
        public Height height { get; set; }
        public double fleeRate { get; set; }
        public NextEvolutionRequirements nextEvolutionRequirements { get; set; }
        public List<NextEvolution> nextEvolutions { get; set; }
        public List<PreviousEvolution> previousEvolutions { get; set; }
        public int maxCP { get; set; }
        public int maxHP { get; set; }
        public string spriteSource {
            get
            {
                return baseImgUrl + "/sprites/" + Convert.ToInt32(number).ToString() + ".png";
            }
        }
        public string imageSource
        {
            get
            {
                return baseImgUrl + "/" + Convert.ToInt32(number).ToString() + ".png";
            }
        }

        public string bgImageSource
        {
            get
            {
                return "/Assets/PokeTypes_BG/BG" + Tools.getEnTypesForString(this.type1) + ".png";
            }
        }
    }
}