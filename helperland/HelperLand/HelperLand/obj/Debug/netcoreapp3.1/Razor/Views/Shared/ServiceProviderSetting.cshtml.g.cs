#pragma checksum "C:\Users\kbsar\source\repos\HelperLand\HelperLand\Views\Shared\ServiceProviderSetting.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e2bb2c9fbdbaaf5dae390f94f46de5ab9029ca49"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_ServiceProviderSetting), @"mvc.1.0.view", @"/Views/Shared/ServiceProviderSetting.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e2bb2c9fbdbaaf5dae390f94f46de5ab9029ca49", @"/Views/Shared/ServiceProviderSetting.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"792c06a17c9f5c83ca6617eee99384b5ffd85ea5", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_ServiceProviderSetting : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
            WriteLiteral(@"

<div class=""my-setting-box d-none"">
    <div class=""my-setting-menu"">
        <ul>
            <li role=""button"" id=""user-setting-option-1"" class=""active-setting-option"">
                <span class=""user-details-menu-icon"">
                    <svg xmlns=""http://www.w3.org/2000/svg"" class=""user-menu-icon""
                         fill=""none"" viewBox=""0 0 24 24"" stroke=""currentColor"">
                        <path stroke-linecap=""round"" stroke-linejoin=""round"" stroke-width=""1""
                              d=""M9 12h6m-6 4h6m2 5H7a2 2 0 01-2-2V5a2 2 0 012-2h5.586a1 1 0 01.707.293l5.414 5.414a1 1 0 01.293.707V19a2 2 0 01-2 2z"" />
                    </svg>
                </span>
                <span class=""user-details-option-text"">My Details</span>
            </li>

            <li role=""button"" id=""user-setting-option-3"">
                <span class=""user-details-menu-icon"">
                    <svg xmlns=""http://www.w3.org/2000/svg"" class=""user-menu-icon key-icon"" fill=""none"" viewBox=""");
            WriteLiteral(@"0 0 24 24""
                         stroke=""currentColor"">
                        <path stroke-linecap=""round"" stroke-linejoin=""round"" stroke-width=""1""
                              d=""M15 7a2 2 0 012 2m4 0a6 6 0 01-7.743 5.743L11 17H9v2H7v2H4a1 1 0 01-1-1v-2.586a1 1 0 01.293-.707l5.964-5.964A6 6 0 1121 9z"" />
                    </svg>
                </span>
                <span class=""user-details-option-text"">Changes Password</span>
            </li>
        </ul>
    </div>
    <div class=""my-setting-details"">
        <div class=""setting-details-alert alert  mt-3 d-none"" role=""alert"">
            This is a danger alert???check it out!
        </div>
        <span class=""user-menu-header"">My deatils</span>

        <div class=""basic-details-box"">
            <div class=""basic-details"">
                <h2>Account Status: <span class=""status"">Active</span></h2>
                <span>Basic details</span>
            </div>
            <div><img id=""profileAvtar"" src=""/image/cap.jpg"" alt");
            WriteLiteral("=\"cap-icon\" /></div>\r\n        </div>\r\n\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e2bb2c9fbdbaaf5dae390f94f46de5ab9029ca495534", async() => {
                WriteLiteral(@"
            <div class=""container"">
                <div class=""row mb-3"">
                    <div class=""col-lg-4 mb-3"">
                        <label for=""firstname""> First Name </label>
                        <input type=""text"" class=""form-control"" placeholder=""First Name"" id=""firstname"" />
                    </div>
                    <div class=""col-lg-4 mb-3"">
                        <label for=""lastname""> Last Name </label>
                        <input type=""text"" placeholder=""Last Name"" class=""form-control"" id=""lastname"" />
                    </div>
                    <div class=""col-lg-4"">
                        <label for=""email""> E-mail Address </label>
                        <input type=""email"" class=""form-control"" placeholder=""E-mail"" id=""email"" disabled />
                    </div>
                </div>
                <div class=""row cover"">
                    <div class=""col-lg-4 mb-3"">
                        <label for=""mobile"">Mobile Number</label>
         ");
                WriteLiteral(@"               <div class=""input-group"">
                            <span class=""input-group-text"">+49</span>
                            <input type=""tel"" id=""mobile"" class=""form-control"" placeholder=""Mobile Number"" aria-label=""mobile""
                                   aria-describedby=""basic-addon1"" />
                        </div>
                    </div>
                    <div class=""col-lg-4 flex-nowrap dobSelect"">
                        <label for=""dob""> Date of Birth </label>
                        <input type=""hidden"" class=""form-control"" name=""birthdate"" id=""example"" />
                    </div>

                </div>
                <div class=""row cover Gender-box"">
                    <label for=""gender"">Gender</label>
                    <div>
                        <input type=""radio"" name=""gender"" class=""gender"" value=""1"" />
                        Male
                        <input type=""radio"" name=""gender"" class=""gender"" value=""2"" />
                        Fem");
                WriteLiteral(@"ale                            
                        <input type=""radio"" name=""gender"" class=""gender"" value=""3"" />
                        Rather not to say
                    </div>
                </div>
                <div class=""row mt-4"">
                    <label for=""avatar"">Select avtar</label>
                    <div class=""avtar-box"">
                        <div>
                            <label>
                                <input type=""radio"" class=""avtar"" name=""avtar"" value=""cap""><img src=""/image/cap.jpg""");
                BeginWriteAttribute("alt", "\r\n                                                                                                alt=\"", 4818, "\"", 4921, 0);
                EndWriteAttribute();
                WriteLiteral(@" />
                            </label>
                        </div>
                        <div>
                            <label>
                                <input type=""radio"" class=""avtar"" name=""avtar"" value=""car""><img src=""/image/car.jpg""");
                BeginWriteAttribute("alt", "\r\n                                                                                                alt=\"", 5181, "\"", 5284, 0);
                EndWriteAttribute();
                WriteLiteral(@" />
                            </label>
                        </div>
                        <div>
                            <label>
                                <input type=""radio"" class=""avtar"" name=""avtar"" value=""man""><img src=""/image/man.jpg""");
                BeginWriteAttribute("alt", "\r\n                                                                                                alt=\"", 5544, "\"", 5647, 0);
                EndWriteAttribute();
                WriteLiteral(@" />
                            </label>
                        </div>
                        <div>
                            <label>
                                <input type=""radio"" class=""avtar"" name=""avtar"" value=""ship""><img src=""/image/ship.jpg""");
                BeginWriteAttribute("alt", "\r\n                                                                                                 alt=\"", 5909, "\"", 6013, 0);
                EndWriteAttribute();
                WriteLiteral(@" />
                            </label>
                        </div>
                        <div>
                            <label>
                                <input type=""radio"" class=""avtar"" name=""avtar"" value=""window""><img src=""/image/window.jpg""");
                BeginWriteAttribute("alt", "\r\n                                                                                                   alt=\"", 6279, "\"", 6385, 0);
                EndWriteAttribute();
                WriteLiteral(@" />
                            </label>
                        </div>
                        <div>
                            <label>
                                <input type=""radio"" class=""avtar"" name=""avtar"" value=""woman""><img src=""/image/woman.jpg""");
                BeginWriteAttribute("alt", "\r\n                                                                                                  alt=\"", 6649, "\"", 6754, 0);
                EndWriteAttribute();
                WriteLiteral(@" />
                            </label>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""setting-address-details-alert alert alert-danger mt-3 d-none"" role=""alert"">
                This is a danger alert???check it out!
            </div>
            <div class=""basic-details-box"">

                <div class=""basic-details mt-5"">
                    <span>My address</span>
                </div>
            </div>
            <div class=""container mt-3"">
                <div class=""row"">
                    <div class=""col-lg-4 mb-3"">
                        <label for=""streetname""> Street Name </label>
                        <input type=""text"" class=""form-control"" placeholder=""Street Name"" id=""streetname"" />
                    </div>
                    <div class=""col-lg-4 mb-3"">
                        <label for=""housenumber""> House Number </label>
                        <input type=""text"" placeholder=""Hou");
                WriteLiteral(@"se Number"" class=""form-control"" id=""housenumber"" />
                    </div>
                    <div class=""col-lg-4"">
                        <label for=""postalcode"">Postal code</label>
                        <input type=""text"" class=""form-control"" placeholder=""Postal Code"" id=""postalcode"" />
                    </div>
                </div>
                <div class=""row"">
                    <div class=""col-lg-4"">
                        <label for=""City"">City</label>
                        <input type=""hidden"" id=""State"" />
                        <input type=""text"" class=""form-control"" disabled placeholder=""City"" id=""City"" />
                    </div>
                </div>
            </div>
            <input id=""updateUserDatabtn"" type=""button"" value=""Save"" class=""save-btn"" />
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
            WriteLiteral(@"
    </div>

    <div class=""my-setting-change-password d-none"">
        <div class="" user-update-password-alert alert  mt-3 d-none"" role=""alert"">
            This is a danger alert???check it out!
        </div>
        <span class=""user-menu-header"">Change Password</span>
        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e2bb2c9fbdbaaf5dae390f94f46de5ab9029ca4914664", async() => {
                WriteLiteral(@"
            <div class=""mt-3"">
                <label for=""currentPassword""> Old Password </label>
                <input type=""password"" class=""form-control"" placeholder=""Current Password"" id=""currenPassword"" />
            </div>
            <div class=""mt-3"">
                <label for=""NewPassword""> New Password </label>
                <input type=""password"" class=""form-control"" placeholder=""Password"" id=""NewPassword"" />
            </div>
            <div class=""mt-3"">
                <label for=""confirmPassword""> Confirm Password </label>
                <input type=""password"" class=""form-control"" placeholder=""Confirm Password"" id=""confirmPassword"" />
                <span class=""confirmpass d-none text-danger"" style=""font-size:12px; font-weight:700; letter-spacing:1px"">password not match!</span>
            </div>

            <input id=""updateUserPassword"" type=""button"" class=""save-btn "" value=""Save"" />
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
            WriteLiteral("\r\n    </div>\r\n</div>");
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
