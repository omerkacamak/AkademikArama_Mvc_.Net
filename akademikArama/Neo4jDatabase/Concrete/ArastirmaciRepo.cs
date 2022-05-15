using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Layers;
using Neo4jDatabase.Abstract;

namespace Neo4jDatabase.Concrete
{
    public class ArastirmaciRepo : IArastirmaciRepo
    {
      private readonly string password,user,uri; 
      DriverIntroductionExample neo;

        public ArastirmaciRepo()
        {
            uri = "neo4j+s://cffecb40.databases.neo4j.io:7687";
            user = "neo4j";
            password = "BTiC1EmclRs3sYMUQ3LXEnmihiunqKrmuuOqoa379ds";
            neo=new DriverIntroductionExample(uri, user, password);
        }

        public async Task<List<Arastirmaci>> AdaGoreAra(string proper, string ad)
        {
            return await neo.AdaGoreAra(proper,ad);
        }

        public async Task<Yayinlar> AramaSonuclari(string ara)
        {
              return await neo.YayinGetir(ara);
        }

        public async Task ArastirmaciAdd(Arastirmaci a)
        {
          await neo.AddArastirmaci(a.Name,a.Soyad,a.Yayinlars.YayinAdi,a.Yayinlars.YayinYili,a.Yayinlars.Turs.TurAdi,a.Yayinlars.YayinYeri);
        }

        public async Task<Arastirmaci> GetArastirmaci(int id)
        {
           return await neo.ArastirmaciGetir(id);
        }

        public async Task<Yayinlar> GetYayinlar(int id)
        {
            return await neo.GetYayinlar(id);
        }

        public async Task<List<Arastirmaci>> SearchResults(string ara)
        {
            return await neo.SearchResults(ara);
        }

        public async Task<List<Yayinlar>> TumYayinlar()
        {
           return await neo.TumYayinlar();
        }

        public async Task<List<Yayinlar>> YayinaGoreAra(string ad)
        {
            return await neo.YayinaGoreAra(ad);
        }

        public async Task<List<Yayinlar>> YilaGore(string ad)
        {
            return await neo.YilaGore(ad);
        }
    }
}