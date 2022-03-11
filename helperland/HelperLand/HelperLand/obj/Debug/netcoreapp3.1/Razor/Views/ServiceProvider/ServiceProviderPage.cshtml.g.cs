#pragma checksum "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\ServiceProvider\ServiceProviderPage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "727fa5e518f385c60879b20124b2adf4575f7f71"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ServiceProvider_ServiceProviderPage), @"mvc.1.0.view", @"/Views/ServiceProvider/ServiceProviderPage.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"727fa5e518f385c60879b20124b2adf4575f7f71", @"/Views/ServiceProvider/ServiceProviderPage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"792c06a17c9f5c83ca6617eee99384b5ffd85ea5", @"/Views/_ViewImports.cshtml")]
    public class Views_ServiceProvider_ServiceProviderPage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\ServiceProvider\ServiceProviderPage.cshtml"
  
    ViewData["Title"] = "UpcomingService";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "727fa5e518f385c60879b20124b2adf4575f7f713629", async() => {
                WriteLiteral(@"
    <meta charset=""UTF-8"" />
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"" />
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"" />
    <link rel=""preconnect"" href=""https://fonts.googleapis.com"" />
    <link rel=""preconnect"" href=""https://fonts.gstatic.com"" crossorigin />
    <link href=""https://fonts.googleapis.com/css2?family=Montserrat:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&family=Roboto:ital,wght@0,100;0,300;0,400;0,500;0,700;0,900;1,100;1,300;1,400;1,500;1,700;1,900&display=swap""
          rel=""stylesheet"" />

    <link href=""https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css"" rel=""stylesheet""
          integrity=""sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC"" crossorigin=""anonymous"" />
    <link rel=""stylesheet"" href=""https://pro.fontawesome.com/releases/v5.10.0/css/all.css""
          integrity=""sha384-AYmEC3Yw5cVb3ZcuHtOA93w35dYTsvh");
                WriteLiteral(@"LPVnYs9eStHfGJvOvKxVfELGroGkvsg+p"" crossorigin=""anonymous"" />
    <link rel=""stylesheet"" type=""text/css"" href=""https://cdn.datatables.net/1.11.3/css/jquery.dataTables.css"" />

    <script type=""text/javascript"" charset=""utf8""
            src=""https://cdn.datatables.net/1.11.3/js/jquery.dataTables.js""></script>
    <link rel=""stylesheet"" href=""https://unpkg.com/leaflet@1.7.1/dist/leaflet.css""
          integrity=""sha512-xodZBNTC5n17Xt2atTPuE1HxjVMSvLVW9ocqUKLsCC5CXdbqCmblAshOMAS6/keqq/sMZMZ19scR4PsZChSR7A==""");
                BeginWriteAttribute("crossorigin", "\r\n          crossorigin=\"", 1640, "\"", 1665, 0);
                EndWriteAttribute();
                WriteLiteral(" />\r\n    <link rel=\"stylesheet\" href=\"/css/serviceProviderStyle.css\" />\r\n    <link rel=\"stylesheet\" href=\"/css/commonStyle.css\">\r\n\r\n    <title>Service History</title>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "727fa5e518f385c60879b20124b2adf4575f7f716595", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 36 "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\ServiceProvider\ServiceProviderPage.cshtml"
Write(await Html.PartialAsync("Navbar2"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    <section id=\"header\">\r\n        <h1>Welcome, <strong>");
#nullable restore
#line 38 "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\ServiceProvider\ServiceProviderPage.cshtml"
                        Write(ViewBag.Name.FirstName);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</strong></h1>
    </section>
    <section id=""contant"">
        <div id=""contant-menu"">
            <ul>
                <li id=""1"" role=""button"">
                    Dashboard
                </li>
                <li id=""2"" role=""button"" onclick=""form2()"">New Service Requests</li>
                <li id=""3"" role=""button"" onclick=""form3()"">Upcoming Services</li>
                <li id=""4"" role=""button"" onclick=""form4()"">Service Schedule</li>
                <li id=""5"" role=""button"" onclick=""form5()"">Service History</li>
                <li id=""6"" role=""button"" onclick=""form6()"">My Ratings</li>
                <li id=""7"" role=""button"" onclick=""form7()"">Block Customer</li>
            </ul>
        </div>

        ");
#nullable restore
#line 55 "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\ServiceProvider\ServiceProviderPage.cshtml"
   Write(await Html.PartialAsync("ServiceProviderSetting"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n        ");
#nullable restore
#line 57 "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\ServiceProvider\ServiceProviderPage.cshtml"
   Write(await Html.PartialAsync("ServiceProviderDashboard"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n        ");
#nullable restore
#line 59 "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\ServiceProvider\ServiceProviderPage.cshtml"
   Write(await Html.PartialAsync("ServiceProviderUpcomingService"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n        ");
#nullable restore
#line 61 "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\ServiceProvider\ServiceProviderPage.cshtml"
   Write(await Html.PartialAsync("ServiceProviderHistory"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n        ");
#nullable restore
#line 63 "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\ServiceProvider\ServiceProviderPage.cshtml"
   Write(await Html.PartialAsync("ServiceProviderRating"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n        ");
#nullable restore
#line 65 "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\ServiceProvider\ServiceProviderPage.cshtml"
   Write(await Html.PartialAsync("ServiceProviderCustomerDetailsSummery"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n    </section>\r\n\r\n    ");
#nullable restore
#line 73 "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\ServiceProvider\ServiceProviderPage.cshtml"
Write(await Html.PartialAsync("footer"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"

    <!-- bootstrap js cdn  -->
    <script src=""https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js""
            integrity=""sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM""
            crossorigin=""anonymous""></script>
    <script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js""></script>
    <script type=""text/javascript""
            src=""https://cdn.datatables.net/v/dt/dt-1.11.3/r-2.2.9/rg-1.1.4/datatables.min.js""></script>
    <script src=""https://cdn.datatables.net/responsive/2.2.9/js/dataTables.responsive.min.js""></script>
    <script src=""https://cdn.datatables.net/buttons/2.1.0/js/dataTables.buttons.min.js""></script>
    <script src=""https://cdn.datatables.net/buttons/2.1.0/js/buttons.html5.min.js""></script>
    <script type=""text/javascript"" src=""https://unpkg.com/xlsx@0.15.1/dist/xlsx.full.min.js""></script>
    <script src=""https://unpkg.com/leaflet@1.7.1/dist/leaflet.js""
            integrity=""sha512-XQoYMqMTK8Lvd");
                WriteLiteral("xXYG3nZ448hOEQiglfqkJs1NOQV44cWnUrBc8PkAOcXy20w0vlaXaVUearIOBhiXZ5V3ynxwA==\"");
                BeginWriteAttribute("crossorigin", "\r\n            crossorigin=\"", 4266, "\"", 4293, 0);
                EndWriteAttribute();
                WriteLiteral(@"></script>
    <script src=""/js/CustomDate.min.js""></script>
    <script>
        $(""#example"").dateDropdowns({
            submitFieldName: 'example',
            minAge: 18,
            submitFormat: ""dd/mm/yyyy""
        });
    </script>
    <script src=""/js/serviceProviderScript.js""></script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n\r\n");
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
