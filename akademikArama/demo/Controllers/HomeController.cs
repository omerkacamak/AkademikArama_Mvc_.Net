using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using demo.Models;
using Layers;
using Neo4jDatabase.Concrete;

namespace demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
    //          var uri = "neo4j+s://cffecb40.databases.neo4j.io:7687";

    //     var user = "neo4j";
    //     var password = "BTiC1EmclRs3sYMUQ3LXEnmihiunqKrmuuOqoa379ds";
    // System.Console.WriteLine("bura : " + isim);
    //     using (var example = new DriverIntroductionExample(uri, user, password))
    //     {
            
    //       await example.AddArastirmaci("Hamza","Mimarlik");
           
            

    //     }
   
    //Arastirmaci a = new Arastirmaci(){Name="Galip",yayinAdi="Yazilim"};
    //await s.addArastirmaciAsync(a);
            return View();
        }

        public IActionResult Privacy(int id)
        {
            System.Console.WriteLine("zarttt::::  " + id);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public async Task<IActionResult> IndexAsync(Arastirmaci b)
        {
             ArastirmaciRepo ar = new ArastirmaciRepo();
   
           await ar.ArastirmaciAdd(b);
            return RedirectToAction("Index","Home");
        }
    }
}
