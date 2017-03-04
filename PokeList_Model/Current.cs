using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace PokeList_Model
{
    public static class Current
    {
        public static Pokemon pokemon { get; set; }
        public static HttpClient client { get; set; }
    }
}
