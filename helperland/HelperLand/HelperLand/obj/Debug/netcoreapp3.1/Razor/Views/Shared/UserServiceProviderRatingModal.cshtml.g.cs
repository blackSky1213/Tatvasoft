#pragma checksum "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\Shared\UserServiceProviderRatingModal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "15c577fa834d23c8a0edbbe01d0d1103a6bb5174"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_UserServiceProviderRatingModal), @"mvc.1.0.view", @"/Views/Shared/UserServiceProviderRatingModal.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"15c577fa834d23c8a0edbbe01d0d1103a6bb5174", @"/Views/Shared/UserServiceProviderRatingModal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"792c06a17c9f5c83ca6617eee99384b5ffd85ea5", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_UserServiceProviderRatingModal : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
<div class=""modal"" tabindex=""-1"" id=""myRatingModal"">
    <div class=""modal-dialog modal-dialog-centered"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <div class=""service-provider-average-rating"">
                    <div>
                        <img class=""cap-icon"" src=""/image/cap.png"" alt=""cap"" />
                    </div>
                    <div>
                        <div><span>Lyum Watson</span></div>
                        <div class=""d-flex align-items-center"">
                            <div class=""average-rating"">
                                <span></span><span></span><span></span><span></span><span></span><span></span><span></span><span></span><span></span><span></span>
                            </div>
                            <div style=""padding-top: 4px; padding-left: 3px"">
                                <span>5</span>
                            </div>
                        </div>
                    </div>
    ");
            WriteLiteral(@"            </div>
                <button type=""button""
                        class=""btn-close""
                        data-bs-dismiss=""modal""
                        aria-label=""Close""></button>
            </div>
            <div class=""modal-body"">
                <h4 class=""rating-head"">Rate your service provider</h4>
                <!-- on time starts -->
                <div class=""spSkills"">
                    <div><p>On Time Arrival</p></div>
                    <div class=""spRatings"">
                        <input type=""radio"" name=""onTime"" />
                        <input type=""radio"" name=""onTime"" />
                        <input type=""radio"" name=""onTime"" />
                        <input type=""radio"" name=""onTime"" />
                        <input type=""radio"" name=""onTime"" />
                        <input type=""radio"" name=""onTime"" />
                        <input type=""radio"" name=""onTime"" />
                        <input type=""radio"" name=""onTime"" />
           ");
            WriteLiteral(@"             <input type=""radio"" name=""onTime"" />
                        <input type=""radio"" name=""onTime"" />
                    </div>
                </div>
                <!-- on time ends -->
                <!-- friendly starts -->
                <div class=""spSkills"">
                    <p>friendly</p>
                    <div class=""spRatings"">
                        <input type=""radio"" name=""friendly"" />
                        <input type=""radio"" name=""friendly"" />
                        <input type=""radio"" name=""friendly"" />
                        <input type=""radio"" name=""friendly"" />
                        <input type=""radio"" name=""friendly"" />
                        <input type=""radio"" name=""friendly"" />
                        <input type=""radio"" name=""friendly"" />
                        <input type=""radio"" name=""friendly"" />
                        <input type=""radio"" name=""friendly"" />
                        <input type=""radio"" name=""friendly"" />
                ");
            WriteLiteral(@"    </div>
                </div>
                <!-- friendly ends -->
                <!-- Quality of Service starts -->
                <div class=""spSkills"">
                    <p>Quality of Service</p>
                    <div class=""spRatings"">
                        <input type=""radio"" name=""qualityService"" />
                        <input type=""radio"" name=""qualityService"" />
                        <input type=""radio"" name=""qualityService"" />
                        <input type=""radio"" name=""qualityService"" />
                        <input type=""radio"" name=""qualityService"" />
                        <input type=""radio"" name=""qualityService"" />
                        <input type=""radio"" name=""qualityService"" />
                        <input type=""radio"" name=""qualityService"" />
                        <input type=""radio"" name=""qualityService"" />
                        <input type=""radio"" name=""qualityService"" />
                    </div>
                </div>
            ");
            WriteLiteral("    <!-- quality of service ends -->\r\n                <div class=\"feedback-box\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "15c577fa834d23c8a0edbbe01d0d1103a6bb51748173", async() => {
                WriteLiteral(@"
                        <label for=""feedback-label"">Feedback on service provider</label>
                        <textarea class=""form-control""
                                  id=""feedback-label""
                                  rows=""2""></textarea>
                        <input type=""button"" class=""submit-btn"" value=""Submit""></input>
                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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