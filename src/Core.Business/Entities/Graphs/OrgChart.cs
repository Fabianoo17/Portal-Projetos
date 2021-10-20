using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business.Entities.Graphs
{
    public class OrgChart
    {
        public OrgChart()
        {
            Nodes = new List<Nodes>();
            data = new List<Data>();
        }

        public List<Nodes> Nodes { get; set; }
        public List<Data> data { get; set; }


        public class Data
        {
         public string pai { get; set; }
            public string filho { get; set; }



        } 
    }
}
