#pragma checksum "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\Shared\ServiceProviderHistory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5acd715145f03e9409bf85b01fe0d6fabb620ee1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_ServiceProviderHistory), @"mvc.1.0.view", @"/Views/Shared/ServiceProviderHistory.cshtml")]
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
#line 1 "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\_ViewImports.cshtml"
using HelperLand;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\_ViewImports.cshtml"
using HelperLand.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5acd715145f03e9409bf85b01fe0d6fabb620ee1", @"/Views/Shared/ServiceProviderHistory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"792c06a17c9f5c83ca6617eee99384b5ffd85ea5", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_ServiceProviderHistory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div id=""ServiceProviderHistory"" class=""contant-right d-none"">
    <div>
        <div class=""table-head"">
            <h2 class=""table-title"">Service History</h2>
            <a class=""export-btn"" id=""export"" onclick=""exportData()"">Export</a>
        </div>
        <table id=""mytable3"">
            <thead style=""background-color: #f9f9f9"">
                <tr>
                    <th>Service Id <img src=""/image/sort.png"" alt=""short"" /></th>
                    <th>Service Date <img src=""/image/sort.png"" alt=""short"" /></th>
                    <th class=""text-center"">Customer Details</th>
                </tr>
            </thead>
            <tbody id=""ServiceProviderHistoryTbody"">
                <tr>
                    <td>8892</td>
                    <td>
                        <img src=""/image/calendar2.png"" alt=""calendar"" />
                        <strong> 09/04/2018</strong><span>
                            <img src=""/image/layer-14.png""");
            BeginWriteAttribute("alt", " alt=\"", 982, "\"", 988, 0);
            EndWriteAttribute();
            WriteLiteral(@" /> 12:00- 18:00
                        </span>
                    </td>
                    <td>
                        <div class=""address-td-box"">
                            <div style=""width: fit-content"">
                                <img src=""/image/layer-15.png"" alt=""cap"" />
                            </div>
                            <div>
                                <span>Kirpalsinh Sarvaiya</span>
                                <span>Ganeshnagar 161</span>
                                <span>364004 Bhavnagar</span>
                            </div>
                        </div>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
