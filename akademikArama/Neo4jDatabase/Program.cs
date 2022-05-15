using Layers;
using Neo4j.Driver;
using Neo4jDatabase.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class DriverIntroductionExample : IDisposable,IMethods
{
    private bool _disposed = false;
    private readonly IDriver _driver;

    ~DriverIntroductionExample() => Dispose(false);

    public DriverIntroductionExample(string uri, string user, string password)
    {
        _driver = GraphDatabase.Driver(uri, AuthTokens.Basic(user, password));
    }


public async Task<List<Arastirmaci>> SearchResults(string ara)
{
var query=@"MATCH (n)-[FRIEND]-(m) WHERE toLower(n.name) CONTAINS toLower($ara) return n,m";
var session = _driver.AsyncSession();
 try
        {
            var readResults = await session.ReadTransactionAsync(async tx =>
            {
                var result = await tx.RunAsync(query, new {ara});
                return (await result.ToListAsync());
            });
            List<INode> persons =new List<INode>();
            List<INode> turs =new List<INode>();
            List<INode> yayins =new List<INode>();
            List<Arastirmaci> reListem = new List<Arastirmaci>();
            //string adi;
            foreach (var result in readResults)
            {
                var p = result["m"].As<INode>();
               
               if(p.Labels[0]=="Tur")
               {
                   turs.Add(p);
                  
               }
               else if (p.Labels[0]=="Person")
               {
                   persons.Add(p);
                   
                   var arastirmaci = await ArastirmaciGetir((int)p.Id);
                   reListem.Add(arastirmaci);
               }
                else if (p.Labels[0]=="Yayinlar")
               {
                   yayins.Add(p);
                  
               }
               
            }
           // return new Yayinlar(){YayinAdi=(string)readResults[0]["n"].As<INode>().Properties["name"],YayinYili=(string)readResults[0]["n"].As<INode>().Properties["yayinYili"],YayinYeri=(string)readResults[0]["n"].As<INode>().Properties["yayinYeri"],nodePerson=persons,nodeTur=turs};
            return reListem;
        }
        // Capture any errors along with the query and data for traceability
        catch (Neo4jException ex)
        {
            Console.WriteLine($"{query} - {ex}");
            throw;
        }
        finally
        {
            await session.CloseAsync();
        }
}
public async Task<Yayinlar> YayinGetir(string ara)
{
var query1 =@"MATCH (n)-[FRIEND]-(m) WHERE n.name = $ara return n,m";
var query=@"MATCH (n)-[FRIEND]-(m) WHERE toLower(n.name) CONTAINS toLower($ara) return n,m";
 var session = _driver.AsyncSession();
 try
        {
            var readResults = await session.ReadTransactionAsync(async tx =>
            {
                var result = await tx.RunAsync(query, new {ara});
                return (await result.ToListAsync());
            });
            List<INode> persons =new List<INode>();
            List<INode> turs =new List<INode>();
            //string adi;
            foreach (var result in readResults)
            {
                var p = result["m"].As<INode>();
               
               if(p.Labels[0]=="Tur")
               {
                   turs.Add(p);
                   
               }
               else if (p.Labels[0]=="Person")
               {
                   persons.Add(p);
                 
               }
            }
           // return new Yayinlar(){YayinAdi=(string)readResults[0]["n"].As<INode>().Properties["name"],YayinYili=(string)readResults[0]["n"].As<INode>().Properties["yayinYili"],YayinYeri=(string)readResults[0]["n"].As<INode>().Properties["yayinYeri"],nodePerson=persons,nodeTur=turs};
            return new Yayinlar(){YayinAdi=(string)readResults[0]["n"].As<INode>().Properties["name"]};
        }
        // Capture any errors along with the query and data for traceability
        catch (Neo4jException ex)
        {
            Console.WriteLine($"{query} - {ex}");
            throw;
        }
        finally
        {
            await session.CloseAsync();
        }
}
public async Task<Arastirmaci> ArastirmaciGetir(int id)
{
    var query1 =@"MATCH (n)-[FRIEND]-(m) WHERE n.name = $ad return n,m";
    var query = @"MATCH (n)-[FRIEND]-(m) WHERE ID(n) = $id return n,m";
    var session = _driver.AsyncSession();
      try
        {
            var readResults = await session.ReadTransactionAsync(async tx =>
            {
                var result = await tx.RunAsync(query, new {id});
                return (await result.ToListAsync());
            });
            List<INode> yayin =new List<INode>();
            List<INode> ortak =new List<INode>();
            //string adi;
            foreach (var result in readResults)
            {
                var p = result["m"].As<INode>();
                 var ben = result["n"].As<INode>();
               //  adi = (string)result["n"].As<INode>().Properties["name"];
                
               // Console.WriteLine($"Found person: {result["n"].As<INode>()}");
               // System.Console.WriteLine("**-->>-- " + result["n.name"].As<String>());
               
               if(p.Labels[0]=="Yayinlar")
               {
                   yayin.Add(p);
               }
               else if (p.Labels[0]=="Person")
               {
                   ortak.Add(p);
               }
            }
            return new Arastirmaci(){Name= (string)readResults[0]["n"].As<INode>().Properties["name"] ,Soyad= (string)readResults[0]["n"].As<INode>().Properties["soyad"],nodeYayinlar=yayin,nodeOrtaklar=ortak,ArastirmaciId= (int)readResults[0]["n"].As<INode>().Id};
        //return new Arastirmaci{Name="golaso"};
        }
        // Capture any errors along with the query and data for traceability
        catch (Neo4jException ex)
        {
            Console.WriteLine($"{query} - {ex}");
            throw;
        }
        finally
        {
            await session.CloseAsync();
        }
}
public async Task Ortakla(string yayinAdi)
{
    var query =@"MATCH (n)-[:yayinYazari]-(m) WHERE n.name = $yayinAdi return m ";
     var session = _driver.AsyncSession();
         try
        {
            // Write transactions allow the driver to handle retries and transient error
            var writeResults = await session.WriteTransactionAsync(async tx =>
            {
                var result = await tx.RunAsync(query, new {yayinAdi});
                return (await result.ToListAsync());
            });
            List<INode> dizi = new List<INode>();
            
            foreach (var result in writeResults)
            {
                var person1 = result["m"].As<INode>().Properties["name"];
                var pkisi=result["m"].As<INode>();
               dizi.Add(pkisi);
               
            }
            for (int i = 0; i <dizi.Count; i++)
            {
                for (int j = 0; j < dizi.Count; j++)
                {
                    if(i==j)
                    {
                        continue;
                    }
                   else{
                        await OrtakCalisirRel(dizi[i].Properties["name"].ToString(),dizi[j].Properties["name"].ToString());
                   }
                }
            }
        }
        // Capture any errors along with the query and data for traceability
        catch (Neo4jException ex)
        {
            Console.WriteLine($"{query} - {ex}");
            throw;
        }
        finally
        {
            await session.CloseAsync();
        }
}
    public async Task AddArastirmaci(string personName,string soyad,string yayin,string yayinYili,string turAdi,string yayinYeri) // tek bir tane ekleyelim
    {
        var query = @"
        MERGE (p1:Person { name: $personName,soyad:$soyad })
        MERGE(y1:Yayinlar{name: $yayin,yayinYili:$yayinYili,yayinYeri:$yayinYeri})
        MERGE(t1:Tur{name:$turAdi})
        MERGE (y1)-[:yayinYazari]->(p1)
        MERGE (y1)-[:Turu]->(t1)
        
        RETURN p1,y1,t1";

         var session = _driver.AsyncSession();
         try
        {
            // Write transactions allow the driver to handle retries and transient error
            var writeResults = await session.WriteTransactionAsync(async tx =>
            {
                var result = await tx.RunAsync(query, new {personName,soyad,yayin,yayinYili,turAdi,yayinYeri});
                return (await result.ToListAsync());
            });

            foreach (var result in writeResults)
            {
                var person1 = result["p1"].As<INode>().Properties["name"];
               
             
            }
            await Ortakla(yayin);
        }
        // Capture any errors along with the query and data for traceability
        catch (Neo4jException ex)
        {
            Console.WriteLine($"{query} - {ex}");
            throw;
        }
        finally
        {
            await session.CloseAsync();
        }
    }
    public async Task OrtakCalisirRel(string person1Name, string person2Name)
    {
        // To learn more about the Cypher syntax, see https://neo4j.com/docs/cypher-manual/current/
        // The Reference Card is also a good resource for keywords https://neo4j.com/docs/cypher-refcard/current/
        var query = @"
        MERGE (p1:Person { name: $person1Name })
        MERGE (p2:Person { name: $person2Name })
        MERGE (p1)-[:ortakCalisir]->(p2)
        MERGE (p2)-[:ortakCalisir]->(p1)
        RETURN p1, p2";

        var session = _driver.AsyncSession();
        try
        {
            // Write transactions allow the driver to handle retries and transient error
            var writeResults = await session.WriteTransactionAsync(async tx =>
            {
                var result = await tx.RunAsync(query, new {person1Name, person2Name});
                return (await result.ToListAsync());
            });

            foreach (var result in writeResults)
            {
                //var person1 = result["p1"].As<INode>().Properties["name"];
                //var person2 = result["p2"].As<INode>().Properties["name"];
                Console.WriteLine("İlişki kuruldu");
            }
        }
        // Capture any errors along with the query and data for traceability
        catch (Neo4jException ex)
        {
            Console.WriteLine($"{query} - {ex}");
            throw;
        }
        finally
        {
            await session.CloseAsync();
        }
    }

    public async Task FindPerson(string personName)
    {
        var query = @"
        MATCH (p:Person)
        WHERE p.name = $name
        RETURN p.name";

        var session = _driver.AsyncSession();
        try
        {
            var readResults = await session.ReadTransactionAsync(async tx =>
            {
                var result = await tx.RunAsync(query, new {name = personName});
                return (await result.ToListAsync());
            });

            foreach (var result in readResults)
            {
                Console.WriteLine($"Found person: {result["p.name"].As<String>()}");
            }
        }
        // Capture any errors along with the query and data for traceability
        catch (Neo4jException ex)
        {
            Console.WriteLine($"{query} - {ex}");
            throw;
        }
        finally
        {
            await session.CloseAsync();
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
            return;

        if (disposing)
        {
            _driver?.Dispose();
        }

        _disposed = true;
    }

    public static async Task Main(string[] args)
    {
        // Aura queries use an encrypted connection using the "neo4j+s" protocol
        var uri = "neo4j+s://cffecb40.databases.neo4j.io:7687";

        var user = "neo4j";
        var password = "BTiC1EmclRs3sYMUQ3LXEnmihiunqKrmuuOqoa379ds";

        using (var example = new DriverIntroductionExample(uri, user, password))
        {
            //await example.CreateFriendship("Alice", "David");
            //await example.FindPerson("Alice");
           // await example.AddArastirmaci("Burcu Savas","Real Time");
           // await example.AddArastirmaci("Yasar Becerikli","Real Time");
            //await example.AddArastirmaci("Ömer","Real Time");
           // await example.Ortakla("Real Time"); // ortakla fonksiyonu  yayın adına göre ortakları getirir ve bunları ortakCalisir ilişkisine çevirir
           //await example.AddArastirmaci("Yaşar","Real Time");
           //await example.AddArastirmaci("Sedef","Real Time");
           //await example.AddArastirmaci("Okan","Real Time");
           //await example.AddArastirmaci("Okan","Mimarlik");
           

        }
    }

    public async Task<List<Arastirmaci>> AdaGoreAra(string proper,string ad)
    {
        var query=@"MATCH (n)-[FRIEND]-(m) WHERE toLower(n.name) CONTAINS toLower($ad) return n,m";
var session = _driver.AsyncSession();
 try
        {
            var readResults = await session.ReadTransactionAsync(async tx =>
            {
                var result = await tx.RunAsync(query, new {proper,ad});
                return (await result.ToListAsync());
            });
            List<INode> persons =new List<INode>();
            List<INode> turs =new List<INode>();
            List<INode> yayins =new List<INode>();
            List<Arastirmaci> reListem = new List<Arastirmaci>();
           var ben = readResults[0]["n"].As<INode>();
            foreach (var result in readResults)
            {
                var p = result["m"].As<INode>();
               
               
            
               
            }
             var arast=   await ArastirmaciGetir((int)ben.Id);
             reListem.Add(arast);
           // return new Yayinlar(){YayinAdi=(string)readResults[0]["n"].As<INode>().Properties["name"],YayinYili=(string)readResults[0]["n"].As<INode>().Properties["yayinYili"],YayinYeri=(string)readResults[0]["n"].As<INode>().Properties["yayinYeri"],nodePerson=persons,nodeTur=turs};
            return reListem;
        }
        // Capture any errors along with the query and data for traceability
        catch (Neo4jException ex)
        {
            Console.WriteLine($"{query} - {ex}");
            throw;
        }
        finally
        {
            await session.CloseAsync();
        }
    }

    public async Task<List<Yayinlar>> YayinaGoreAra(string ad)
    {
             var query=@"MATCH (n:Yayinlar)-[FRIEND]-(m) WHERE toLower(n.name) CONTAINS toLower($ad) return n,m";
var session = _driver.AsyncSession();
 try
        {
            var readResults = await session.ReadTransactionAsync(async tx =>
            {
                var result = await tx.RunAsync(query, new {ad});
                return (await result.ToListAsync());
            });
            List<INode> persons =new List<INode>();
            List<INode> turs =new List<INode>();
            List<INode> yayins =new List<INode>();
            List<Yayinlar> reListem = new List<Yayinlar>();
            //string adi;
            
            
            if(readResults!=null)
            {
                
                foreach (var result in readResults)
            {
                var p = result["m"].As<INode>();
                var ben = result["n"].As<INode>();
                if(p.Labels[0]=="Tur")
               {
                   turs.Add(p);
                   
               }
               else if (p.Labels[0]=="Person")
               {
                   persons.Add(p);
                   
                   
               }
              
             
             var yayin= new Yayinlar(){YayinId= (int)ben.Id,YayinAdi= (string)ben.Properties["name"],YayinYili= (string)ben.Properties["yayinYili"],YayinYeri= (string)ben.Properties["yayinYeri"],nodePerson=persons,nodeTur=turs};
            reListem.Add(yayin);
             
               
            }
           // return new Yayinlar(){YayinAdi=(string)readResults[0]["n"].As<INode>().Properties["name"],YayinYili=(string)readResults[0]["n"].As<INode>().Properties["yayinYili"],YayinYeri=(string)readResults[0]["n"].As<INode>().Properties["yayinYeri"],nodePerson=persons,nodeTur=turs};
             var beni = readResults[0]["n"].As<INode>();
            
            return reListem;
            }
            else{
                var yay=new Yayinlar(){YayinAdi="FAZLA"};
                reListem.Add(yay);
                return reListem;
            }
        }
        // Capture any errors along with the query and data for traceability
        catch (Neo4jException ex)
        {
            Console.WriteLine($"{query} - {ex}");
            throw ;
        }
        finally
        {
            await session.CloseAsync();
        }
    }

    public async Task<Yayinlar> GetYayinlar(int id)
    {
         var query1 =@"MATCH (n)-[FRIEND]-(m) WHERE n.name = $ad return n,m";
    var query = @"MATCH (n)-[FRIEND]-(m) WHERE ID(n) = $id return n,m";
   var session = _driver.AsyncSession();
 try
        {
            var readResults = await session.ReadTransactionAsync(async tx =>
            {
                var result = await tx.RunAsync(query, new {id});
                return (await result.ToListAsync());
            });
            List<INode> persons =new List<INode>();
            List<INode> turs =new List<INode>();
            List<INode> yayins =new List<INode>();
            List<Yayinlar> reListem = new List<Yayinlar>();
            //string adi;
            foreach (var result in readResults)
            {
                var p = result["m"].As<INode>();
                var ben = result["n"].As<INode>();
                if(p.Labels[0]=="Tur")
               {
                   turs.Add(p);
                  
               }
               else if (p.Labels[0]=="Person")
               {
                   persons.Add(p);
                  
                   
               }
              
             
             
               
            }
           // return new Yayinlar(){YayinAdi=(string)readResults[0]["n"].As<INode>().Properties["name"],YayinYili=(string)readResults[0]["n"].As<INode>().Properties["yayinYili"],YayinYeri=(string)readResults[0]["n"].As<INode>().Properties["yayinYeri"],nodePerson=persons,nodeTur=turs};
             var beni = readResults[0]["n"].As<INode>();
             var yayin= new Yayinlar(){YayinId= (int)beni.Id,YayinAdi= (string)beni.Properties["name"],YayinYili= (string)beni.Properties["yayinYili"],YayinYeri= (string)beni.Properties["yayinYeri"],nodePerson=persons,nodeTur=turs};
            
            
            return yayin;
        }
        // Capture any errors along with the query and data for traceability
        catch (Neo4jException ex)
        {
            Console.WriteLine($"{query} - {ex}");
            throw;
        }
        finally
        {
            await session.CloseAsync();
        }
    }

    public async Task<List<Yayinlar>> TumYayinlar()
    {
          var query =@"match(n:Yayinlar) return n";
    var query1 = @"MATCH (n)-[FRIEND]-(m) WHERE ID(n) = $id return n,m";
   var session = _driver.AsyncSession();
 try
        {
            var readResults = await session.ReadTransactionAsync(async tx =>
            {
                var result = await tx.RunAsync(query, new {});
                return (await result.ToListAsync());
            });
            List<INode> persons =new List<INode>();
            List<INode> turs =new List<INode>();
            List<INode> yayins =new List<INode>();
            List<Yayinlar> reListem = new List<Yayinlar>();
            //string adi;
            foreach (var result in readResults)
            {
                var ben = result[0].As<INode>();
              var yayin= new Yayinlar(){YayinId= (int)ben.Id,YayinAdi= (string)ben.Properties["name"],YayinYili= (string)ben.Properties["yayinYili"],YayinYeri= (string)ben.Properties["yayinYeri"]};
             reListem.Add(yayin);
             
               
            }
           // return new Yayinlar(){YayinAdi=(string)readResults[0]["n"].As<INode>().Properties["name"],YayinYili=(string)readResults[0]["n"].As<INode>().Properties["yayinYili"],YayinYeri=(string)readResults[0]["n"].As<INode>().Properties["yayinYeri"],nodePerson=persons,nodeTur=turs};
            // var beni = readResults[0]["n"].As<INode>();
            // var yayin= new Yayinlar(){YayinId= (int)beni.Id,YayinAdi= (string)beni.Properties["name"],YayinYili= (string)beni.Properties["yayinYili"],YayinYeri= (string)beni.Properties["yayinYeri"],nodePerson=persons,nodeTur=turs};
            
            
            return reListem;
        }
        // Capture any errors along with the query and data for traceability
        catch (Neo4jException ex)
        {
            Console.WriteLine($"{query} - {ex}");
            throw;
        }
        finally
        {
            await session.CloseAsync();
        }
    }

    public async Task<List<Yayinlar>> YilaGore(string ad)
    {
        var query=@"MATCH (n:Yayinlar)-[FRIEND]-(m) WHERE toLower(n.yayinYili) CONTAINS toLower($ad) return n,m";
var session = _driver.AsyncSession();
 try
        {
            var readResults = await session.ReadTransactionAsync(async tx =>
            {
                var result = await tx.RunAsync(query, new {ad});
                return (await result.ToListAsync());
            });
            List<INode> persons =new List<INode>();
            List<INode> turs =new List<INode>();
            List<INode> yayins =new List<INode>();
            List<Yayinlar> reListem = new List<Yayinlar>();
            //string adi;
            
            
            if(readResults!=null)
            {
                
                foreach (var result in readResults)
            {
                var p = result["m"].As<INode>();
                var ben = result["n"].As<INode>();
                if(p.Labels[0]=="Tur")
               {
                   turs.Add(p);
                   
               }
               else if (p.Labels[0]=="Person")
               {
                   persons.Add(p);
                   
                   
               }
              
             
             var yayin= new Yayinlar(){YayinId= (int)ben.Id,YayinAdi= (string)ben.Properties["name"],YayinYili= (string)ben.Properties["yayinYili"],YayinYeri= (string)ben.Properties["yayinYeri"],nodePerson=persons,nodeTur=turs};
            reListem.Add(yayin);
             
               
            }
           // return new Yayinlar(){YayinAdi=(string)readResults[0]["n"].As<INode>().Properties["name"],YayinYili=(string)readResults[0]["n"].As<INode>().Properties["yayinYili"],YayinYeri=(string)readResults[0]["n"].As<INode>().Properties["yayinYeri"],nodePerson=persons,nodeTur=turs};
             var beni = readResults[0]["n"].As<INode>();
            
            return reListem;
            }
            else{
                var yay=new Yayinlar(){YayinAdi="FAZLA"};
                reListem.Add(yay);
                return reListem;
            }
        }
        // Capture any errors along with the query and data for traceability
        catch (Neo4jException ex)
        {
            Console.WriteLine($"{query} - {ex}");
            throw ;
        }
        finally
        {
            await session.CloseAsync();
        }
    }
}