using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokeList_WebApi.Models
{
    public class SpecialAttack
    {
        public string name { get; set; }
        public string type { get; set; }
        public int damage { get; set; }
    }
}