#pragma checksum "C:\Users\Mohsen\Desktop\ASPCore Angular 1398\Session11\Session07Application\ManualAuthenticationSample\Areas\Admin\Views\Permission\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5ae2be9a1b39756ae593b05a51ac41b824c44641"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Permission_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Permission/Index.cshtml")]
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
#line 1 "C:\Users\Mohsen\Desktop\ASPCore Angular 1398\Session11\Session07Application\ManualAuthenticationSample\Areas\Admin\Views\_ViewImports.cshtml"
using ManualAuthenticationSample;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Mohsen\Desktop\ASPCore Angular 1398\Session11\Session07Application\ManualAuthenticationSample\Areas\Admin\Views\_ViewImports.cshtml"
using ManualAuthenticationSample.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Mohsen\Desktop\ASPCore Angular 1398\Session11\Session07Application\ManualAuthenticationSample\Areas\Admin\Views\_ViewImports.cshtml"
using ManualAuthenticationSample.Common;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Mohsen\Desktop\ASPCore Angular 1398\Session11\Session07Application\ManualAuthenticationSample\Areas\Admin\Views\_ViewImports.cshtml"
using StackExchange.Profiling;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ae2be9a1b39756ae593b05a51ac41b824c44641", @"/Areas/Admin/Views/Permission/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d11f9d6b4f606c69b23d7eb513a3f5c09ef89c75", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Permission_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ManualAuthenticationSample.Entities.Permissions>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Mohsen\Desktop\ASPCore Angular 1398\Session11\Session07Application\ManualAuthenticationSample\Areas\Admin\Views\Permission\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5ae2be9a1b39756ae593b05a51ac41b824c446414567", async() => {
                WriteLiteral("Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "C:\Users\Mohsen\Desktop\ASPCore Angular 1398\Session11\Session07Application\ManualAuthenticationSample\Areas\Admin\Views\Permission\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.ControllerName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "C:\Users\Mohsen\Desktop\ASPCore Angular 1398\Session11\Session07Application\ManualAuthenticationSample\Areas\Admin\Views\Permission\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.ControllerCaption));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "C:\Users\Mohsen\Desktop\ASPCore Angular 1398\Session11\Session07Application\ManualAuthenticationSample\Areas\Admin\Views\Permission\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.ActionName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "C:\Users\Mohsen\Desktop\ASPCore Angular 1398\Session11\Session07Application\ManualAuthenticationSample\Areas\Admin\Views\Permission\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.ActionCaption));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 28 "C:\Users\Mohsen\Desktop\ASPCore Angular 1398\Session11\Session07Application\ManualAuthenticationSample\Areas\Admin\Views\Permission\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.ActionType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 34 "C:\Users\Mohsen\Desktop\ASPCore Angular 1398\Session11\Session07Application\ManualAuthenticationSample\Areas\Admin\Views\Permission\Index.cshtml"
         foreach (var item in Model)
        {
            string encryptID = EncyrptionUtility.Encrypt(item.Id.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 39 "C:\Users\Mohsen\Desktop\ASPCore Angular 1398\Session11\Session07Application\ManualAuthenticationSample\Areas\Admin\Views\Permission\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.ControllerName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 42 "C:\Users\Mohsen\Desktop\ASPCore Angular 1398\Session11\Session07Application\ManualAuthenticationSample\Areas\Admin\Views\Permission\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.ControllerCaption));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 45 "C:\Users\Mohsen\Desktop\ASPCore Angular 1398\Session11\Session07Application\ManualAuthenticationSample\Areas\Admin\Views\Permission\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.ActionName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 48 "C:\Users\Mohsen\Desktop\ASPCore Angular 1398\Session11\Session07Application\ManualAuthenticationSample\Areas\Admin\Views\Permission\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.ActionCaption));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 51 "C:\Users\Mohsen\Desktop\ASPCore Angular 1398\Session11\Session07Application\ManualAuthenticationSample\Areas\Admin\Views\Permission\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.ActionType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    <a");
            BeginWriteAttribute("onclick", " onclick=\"", 1594, "\"", 1642, 5);
            WriteAttributeValue("", 1604, "showEditModal(event,", 1604, 20, true);
            WriteAttributeValue(" ", 1624, "this,", 1625, 6, true);
            WriteAttributeValue(" ", 1630, "\'", 1631, 2, true);
#nullable restore
#line 54 "C:\Users\Mohsen\Desktop\ASPCore Angular 1398\Session11\Session07Application\ManualAuthenticationSample\Areas\Admin\Views\Permission\Index.cshtml"
WriteAttributeValue("", 1632, item.Id, 1632, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1640, "\')", 1640, 2, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-info btn-sm\">Edit</a> |\r\n                    <a class=\"btn btn-danger btn-sm\"");
            BeginWriteAttribute("href", " href=\"", 1736, "\"", 1778, 2);
            WriteAttributeValue("", 1743, "/Admin/Permission/Delete/", 1743, 25, true);
#nullable restore
#line 55 "C:\Users\Mohsen\Desktop\ASPCore Angular 1398\Session11\Session07Application\ManualAuthenticationSample\Areas\Admin\Views\Permission\Index.cshtml"
WriteAttributeValue("", 1768, encryptID, 1768, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Delete</a>\r\n\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 59 "C:\Users\Mohsen\Desktop\ASPCore Angular 1398\Session11\Session07Application\ManualAuthenticationSample\Areas\Admin\Views\Permission\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </tbody>
</table>

<div class=""modal fade"" id=""sampleModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""channelModal"">
    <div class=""modal-dialog"" style=""width:80%;max-width:1000px !important"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-title"" style=""padding:15px 15px 0"">
                <h3 class=""text-left"">
                  ویرایش | افزودن دسترسی
                    <button type=""button"" class=""close pull-right"" data-dismiss=""modal"" aria-label=""Close""><strong style='font-size:35px;' aria-hidden=""true"">&times;</strong></button>
                </h3>
            </div>
            <div class=""modal-body"">
               
            </div>
        </div>
    </div>
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        const showEditModal = (event, element, id) => {
            //debugger;
            event.preventDefault();

            //ajax: 1.jQuery Ajax 2.Fetch 3.XMLHttpRequest
            const url = `/Admin/Permission/Edit/${id}`;
            $.get(url, function (html) {
                console.log(html);  
                $('#sampleModal .modal-body').html(html);
                 $(""#sampleModal"").modal();
            })
        }
    </script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ManualAuthenticationSample.Entities.Permissions>> Html { get; private set; }
    }
}
#pragma warning restore 1591
