#pragma checksum "C:\Users\90545\Desktop\akademikArama\demo\Views\Shared\Components\SearchBar\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cc4ea08d33a77f21c41b20a6add0e327939de86f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_SearchBar_Default), @"mvc.1.0.view", @"/Views/Shared/Components/SearchBar/Default.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\90545\Desktop\akademikArama\demo\Views\_ViewImports.cshtml"
using demo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\90545\Desktop\akademikArama\demo\Views\_ViewImports.cshtml"
using demo.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc4ea08d33a77f21c41b20a6add0e327939de86f", @"/Views/Shared/Components/SearchBar/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eae16e985384ed2ccc0dcb10dbe2dab2d21b6a3b", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_SearchBar_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<demo.Models.AraYayinModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<table class=\"table table-bordered w-100\">\r\n    <tr class=\"w-25\">\r\n        <th>Arastirmaci Adi</th>\r\n        <td>\r\n           <a");
            BeginWriteAttribute("href", " href=\"", 166, "\"", 216, 2);
            WriteAttributeValue("", 173, "/Search/Profil/", 173, 15, true);
#nullable restore
#line 8 "C:\Users\90545\Desktop\akademikArama\demo\Views\Shared\Components\SearchBar\Default.cshtml"
WriteAttributeValue("", 188, Model.ArasTek.ArastirmaciId, 188, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("> ");
#nullable restore
#line 8 "C:\Users\90545\Desktop\akademikArama\demo\Views\Shared\Components\SearchBar\Default.cshtml"
                                                             Write(Model.ArasTek.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n        </td>\r\n    </tr>\r\n     <tr>\r\n        <th class=\"w-25\">ArastirmaciSoyadi</th>\r\n        <td>");
#nullable restore
#line 13 "C:\Users\90545\Desktop\akademikArama\demo\Views\Shared\Components\SearchBar\Default.cshtml"
       Write(Model.ArasTek.Soyad);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    </tr>\r\n     <tr>\r\n        <th class=\"w-25\">YayinAdi:</th>\r\n        <td>");
#nullable restore
#line 17 "C:\Users\90545\Desktop\akademikArama\demo\Views\Shared\Components\SearchBar\Default.cshtml"
       Write(Model.YayTek.YayinAdi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    </tr>\r\n    <tr>\r\n        <th class=\"w-25\">YayinYili:</th>\r\n        <td>");
#nullable restore
#line 21 "C:\Users\90545\Desktop\akademikArama\demo\Views\Shared\Components\SearchBar\Default.cshtml"
       Write(Model.YayTek.YayinYili);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    </tr>\r\n     <tr>\r\n        <th class=\"w-25\">YayinYeri:</th>\r\n        <td>");
#nullable restore
#line 25 "C:\Users\90545\Desktop\akademikArama\demo\Views\Shared\Components\SearchBar\Default.cshtml"
       Write(Model.YayTek.YayinYeri);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    </tr><tr>\r\n        <th class=\"w-25\">Türü:</th>\r\n        <td>");
#nullable restore
#line 28 "C:\Users\90545\Desktop\akademikArama\demo\Views\Shared\Components\SearchBar\Default.cshtml"
       Write(Model.YayTek.nodeTur[0].Properties["name"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    </tr>\r\n     <tr>\r\n        <th class=\"w-25\">Ortaklar:</th>\r\n        <td>\r\n");
#nullable restore
#line 33 "C:\Users\90545\Desktop\akademikArama\demo\Views\Shared\Components\SearchBar\Default.cshtml"
             foreach (var item in Model.YayTek.nodePerson)
    {
        if (item.Properties["name"].ToString()==Model.ArasTek.Name)
        {
           continue;
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("         <a");
            BeginWriteAttribute("href", " href=\"", 1066, "\"", 1096, 2);
            WriteAttributeValue("", 1073, "/Search/Profil/", 1073, 15, true);
#nullable restore
#line 39 "C:\Users\90545\Desktop\akademikArama\demo\Views\Shared\Components\SearchBar\Default.cshtml"
WriteAttributeValue("", 1088, item.Id, 1088, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 39 "C:\Users\90545\Desktop\akademikArama\demo\Views\Shared\Components\SearchBar\Default.cshtml"
                                      Write(item.Properties["name"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 40 "C:\Users\90545\Desktop\akademikArama\demo\Views\Shared\Components\SearchBar\Default.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </td>\r\n    </tr>\r\n    \r\n    \r\n</table>\r\n    \r\n\r\n\r\n \r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<demo.Models.AraYayinModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
