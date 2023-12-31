#pragma checksum "D:\dev\source\repos\.NET Core\ShopApp\Client\Views\Admin\RoleList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "74fa8d27c9f09a8b39214b76086aad26d5e4f25b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_RoleList), @"mvc.1.0.view", @"/Views/Admin/RoleList.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74fa8d27c9f09a8b39214b76086aad26d5e4f25b", @"/Views/Admin/RoleList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ed4ee97d913bd698995235ac791d130d387c28af", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_RoleList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<IdentityRole>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/admin/role/delete"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-inline"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<div class=""row"">
    <div class=""col-md-12"">
        <h1>Role List</h1>
        <hr>
        <a href=""/admin/role/create"" class=""btn btn-primary btn-sm mb-3"">Create Role</a>
        <table class=""table table-bordered table-responsive align-middle"">
            <thead>
                <tr class=""text-center"">
                    <td>Role ID</td>
                    <td>Role Name</td>
                    <td style=""width:150px;"">Actions</td>
                </tr>
            </thead>

            <tbody>

");
#nullable restore
#line 20 "D:\dev\source\repos\.NET Core\ShopApp\Client\Views\Admin\RoleList.cshtml"
                 if (Model.Count() > 0)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "D:\dev\source\repos\.NET Core\ShopApp\Client\Views\Admin\RoleList.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr class=\"text-center\">\r\n                            <td>");
#nullable restore
#line 25 "D:\dev\source\repos\.NET Core\ShopApp\Client\Views\Admin\RoleList.cshtml"
                           Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 26 "D:\dev\source\repos\.NET Core\ShopApp\Client\Views\Admin\RoleList.cshtml"
                           Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                            <td>\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 913, "\"", 940, 2);
            WriteAttributeValue("", 920, "/admin/role/", 920, 12, true);
#nullable restore
#line 29 "D:\dev\source\repos\.NET Core\ShopApp\Client\Views\Admin\RoleList.cshtml"
WriteAttributeValue("", 932, item.Id, 932, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary btn-sm me-2\">Edit</a>\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "74fa8d27c9f09a8b39214b76086aad26d5e4f25b7141", async() => {
                WriteLiteral("\r\n                                    <input type=\"hidden\" name=\"RoleId\"");
                BeginWriteAttribute("value", " value=\"", 1157, "\"", 1173, 1);
#nullable restore
#line 31 "D:\dev\source\repos\.NET Core\ShopApp\Client\Views\Admin\RoleList.cshtml"
WriteAttributeValue("", 1165, item.Id, 1165, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                    <button type=\"submit\" class=\"btn btn-danger btn-sm\">Delete</button>\r\n\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 38 "D:\dev\source\repos\.NET Core\ShopApp\Client\Views\Admin\RoleList.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "D:\dev\source\repos\.NET Core\ShopApp\Client\Views\Admin\RoleList.cshtml"
                     
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"alert alert-danger\">\r\n                        <h3>No Roles</h3>\r\n                    </div>\r\n");
#nullable restore
#line 45 "D:\dev\source\repos\.NET Core\ShopApp\Client\Views\Admin\RoleList.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </tbody>\r\n\r\n        </table>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<IdentityRole>> Html { get; private set; }
    }
}
#pragma warning restore 1591
