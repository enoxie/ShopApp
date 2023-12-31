#pragma checksum "D:\dev\source\repos\.NET Core\ShopApp\Client\Views\Shop\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2d51ba5d298393938edee8063b5a5e092a16317f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shop_List), @"mvc.1.0.view", @"/Views/Shop/List.cshtml")]
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
#line 2 "D:\dev\source\repos\.NET Core\ShopApp\Client\Views\_ViewImports.cshtml"
using Entity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\dev\source\repos\.NET Core\ShopApp\Client\Views\_ViewImports.cshtml"
using Client.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\dev\source\repos\.NET Core\ShopApp\Client\Views\_ViewImports.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\dev\source\repos\.NET Core\ShopApp\Client\Views\_ViewImports.cshtml"
using Client.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\dev\source\repos\.NET Core\ShopApp\Client\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\dev\source\repos\.NET Core\ShopApp\Client\Views\_ViewImports.cshtml"
using Client.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d51ba5d298393938edee8063b5a5e092a16317f", @"/Views/Shop/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ed4ee97d913bd698995235ac791d130d387c28af", @"/Views/_ViewImports.cshtml")]
    public class Views_Shop_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductListViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n\r\n");
#nullable restore
#line 5 "D:\dev\source\repos\.NET Core\ShopApp\Client\Views\Shop\List.cshtml"
 if (Model.Products.Count == 0)
{




#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-md-3\">\r\n            ");
#nullable restore
#line 12 "D:\dev\source\repos\.NET Core\ShopApp\Client\Views\Shop\List.cshtml"
       Write(await Component.InvokeAsync("Categories"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-md-9\">\r\n            <div class=\"row\">\r\n                ");
#nullable restore
#line 16 "D:\dev\source\repos\.NET Core\ShopApp\Client\Views\Shop\List.cshtml"
           Write(await Html.PartialAsync("_noproduct"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 20 "D:\dev\source\repos\.NET Core\ShopApp\Client\Views\Shop\List.cshtml"

}

else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-md-3\">\r\n            ");
#nullable restore
#line 27 "D:\dev\source\repos\.NET Core\ShopApp\Client\Views\Shop\List.cshtml"
       Write(await Component.InvokeAsync("Categories"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-md-9\">\r\n            <div class=\"row\">\r\n");
#nullable restore
#line 31 "D:\dev\source\repos\.NET Core\ShopApp\Client\Views\Shop\List.cshtml"
                 foreach (var product in Model.Products)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"col-md-3 mb-3\">\r\n                        ");
#nullable restore
#line 34 "D:\dev\source\repos\.NET Core\ShopApp\Client\Views\Shop\List.cshtml"
                   Write(await Html.PartialAsync("_product", product));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n");
#nullable restore
#line 36 "D:\dev\source\repos\.NET Core\ShopApp\Client\Views\Shop\List.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n\r\n            <div class=\"row\">\r\n                <div class=\"col\">\r\n                    <nav aria-label=\"Page navigation example\">\r\n                        <ul class=\"pagination justify-content-center\">\r\n\r\n");
#nullable restore
#line 44 "D:\dev\source\repos\.NET Core\ShopApp\Client\Views\Shop\List.cshtml"
                             for (int i = 0; i < Model.PageInfo.TotalPages(); i++)
                            {

                                if (String.IsNullOrEmpty(Model.PageInfo.CurrentCategory))
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <li");
            BeginWriteAttribute("class", " class=\"", 1329, "\"", 1399, 3);
            WriteAttributeValue("", 1337, "page-item", 1337, 9, true);
#nullable restore
#line 49 "D:\dev\source\repos\.NET Core\ShopApp\Client\Views\Shop\List.cshtml"
WriteAttributeValue(" ", 1346, Model.PageInfo.CurrentPage==i+1 ? "active" : "" , 1347, 51, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 1398, "", 1399, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 1463, "\"", 1498, 2);
            WriteAttributeValue("", 1470, "/products?currentPage=", 1470, 22, true);
#nullable restore
#line 50 "D:\dev\source\repos\.NET Core\ShopApp\Client\Views\Shop\List.cshtml"
WriteAttributeValue("", 1492, i+1, 1492, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" tabindex=\"-1\">");
#nullable restore
#line 50 "D:\dev\source\repos\.NET Core\ShopApp\Client\Views\Shop\List.cshtml"
                                                                                                           Write(i + 1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                    </li>\r\n");
#nullable restore
#line 52 "D:\dev\source\repos\.NET Core\ShopApp\Client\Views\Shop\List.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <li");
            BeginWriteAttribute("class", " class=\"", 1718, "\"", 1788, 3);
            WriteAttributeValue("", 1726, "page-item", 1726, 9, true);
#nullable restore
#line 55 "D:\dev\source\repos\.NET Core\ShopApp\Client\Views\Shop\List.cshtml"
WriteAttributeValue(" ", 1735, Model.PageInfo.CurrentPage==i+1 ? "active" : "" , 1736, 51, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 1787, "", 1788, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 1852, "\"", 1919, 4);
            WriteAttributeValue("", 1859, "/products/", 1859, 10, true);
#nullable restore
#line 56 "D:\dev\source\repos\.NET Core\ShopApp\Client\Views\Shop\List.cshtml"
WriteAttributeValue("", 1869, Model.PageInfo.CurrentCategory, 1869, 31, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1900, "?currentPage=", 1900, 13, true);
#nullable restore
#line 56 "D:\dev\source\repos\.NET Core\ShopApp\Client\Views\Shop\List.cshtml"
WriteAttributeValue("", 1913, i+1, 1913, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("\r\n                                            tabindex=\"-1\">");
#nullable restore
#line 57 "D:\dev\source\repos\.NET Core\ShopApp\Client\Views\Shop\List.cshtml"
                                                      Write(i + 1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                    </li>\r\n");
#nullable restore
#line 59 "D:\dev\source\repos\.NET Core\ShopApp\Client\Views\Shop\List.cshtml"
                                }

                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n                        </ul>\r\n                    </nav>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 76 "D:\dev\source\repos\.NET Core\ShopApp\Client\Views\Shop\List.cshtml"

}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\r\n    <script src=\"https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.min.js\"\r\n        integrity=\"sha384-BBtl+eGJRgqQAUMxJ7pMwbEyER4l1g+O15P+16Ep7Q9Q+zqX6gSbd85u4mG4QzX+\"\r\n        crossorigin=\"anonymous\"></script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
