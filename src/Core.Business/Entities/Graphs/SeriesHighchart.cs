using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Business.Entities
{
    public class SeriesHighchart
    {
        public SeriesHighchart()
        {
            data = new List<double?>();
        }
        public string name { get; set; }
        public List<double?> data { set; get; }

        
    }
}
