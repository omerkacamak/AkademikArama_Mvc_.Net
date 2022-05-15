using System.Collections.Generic;
using System.Threading.Tasks;
using demo.Models;
using Layers;
using Microsoft.AspNetCore.Mvc;
using Neo4jDatabase.Concrete;

namespace demo.ViewComponents.Search
{
    public class SearchBar:ViewComponent
    {
          ArastirmaciRepo ara =new ArastirmaciRepo();
        public async Task<IViewComponentResult> InvokeAsync(int YayinId,int ArId)
        {
            var kisi= await ara.GetArastirmaci(ArId);
            var yayin = await ara.GetYayinlar(YayinId);
            var model = new AraYayinModel(){ArasTek=kisi,YayTek=yayin};
            
            return View(model);
        }
    }
}