#pragma checksum "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\Shared\AdminServiceRequestUpdate.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "18e8cc0fe95716266c90e62dcc65ec9a85f97c41"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_AdminServiceRequestUpdate), @"mvc.1.0.view", @"/Views/Shared/AdminServiceRequestUpdate.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"18e8cc0fe95716266c90e62dcc65ec9a85f97c41", @"/Views/Shared/AdminServiceRequestUpdate.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"792c06a17c9f5c83ca6617eee99384b5ffd85ea5", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_AdminServiceRequestUpdate : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<button type=""button"" class=""btn btn-primary d-none"" id=""ServiceRequestUpdateByAdminBtn"" data-bs-toggle=""modal"" data-bs-target=""#staticBackdrop6"">
    addmin service request edit
</button>


<div class=""modal fade AdminserviceRequest"" id=""staticBackdrop6"" data-bs-backdrop=""static"" data-bs-keyboard=""false""
     tabindex=""-1"" aria-labelledby=""staticBackdropLabe2"" aria-hidden=""true"">
    <div class=""modal-dialog modal-dialog-centered"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title login-title"" id=""staticBackdropLabe2"">
                    Edit Service Request
                </h5>
                <button type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
            </div>
            <div class=""modal-body"">

                <div class=""alert update-alert d-none"" role=""alert"">
                    
                </div>
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "18e8cc0fe95716266c90e62dcc65ec9a85f97c414322", async() => {
                WriteLiteral(@"


                    <div class=""container-fluid"">
                        <div class=""row mb-3"">
                            <div class=""col-sm-6"">
                                <label for=""date""> Date </label>
                                <div class=""input-group"">
                                    <span class=""input-group-text""><img src=""shape-1.png""");
                BeginWriteAttribute("alt", " alt=\"", 1345, "\"", 1351, 0);
                EndWriteAttribute();
                WriteLiteral(@"></span>
                                    <input type=""date"" id=""date"" class=""form-control"" placeholder=""Mobile Number"" aria-label=""mobile""
                                           aria-describedby=""basic-addon1"" />
                                </div>
                            </div>
                            <div class=""col-sm-6"">
                                <label for=""time""> Time</label>

                                <input type=""time"" id=""time"" class=""form-control"" placeholder=""Mobile Number"" />

                            </div>
                        </div>
                        <span class=""serviceAddressTitle"">Service Address</span>
                        <div class=""row"">
                            <div class=""col-sm-6 mb-2"">
                                <label for=""streetname""> Street Name </label>
                                <input type=""text"" class=""form-control"" placeholder=""Street Name"" id=""streetname"" />
                            </div>
      ");
                WriteLiteral(@"                      <div class=""col-sm-6 mb-2"">
                                <label for=""housename"">House Number </label>
                                <input type=""text"" class=""form-control"" placeholder=""House Number"" id=""housenumber"" />
                            </div>
                        </div>
                        <div class=""row"">
                            <div class=""col-sm-6 mb-2"">
                                <label for=""postalcode""> Postal Code </label>
                                <input type=""text"" class=""form-control"" placeholder=""Postal Code"" id=""postalcode"" />
                            </div>
                            <div class=""col-sm-6 mb-2"">
                                <label for=""city""> City </label>
                                <input type=""text"" class=""form-control"" placeholder=""Street Name"" id=""city"" disabled />
                            </div>
                        </div>
                        <div class=""col-sm-12 mb-2"">
        ");
                WriteLiteral(@"                    <label for=""Whycomment""> Why do you want to reschedule service? </label>
                            <textarea class=""mt-1"" rows=""5"" name=""comment"" id=""Whycomment""></textarea>
                        </div>
                    </div>


                    <input class=""addmin-edit-service-btn"" type=""button"" value=""Add"" />

                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n    </div>\r\n</div>\r\n</div>\r\n\r\n");
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
