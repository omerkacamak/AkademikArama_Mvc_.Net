using System.Collections.Generic;
using Neo4j.Driver;

namespace Layers
{
    public class Yayinlar
    {
        public int YayinId { get; set; }
        public string YayinAdi { get; set; }
        public string YayinYili { get; set; }
         public string YayinYeri { get; set; }
          public List<INode> nodePerson { get; set; }
            public List<INode> nodeTur { get; set; }
        public int TurId { get; set; }
        public Tur Turs { get; set; }
    }
}