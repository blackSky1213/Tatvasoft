#pragma checksum "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\Shared\CustomerServiceHistoryTab.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4ae882bdeaa85993c193d42e99cb51f1db6b8b8e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_CustomerServiceHistoryTab), @"mvc.1.0.view", @"/Views/Shared/CustomerServiceHistoryTab.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ae882bdeaa85993c193d42e99cb51f1db6b8b8e", @"/Views/Shared/CustomerServiceHistoryTab.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"792c06a17c9f5c83ca6617eee99384b5ffd85ea5", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_CustomerServiceHistoryTab : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div id=""ServiceHistory"">
    <div class=""table-head"">
        <h2 class=""table-title"">Service History</h2>
        <a class=""export-btn"" id=""export"" onclick=""exportData()"">Export</a>
    </div>
    <table id=""mytable2"">
        <thead style=""background-color: #f9f9f9"">
            <tr>
               <th>Service Id <img src=""/image/sort.png"" alt=""short"" /></th>
                <th>
                    Service Date <img src=""/image/sort.png"" alt=""short"" />
                </th>
                <th>
                    Service Provider <img src=""/image/sort.png"" alt=""short"" />
                </th>
                <th class=""text-center"">
                    Payment <img src=""/image/sort.png"" alt=""short"" />
                </th>
                <th class=""text-center"">
                    Status <img src=""/image/sort.png"" alt=""short"" />
                </th>
                <th>Rate SP</th>
            </tr>
        </thead>
        <tbody id=""CustomerServiceHistoryTable"">
          ");
            WriteLiteral("\r\n        </tbody>\r\n    </table>\r\n</div>");
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
