using System.Collections.Generic;
using Layers;

namespace demo.Models
{
    public class AraYayinModel
    {
        public List<Arastirmaci>ArastListe { get; set; }
        public List<Yayinlar>YayinListe { get; set; }
        public Arastirmaci ArasTek{ get; set; }
        public Yayinlar YayTek{ get; set; }
        public List<string> dizi { get; set; }
    }
}