#pragma checksum "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\Customer\CustomerServiceHistory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e4e7e989967aa93dfa65ffa39d02b9b924cc6a85"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_CustomerServiceHistory), @"mvc.1.0.view", @"/Views/Customer/CustomerServiceHistory.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e4e7e989967aa93dfa65ffa39d02b9b924cc6a85", @"/Views/Customer/CustomerServiceHistory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"792c06a17c9f5c83ca6617eee99384b5ffd85ea5", @"/Views/_ViewImports.cshtml")]
    public class Views_Customer_CustomerServiceHistory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 2 "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\Customer\CustomerServiceHistory.cshtml"
  
    ViewData["Title"] = "CustomerServiceHistory";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            \r\n\r\n            \r\n\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e4e7e989967aa93dfa65ffa39d02b9b924cc6a853648", async() => {
                WriteLiteral(@"
    <meta charset=""UTF-8"" />
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"" />
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"" />
    
    <link rel=""preconnect"" href=""https://fonts.googleapis.com"" />
    <link rel=""preconnect"" href=""https://fonts.gstatic.com"" crossorigin />
    <link href=""https://fonts.googleapis.com/css2?family=Montserrat:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&family=Roboto:ital,wght@0,100;0,300;0,400;0,500;0,700;0,900;1,100;1,300;1,400;1,500;1,700;1,900&display=swap""
          rel=""stylesheet"" />
    <link href=""https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css""
          rel=""stylesheet""
          integrity=""sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC""
          crossorigin=""anonymous"" />
    <link rel=""stylesheet""
          href=""https://pro.fontawesome.com/releases/v5.10.0/css/all.css""
          integrity=""s");
                WriteLiteral(@"ha384-AYmEC3Yw5cVb3ZcuHtOA93w35dYTsvhLPVnYs9eStHfGJvOvKxVfELGroGkvsg+p""
          crossorigin=""anonymous"" />
    <link rel=""stylesheet""
          type=""text/css""
          href=""https://cdn.datatables.net/1.11.3/css/jquery.dataTables.css"" />

    <script type=""text/javascript""
            charset=""utf8""
            src=""https://cdn.datatables.net/1.11.3/js/jquery.dataTables.js""></script>
    <link rel=""stylesheet"" href=""/css/serviceHistoryStyle.css"" />
    <link rel=""stylesheet"" href=""/css/commonStyle.css""/>

    <title>Service History</title>
");
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e4e7e989967aa93dfa65ffa39d02b9b924cc6a856296", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 43 "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\Customer\CustomerServiceHistory.cshtml"
Write(await Html.PartialAsync("Navbar2"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    <section id=\"header\">\r\n        <h1>Welcome, <strong> ");
#nullable restore
#line 45 "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\Customer\CustomerServiceHistory.cshtml"
                         Write(ViewBag.Name.FirstName);

#line default
#line hidden
#nullable disable
                WriteLiteral(@" </strong></h1>
    </section>

    <section id=""contant"">
        <div id=""contant-menu"">
            <ul>
                <li id=""1""
                    role=""button""
                    onclick=""form1()""
                    style=""background-color: #146371"">
                    Dashboard
                </li>
                <li id=""2"" role=""button"" onclick=""form2()"" >Service History</li>
                <li id=""3"" role=""button"" onclick=""form3()"">Sercie Schedule</li>
                <li id=""4"" role=""button"" onclick=""form4()"">Favourite Pros</li>
                <li id=""5"" role=""button"" onclick=""form5()"">Invoices</li>
                <li id=""6"" role=""button"" onclick=""form6()"">Notification</li>
            </ul>
        </div>

        ");
#nullable restore
#line 65 "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\Customer\CustomerServiceHistory.cshtml"
   Write(await Html.PartialAsync("CustomerSetting"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n        <div class=\"contant-right\">\r\n\r\n            ");
#nullable restore
#line 69 "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\Customer\CustomerServiceHistory.cshtml"
       Write(await Html.PartialAsync("CustomerDashboard"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            ");
#nullable restore
#line 70 "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\Customer\CustomerServiceHistory.cshtml"
       Write(await Html.PartialAsync("CustomerServiceHistoryTab"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n    </section>\r\n\r\n    ");
#nullable restore
#line 74 "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\Customer\CustomerServiceHistory.cshtml"
Write(await Html.PartialAsync("footer"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 75 "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\Customer\CustomerServiceHistory.cshtml"
Write(await Html.PartialAsync("customerServiceRescheduleModal"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 76 "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\Customer\CustomerServiceHistory.cshtml"
Write(await Html.PartialAsync("CustomerServiceRequestCancelModal"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 77 "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\Customer\CustomerServiceHistory.cshtml"
Write(await Html.PartialAsync("CustomerServiceRequestSummery"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 78 "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\Customer\CustomerServiceHistory.cshtml"
Write(await Html.PartialAsync("userSettingAddAddress"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 79 "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\Customer\CustomerServiceHistory.cshtml"
Write(await Html.PartialAsync("UserServiceProviderRatingModal"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 80 "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\Customer\CustomerServiceHistory.cshtml"
Write(await Html.PartialAsync("DeleteAddress"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 81 "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\Customer\CustomerServiceHistory.cshtml"
Write(await Html.PartialAsync("userSettingUpdateAddress"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
    <script src=""https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js""
            integrity=""sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM""
            crossorigin=""anonymous""></script>
    <script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js""></script>
    <script src=""/js/CustomDate.min.js""></script>
    <script type=""text/javascript""
            src=""https://cdn.datatables.net/v/dt/dt-1.11.3/r-2.2.9/rg-1.1.4/datatables.min.js""></script>
    <script src=""https://cdn.datatables.net/responsive/2.2.9/js/dataTables.responsive.min.js""></script>
    <script src=""https://cdn.datatables.net/buttons/2.1.0/js/dataTables.buttons.min.js""></script>
    <script src=""https://cdn.datatables.net/buttons/2.1.0/js/buttons.html5.min.js""></script>
    <script type=""text/javascript"" src=""https://unpkg.com/xlsx@0.15.1/dist/xlsx.full.min.js""></script>


    <script>
        $(""#example"").dateDropdowns({
            submitFieldName: 'exampl");
                WriteLiteral("e\',\r\n            minAge: 18,\r\n            submitFormat: \"dd/mm/yyyy\"\r\n        });\r\n    </script>\r\n    <script src=\"/js/customerServiceHistory.js\">\r\n    </script>\r\n    <!-- bootstrap js cdn  -->\r\n");
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
            WriteLiteral("\r\n</html>\r\n\r\n\r\n");
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
