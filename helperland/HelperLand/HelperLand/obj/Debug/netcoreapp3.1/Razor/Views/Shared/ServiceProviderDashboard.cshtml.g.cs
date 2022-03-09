#pragma checksum "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\Shared\ServiceProviderDashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "71d50315eeb6a70ef9823ff2dd7b063b6091a7cd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_ServiceProviderDashboard), @"mvc.1.0.view", @"/Views/Shared/ServiceProviderDashboard.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"71d50315eeb6a70ef9823ff2dd7b063b6091a7cd", @"/Views/Shared/ServiceProviderDashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"792c06a17c9f5c83ca6617eee99384b5ffd85ea5", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_ServiceProviderDashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<HelperLand.Models.ServiceProviderService>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div id=""Dashboard"" class=""contant-right "">
    <div>
        <div class=""table-head"">
            <div style=""color: #4f4f4f"">
                <input type=""checkbox"" name=""havepet"" id=""havepet"" /> Include Pet
                at Home
            </div>
        </div>
        <table id=""mytable1"">
            <thead style=""background-color: #f9f9f9"">

                <tr>
                    <th>Service Id <img src=""/image/sort.png"" alt=""short"" /></th>
                    <th>Service Date <img src=""/image/sort.png"" alt=""short"" /></th>
                    <th class=""text-center"">Customer Details</th>
                    <th class=""text-center"">
                        Payment <img src=""/image/sort.png"" alt=""short"" />
                    </th>
                    <th>Time conflict</th>
                    <th>Action</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 26 "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\Shared\ServiceProviderDashboard.cshtml"
                 if (Model.Count() > 0)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\Shared\ServiceProviderDashboard.cshtml"
                     foreach (var obj in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 31 "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\Shared\ServiceProviderDashboard.cshtml"
                           Write(obj.ServiceRequestId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>\r\n                                <img src=\"/image/calendar2.png\" alt=\"calendar\" />\r\n                                <strong> ");
#nullable restore
#line 34 "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\Shared\ServiceProviderDashboard.cshtml"
                                    Write(obj.ServiceStartDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong><span>\r\n                                    <img src=\"/image/layer-14.png\"");
            BeginWriteAttribute("alt", " alt=\"", 1464, "\"", 1470, 0);
            EndWriteAttribute();
            WriteLiteral(" /> ");
#nullable restore
#line 35 "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\Shared\ServiceProviderDashboard.cshtml"
                                                                        Write(obj.startTime);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 35 "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\Shared\ServiceProviderDashboard.cshtml"
                                                                                         Write(obj.endTime);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </span>
                            </td>
                            <td>
                                <div class=""address-td-box"">
                                    <div style=""width: fit-content"">
                                        <img src=""/image/layer-15.png"" alt=""cap"" />
                                    </div>
                                    <div>
                                        <span>");
#nullable restore
#line 44 "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\Shared\ServiceProviderDashboard.cshtml"
                                         Write(obj.CustomerName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                        <span>");
#nullable restore
#line 45 "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\Shared\ServiceProviderDashboard.cshtml"
                                         Write(obj.CustomerAddress1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                        <span>");
#nullable restore
#line 46 "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\Shared\ServiceProviderDashboard.cshtml"
                                         Write(obj.CustomerAddress2);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                    </div>\r\n                                </div>\r\n                            </td>\r\n                            <td>\r\n                                <span class=\"payment-td\">&#8364; ");
#nullable restore
#line 51 "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\Shared\ServiceProviderDashboard.cshtml"
                                                            Write(obj.TotalCost);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                            </td>\r\n                            <td> ");
#nullable restore
#line 53 "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\Shared\ServiceProviderDashboard.cshtml"
                            Write(obj.timeConflict);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                            <td>\r\n                                <button class=\"accept-btn\"");
            BeginWriteAttribute("href", " href=\"", 2571, "\"", 2578, 0);
            EndWriteAttribute();
            WriteLiteral(">Accept</button>\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 59 "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\Shared\ServiceProviderDashboard.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 59 "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\Shared\ServiceProviderDashboard.cshtml"
                     
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n        </table>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<HelperLand.Models.ServiceProviderService>> Html { get; private set; }
    }
}
#pragma warning restore 1591
