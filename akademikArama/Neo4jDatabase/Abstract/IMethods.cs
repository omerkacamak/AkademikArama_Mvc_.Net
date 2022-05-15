using System.Collections.Generic;
using System.Threading.Tasks;
using Layers;

namespace Neo4jDatabase.Abstract
{
    public interface IMethods
    {
         public  Task<List<Arastirmaci>>AdaGoreAra(string ad,string proper);
         public Task<List<Yayinlar>> YayinaGoreAra(string ad);
         public Task<Yayinlar> GetYayinlar (int id);
         public Task<List<Yayinlar>> TumYayinlar();
         public  Task<List<Yayinlar>> YilaGore(string ad);
    }
}