using System.Collections.Generic;
using System.Threading.Tasks;
using demo.Models;
using Layers;
using Microsoft.AspNetCore.Mvc;
using Neo4jDatabase.Concrete;

namespace demo.Controllers
{
    public class SearchController:Controller
    {
        ArastirmaciRepo ara =new ArastirmaciRepo();
       
        public async Task<IActionResult> IndexAsync()
        {
            // var tt=await ara.GetArastirmaci(72);
            // System.Console.WriteLine(tt.ArastirmaciId);
            // //var xx= await ara.AramaSonuclari("Sedef");
            // //System.Console.WriteLine("----> " + xx.YayinAdi);
            // var aras = await ara.SearchResults("a");
            // System.Console.WriteLine(":::::    " + aras[2].Name);
            // var are = await ara.YayinaGoreAra("yazilim");
            List<string> dizim=new List<string>();
            var are = await ara.AdaGoreAra("name","");
            dizim.Add("Gol");
            var model = new AraYayinModel(){ArastListe=are,YayinListe=null,dizi=dizim};
            return View(model);
        }
        public async Task<IActionResult> Profil(int id)
        {
            var getArastirmaci = await ara.GetArastirmaci(id);
            return View(getArastirmaci);
        }


        public async Task<IActionResult> CizgeAsync(int id)
        {
            var getArastirmaci = await ara.GetArastirmaci(id);
            return View(getArastirmaci);
        }
        public IActionResult TumCizge()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> IndexAsync(string arananKelime,string alan)
        {
          
            System.Console.WriteLine("----> : " + alan);
            AraYayinModel models;
            if(alan=="yayin")
            {
                var arex = await ara.YayinaGoreAra(arananKelime);
                var model2= new AraYayinModel(){YayinListe=arex,ArastListe=null};
                models=model2;
                System.Console.WriteLine("bilgi-> " + arex[0].YayinAdi);
               return View(model2);
            }
            else if(alan=="arastirmaci"){
            var are = await ara.AdaGoreAra("name",arananKelime);
             List<string> dizim=new List<string>();
             dizim.Add("Gol");
            var model = new AraYayinModel(){ArastListe=are,YayinListe=null,dizi=dizim};
            models=model;
             return View(model);
            }
            else{
                var arex = await ara.YilaGore(arananKelime);
                var model3= new AraYayinModel(){YayinListe=arex,ArastListe=null};
                models=model3;
                System.Console.WriteLine("bilgi-> " + arex[0].YayinAdi);
               return View(model3);
                
                
            }
            
          
            
            
        }
[HttpPost]
    public IActionResult Profil(string a)
    {   System.Console.WriteLine("----a:: " + a);
        return View();
    }

            
    }
}