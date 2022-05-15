

using System.Collections.Generic;
using System.Threading.Tasks;
using Layers;

namespace Neo4jDatabase.Abstract
{
    public interface IArastirmaciRepo
    {
        // public void  addArastirmaciAsync(Arastirmaci a);
        public Task ArastirmaciAdd(Arastirmaci a);
        public Task<Arastirmaci> GetArastirmaci(int id);
        public Task<Yayinlar> AramaSonuclari(string ara);
     public  Task<List<Arastirmaci>> SearchResults(string ara);
      public  Task<List<Arastirmaci>> AdaGoreAra(string proper,string ad);
      public Task<List<Yayinlar>> YayinaGoreAra(string ad);
      public  Task<Yayinlar> GetYayinlar(int id);
        public  Task<List<Yayinlar>> TumYayinlar();
        public  Task<List<Yayinlar>> YilaGore(string ad);
     
        
        
    }
}