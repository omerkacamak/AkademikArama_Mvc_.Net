using System.Collections.Generic;
using Neo4j.Driver;

namespace Layers
{
    public class Arastirmaci
    {
        public int ArastirmaciId { get; set; }
        public string Name { get; set; }
        public string Soyad { get; set; }
        public string yayinAdi { get; set; }
        public List<INode> nodeYayinlar { get; set; } // tüm yayinlarini buraya çeker
        public List<INode> nodeOrtaklar { get; set; } // tüm ortak çalıştıklarını buraya çeker
        public int YayinId { get; set; }
        public Yayinlar Yayinlars { get; set; }

    }
}